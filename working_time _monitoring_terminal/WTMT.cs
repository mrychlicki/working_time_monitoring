using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace working_time__monitoring_terminal
{
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
}
