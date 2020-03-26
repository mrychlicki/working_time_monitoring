using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace working_time_monitoring_management
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
    public class AddToDatabase
    {
        public static void add(string name, string surname, int card_number)
        {
            Connect connect = new Connect();
            var connection = new MySqlConnection(connect.connect_adress());
            connection.Open();
            var command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = $"INSERT INTO employee(Name, Surname, Card_number) VALUES('{name}','{surname}', {card_number})";
            command.ExecuteNonQuery();

        }
    }

    public class UpdateDatabase
    {
        public static void change_card_number(string name, string surname, int new_card_number)
        {
            Connect connect = new Connect();
            var connection = new MySqlConnection(connect.connect_adress());
            connection.Open();
            var command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = $"UPDATE employee SET Card_number = {new_card_number} WHERE name like'{name}' and surname like '{surname}'";
            command.ExecuteNonQuery();

        }
    }

    public class ShowEmployee
    {
        public static string name_;
        public static string surname_;
        public static void show(int card_number)
        {
            Connect connect = new Connect();
            var connection = new MySqlConnection(connect.connect_adress());
            connection.Open();
            string sql = $"SELECT * FROM employee WHERE Card_number = {card_number}";
            var command = new MySqlCommand(sql, connection);
            var read_all = command.ExecuteReader();
            read_all.Read();
            name_ = read_all.GetString(1).ToString();
            surname_ = read_all.GetString(2).ToString();
           
        }
    }
    public class ShowAllEmployee
    {
        public static DataView defaultview_;

        public static void showAll()
        {
            Connect connect = new Connect();
            var connection = new MySqlConnection(connect.connect_adress());
            connection.Open();
            string sql = $"SELECT * FROM employee";
            var command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            MySqlDataAdapter data = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable("employee");
            data.Fill(dataTable);
            defaultview_ = dataTable.DefaultView;
            data.Update(dataTable);
        }
    }
    

    public class WorkingTime
    {
        public static string workingtime_;
        public static void showWorkingTime(string name, string surname, int month)
        {
            List<TimeSpan> time_S = new List<TimeSpan>();
            List<TimeSpan> time_e = new List<TimeSpan>();

            Connect connect = new Connect();
            var connection = new MySqlConnection(connect.connect_adress());
            connection.Open();
            string sql = $"SELECT * FROM time_monitoring as tm JOIN employee as e on tm.FK_ID=e.ID WHERE e.Name LIKE '{name}' and e.Surname LIKE '{surname}' and tm.date BETWEEN '2020-{month}-01' AND '2020-{month}-31' AND tm.time_end IS NOT NULL;";
            var cmd2 = new MySqlCommand(sql, connection);
            var read_all = cmd2.ExecuteReader();

            while (read_all.Read())
            {
                time_S.Add(read_all.GetTimeSpan(2));
                time_e.Add(read_all.GetTimeSpan(3));
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
                workingtime_ = ($"{count_convert_string}:{count_convert2[1]}:{count_convert2[2]}");
            }
            else
            {
                workingtime_ = count.ToString();
            }

        }
    }
}
