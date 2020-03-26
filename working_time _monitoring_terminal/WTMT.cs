using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace working_time__monitoring_terminal
{
    class Connect
    {
        private static string userid = "Administrator";
        private static string password = "@dministrato";
        private string adres = $@"server=localhost;userid={userid};password={password};database=db_working_time";
        public string connect_adress()
        {
            return adres;
        }
    }
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
            Connect connect = new Connect();
            var connection = new MySqlConnection(connect.connect_adress());
            connection.Open();
            var command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = $"INSERT INTO time_monitoring (FK_ID) SELECT e.ID FROM employee as e WHERE e.Card_number like {card_number}";
            command.ExecuteNonQuery();

        }
    }
    
    public class Verification
    {
        public static bool check(int card_number)
        {
            Connect connect = new Connect();
            var connection = new MySqlConnection(connect.connect_adress());
            connection.Open();
            var command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT COUNT(e.ID) FROM employee as e JOIN time_monitoring as tm on e.ID=tm.FK_ID WHERE e.Card_number LIKE {card_number} and tm.date LIKE '{Date.date()}'";
            var rdr = command.ExecuteReader();
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
            Connect connect = new Connect();
            var connection = new MySqlConnection(connect.connect_adress());
            connection.Open();
            var command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = $"update time_monitoring as tm JOIN employee as e on tm.FK_ID=e.ID SET tm.time_end=CURRENT_TIMESTAMP WHERE e.Card_number like {card_number} and tm.date LIKE '{Date.date()}'";
            command.ExecuteNonQuery();

        }
    }
}
