using Models;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceImpl
{
    public class ClassService : BaseService<EDU_CLASS>, IClassService
    {
        public ClassService(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {
        }

        public List<EDU_CLASS> GetAllClassInfo()
        {
            List<EDU_CLASS> retList = _sqlSugarClient.Queryable<EDU_CLASS>().Where(c => c.ISENABLE == "1")?.ToList();
            if (retList != null && retList.Any())
            {
                foreach (var item in retList)
                {
                    var masterTeacher = _sqlSugarClient.Queryable<EDU_TEACHER, EDU_CLASS_TEACHER, EDU_ROLE>((t, ct, r) => new JoinQueryInfos(
                          JoinType.Inner, t.ID == ct.TEACHERID,
                          JoinType.Inner, ct.ROLEID == r.ID)
                      ).Where((t, ct, r) => ct.CLASSID == item.ID && r.NAME == "班主任")?.First(); ;
                    
                    if (masterTeacher != null)
                    {
                        item.MasterTeacherName = masterTeacher.NAME;
                        item.MasterTeacherId = masterTeacher.ID;
                    }

                    var subjectTeachers = _sqlSugarClient.Queryable<EDU_TEACHER, EDU_CLASS_TEACHER, EDU_ROLE>((t, ct, r) => new JoinQueryInfos(
                          JoinType.Inner, t.ID == ct.TEACHERID,
                          JoinType.Inner, ct.ROLEID == r.ID)
                      ).Where((t, ct, r) => ct.CLASSID == item.ID && r.NAME == "学科老师")?.ToList();
                    if (subjectTeachers != null && subjectTeachers.Any())
                    {
                        item.SubjectTeacherNames = String.Join("，", subjectTeachers?.Select(c => c.NAME));
                        item.SubjectTeacherIds = subjectTeachers.Select(c => c.ID).ToList();
                    }


                }
            }
            return retList;
        }

        /// <summary>
        /// 添加班级信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool AddClass(AddClassParameter parameter, out string msg)
        {
            msg = "";
            try
            {
                TransactionOperation(c =>
                {
                    //增加班级
                    EDU_CLASS cl = new EDU_CLASS();
                    cl.NAME = parameter.ClassName;
                    cl.ISENABLE = parameter.IsEnable;
                    cl.ADDTIME = DateTime.Now;
                    int id = c.Insertable<EDU_CLASS>(cl).ExecuteReturnIdentity();
                    //增加中间表 
                    long? masterRoleId = c.Queryable<EDU_ROLE>().Where(x => x.NAME == "班主任")?.First()?.ID;
                    if (masterRoleId.HasValue && parameter.MasterTeacherId > 0)
                    {
                        c.Insertable(new EDU_CLASS_TEACHER() { CLASSID = id, TEACHERID = parameter.MasterTeacherId, ROLEID = masterRoleId.Value }).ExecuteCommand();
                    }
                    long? subjectRoleId = c.Queryable<EDU_ROLE>().Where(x => x.NAME == "学科老师")?.First()?.ID;
                    if (subjectRoleId.HasValue && parameter.SubjectTeacherIds.Count > 0)
                    {
                        foreach (var item in parameter.SubjectTeacherIds)
                        {
                            c.Insertable(new EDU_CLASS_TEACHER() { CLASSID = id, TEACHERID = item, ROLEID = subjectRoleId.Value }).ExecuteCommand();

                        }
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                msg = "增加失败";
                return false;
            }

        }



        /// <summary>
        /// 根据班级id 获取班级信息 携带班级老师信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EDU_CLASS GetAllClassInfoByClassId(int id)
        {
            EDU_CLASS ret = _sqlSugarClient.Queryable<EDU_CLASS>().Single(c => c.ID == id);
            if (ret != null)
            {

                var masterTeacher = _sqlSugarClient.Queryable<EDU_TEACHER, EDU_CLASS_TEACHER, EDU_ROLE>((t, ct, r) => new JoinQueryInfos(
                      JoinType.Inner, t.ID == ct.TEACHERID,
                      JoinType.Inner, ct.ROLEID == r.ID)
                  ).Where((t, ct, r) => ct.CLASSID == ret.ID && r.NAME == "班主任")?.First(); ;
               
                if (masterTeacher != null)
                {
                    ret.MasterTeacherName = masterTeacher.NAME;
                    ret.MasterTeacherId = masterTeacher.ID;
                }

                var subjectTeachers = _sqlSugarClient.Queryable<EDU_TEACHER, EDU_CLASS_TEACHER, EDU_ROLE>((t, ct, r) => new JoinQueryInfos(
                      JoinType.Inner, t.ID == ct.TEACHERID,
                      JoinType.Inner, ct.ROLEID == r.ID)
                  ).Where((t, ct, r) => ct.CLASSID == ret.ID && r.NAME == "学科老师")?.ToList();
                if (subjectTeachers != null && subjectTeachers.Any())
                {
                    ret.SubjectTeacherNames = String.Join("，", subjectTeachers?.Select(c => c.NAME));
                    ret.SubjectTeacherIds = subjectTeachers.Select(c => c.ID).ToList();
                }
            }
            return ret;
        }

        /// <summary>
        /// 修改班级信息 修改班级老师信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateTeacher(UpdateClassParameter parameter, out string msg)
        {
            msg = "";
            try
            {
                TransactionOperation(c =>
                {
                    //修改班级 TODO 如果班级需要学生人数字段，这里要修改

                    //修改中间表 先删除再增加
                    c.Deleteable<EDU_CLASS_TEACHER>().Where(x => x.CLASSID == parameter.Id).ExecuteCommand();
                   
                    long? masterRoleId = c.Queryable<EDU_ROLE>().Where(x => x.NAME == "班主任")?.First()?.ID;
                    if (masterRoleId.HasValue && parameter.MasterTeacherId > 0)
                    {
                        c.Insertable(new EDU_CLASS_TEACHER() { CLASSID = parameter.Id, TEACHERID = parameter.MasterTeacherId, ROLEID = masterRoleId.Value }).ExecuteCommand();
                    }
                    long? subjectRoleId = c.Queryable<EDU_ROLE>().Where(x => x.NAME == "学科老师")?.First()?.ID;
                    if (subjectRoleId.HasValue && parameter.SubjectTeacherIds.Count > 0)
                    {
                        foreach (var item in parameter.SubjectTeacherIds)
                        {
                            c.Insertable(new EDU_CLASS_TEACHER() { CLASSID = parameter.Id, TEACHERID = item, ROLEID = subjectRoleId.Value }).ExecuteCommand();

                        }
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                msg = "修改失败";
                return false;
            }
        }
    }
}
