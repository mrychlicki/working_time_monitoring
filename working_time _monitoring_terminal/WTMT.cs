using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace working_time__monitoring_terminal
{
    public class Date
    {
        public static string date()
        {
            DateTime dateAndTime = DateTime.Now;
            string date = dateAndTime.ToString("yyyy-MM-dd");
            return date;
        }
    }
    public class Terminal_Add
    {
        public static void add(int card_number)
        {
            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO time_monitoring (FK_ID) SELECT e.ID FROM employee as e WHERE e.Card_number like {card_number}";
            cmd.ExecuteNonQuery();

        }
    }
    
    public class Verification
    {
        public static bool check(int card_number)
        {
            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT COUNT(e.ID) FROM employee as e JOIN time_monitoring as tm on e.ID=tm.FK_ID WHERE e.Card_number LIKE {card_number} and tm.date LIKE '{Date.date()}'";
            var rdr = cmd.ExecuteReader();
            rdr.Read();
            int x = rdr.GetInt32(0);
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class Update_end_time
    {
        public static void add_end_time(int card_number)
        {
            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"update time_monitoring as tm JOIN employee as e on tm.FK_ID=e.ID SET tm.time_end=CURRENT_TIMESTAMP WHERE e.Card_number like {card_number} and tm.date LIKE '{Date.date()}'";
            cmd.ExecuteNonQuery();

        }
    }
}
