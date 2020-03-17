using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace working_time_monitoring_management
{
    
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
            cmd.CommandText = $"UPDATE employee SET Card_number = {new_card_number} WHERE name like'{name}' and surname like '{surname}'";
            cmd.ExecuteNonQuery();

        }
    }

    public class ShowEmployee
    {
        public static string name_;
        public static string surname_;
        public static void show(int card_number)
        {
            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            string sql2 = $"SELECT * FROM employee WHERE Card_number = {card_number}";
            var cmd2 = new MySqlCommand(sql2, con);
            var rdr_all = cmd2.ExecuteReader();
            rdr_all.Read();
            name_ = rdr_all.GetString(1).ToString();
            surname_ = rdr_all.GetString(2).ToString();
           
        }
    }
    public class ShowAllEmployee
    {
        public static DataView defaultview_;

        public static void showAll()
        {
            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            string sql2 = $"SELECT * FROM employee";
            var cmd2 = new MySqlCommand(sql2, con);
            cmd2.ExecuteNonQuery();

            MySqlDataAdapter data = new MySqlDataAdapter(cmd2);
            DataTable dt = new DataTable("employee");
            data.Fill(dt);
            defaultview_ = dt.DefaultView;
            data.Update(dt);
        }
    }
    

    public class WorkingTime
    {
        public static string workingtime;
        public static void showWorkingTime(string name, string surname)
        {
            List<TimeSpan> time_S = new List<TimeSpan>();
            List<TimeSpan> time_e = new List<TimeSpan>();

            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            string sql2 = $"SELECT * FROM time_monitoring as tm JOIN employee as e on tm.FK_ID=e.ID WHERE e.Surname LIKE '{surname}' and e.Name LIKE '{name}'";
            var cmd2 = new MySqlCommand(sql2, con);
            var rdr_all = cmd2.ExecuteReader();

            while (rdr_all.Read())
            {
                time_S.Add(rdr_all.GetTimeSpan(2));
                time_e.Add(rdr_all.GetTimeSpan(3));
            }

            TimeSpan count = new TimeSpan();

            for (int i = 0; i < time_S.Count; i++)
            {
                TimeSpan ts = (time_e[i] - time_S[i]);
                count += ts;
            }
            if (count.Days > 0)
            {
                string count_string = count.ToString();
                string[] count_convert = count_string.Split('.');
                string[] count_convert2 = count_convert[1].Split(':');
                string count_convert_string = ((int.Parse(count_convert[0]) * 24) + int.Parse(count_convert2[0])).ToString();
                workingtime = ($"{count_convert_string}:{count_convert2[1]}:{count_convert2[2]}");
            }
            else
            {
                workingtime = count.ToString();
            }

        }
    }
}
