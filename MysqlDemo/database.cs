using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
using System.Data;


namespace MysqlDemo
{
    class database
    {
        private MySqlConnection conn;//数据库连接句柄
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public MySqlConnection ConnectDb()
        {
            conn = new MySqlConnection("Database=fang;Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=Hlxm123456;");
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        /// <param name="conn"></param>句柄
        public void CloseDb(MySqlConnection conn)
        {
            conn.Close();
        }

        public void CreateDb()
        {
            MySqlConnection conn = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=Hlxm123456;");
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE fang;", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            Console.Write("ok!");
           // Console.ReadLine();
           // conn.Close();  
        }

        public void CreateTable(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand("CREATE TABLE Test (id int, name varChar(10))", conn);
            cmd.ExecuteNonQuery();
          //  Console.Write("ok!");
          //  Console.ReadLine();
            
        }

        public void InsertData(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO test (id,name) VALUES (2, '章奇')", conn);
            cmd.ExecuteNonQuery();
        }

        public void ReadData(MySqlConnection conn)
        {
            String sqlstr = "select * from test";
            MySqlDataAdapter mysqlad = new MySqlDataAdapter(sqlstr, conn);
            MySqlCommandBuilder sb1 = new MySqlCommandBuilder(mysqlad);
            DataSet ds = new DataSet();
            mysqlad.Fill(ds, "Table1");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine("id:{0},name:{1}",row[0],row[1]);
            }
            
            
        }
    } 
}
