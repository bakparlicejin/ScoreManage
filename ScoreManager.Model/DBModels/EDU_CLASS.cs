using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_CLASS
    {
           public EDU_CLASS(){


           }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>   
        [SqlSugar.SugarColumn(IsPrimaryKey = true, OracleSequenceName = "SEQ_ID")]
        public long ID {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string NAME {get;set;}

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime ADDTIME { get; set; }
        /// <summary>
        /// 是否启用 0：不启用 1：启用 默认启用
        /// </summary>
        public string ISENABLE { get; set; } = "1";
        /// <summary>
        /// 班主任老师名字
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore =true)]
        public string MasterTeacherName { get; set; }
        /// <summary>
        /// 班主任老师id
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public long MasterTeacherId { get; set; }
        /// <summary>
        /// 学科老师id
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public List< long> SubjectTeacherIds { get; set; }
        /// <summary>
        /// 学科任老师名字
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string SubjectTeacherNames { get; set; }

    }
}
