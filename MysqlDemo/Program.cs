using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;

namespace MysqlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            database db = new database();
            MySqlConnection connection = db.ConnectDb();
            db.ReadData(connection);
            Console.WriteLine("ok");
            Console.ReadLine();

        }
    }
}
