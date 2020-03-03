using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace working_time_monitoring_management
{
    class WTMM_Class
    {
    }

    public class AddToDatabase
    {
        public static void add(string name, string surname, int card_number)
        {
            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO employee(Name, Surname, Card_number) VALUES('{name}','{surname}', {card_number})";
            cmd.ExecuteNonQuery();

        }
    }

    public class UpdateDatabase
    {
        public static void change_card_number(string name, string surname, int new_card_number)
        {
            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"UPDATE employee SET Card_number={new_card_number} WHERE name like'{name}')";
            cmd.ExecuteNonQuery();

        }
    }
}
