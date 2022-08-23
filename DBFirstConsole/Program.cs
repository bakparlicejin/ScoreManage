using SqlSugar;
using System;

namespace DBFirstConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //数据库链接字符串
            string ConnectionString1 = "User Id=scott;Password=456258;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;Connection Timeout=20;";

            ConnectionConfig config = new ConnectionConfig()
            {
                ConnectionString = ConnectionString1,
                DbType = DbType.Oracle,
                InitKeyType = InitKeyType.SystemTable
            };

            using (SqlSugarClient Client = new SqlSugarClient(config))
            {
                //生成所有的表对应实体
                {
                    Client.DbFirst.CreateClassFile(@"D:\Desktop\ScoreManager(3)\ScoreManager\ScoreManager.Model\DBModels");
                }
                //{
                //    //条件筛选--生成实体
                //    Client.DbFirst.Where(c => c.StartsWith("Zhaoxi")).CreateClassFile(@"D:\ZXWork\Richard-Public\2021\2021ORM-SqlSugar\Advanced.Project\Advanced.SqlSugarDbFirst\DbModels"); 
                //}
            }
        }
    }
}
