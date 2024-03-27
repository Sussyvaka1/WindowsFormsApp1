using MySql.Data.MySqlClient;
using System.Data;

namespace DataControll
{
    public class dbcGetData
    {
        
            private static string connString = "server=localhost;port=3306;user id = root;password=;database=classicmodels;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlDataAdapter adr;
            DataTable dt = new DataTable();

            dbcGetData()
            {


            }
            public DataTable GetEmployeesData()
            {
                DataTable dt = new DataTable();
                string sqlCmd = "SELECT * FROM employees";
            adr = new MySqlDataAdapter(sqlCmd,conn);
            adr.Fill(dt);
            return dt;


            }

        }
    }