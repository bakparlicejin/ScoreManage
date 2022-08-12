using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeFirstConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region 实体生成数据库和表

                //数据库链接字符串
                string ConnectionString2 = "Data Source=orcl;User ID=scott;Password=Comeon007;";

                ConnectionConfig config2 = new ConnectionConfig()
                {
                    ConnectionString = ConnectionString2,
                    DbType = DbType.Oracle,
                    InitKeyType = InitKeyType.Attribute //初始化主键和自增列信息到ORM的方式
                };

                //通过实体生成数据库


                Assembly assembly = Assembly.LoadFrom("ScoreManager.Model.dll");
                IEnumerable<Type> typelist

                    = assembly.GetTypes().Where(c => c.Namespace == "Models");

                bool Backup = false;  //是否备份
                using (SqlSugarClient Client = new SqlSugarClient(config2))
                {
                    Client.DbMaintenance.CreateDatabase(); //创建一个数据库出来
                    if (Backup)
                    {
                        Client.CodeFirst.BackupTable().InitTables(typelist.ToArray());
                    }
                    else
                    {
                        Client.CodeFirst.InitTables(typelist.ToArray());
                    }
                }


                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
