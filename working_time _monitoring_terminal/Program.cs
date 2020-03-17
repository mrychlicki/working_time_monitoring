using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace working_time__monitoring_terminal
{
    class Program
    {
        static void Main(string[] args)
        {/*
            string end = "";
            while (end != "exit")
            {
                string number = Console.ReadLine();
                if(number == "exit")
                {
                    end = "exit";
                }
                else
                {
                    int card_number = int.Parse(number);
                   bool check = Verification.check(card_number);

                   if (check == false)
                   {
                       Terminal_Add.add(card_number);

                   }
                   else
                   {
                       Update_end_time.add_end_time(card_number);
                   }

               }
            }
            
            */
            string name = "Adam";
            string surname = "Nowak";
            List<TimeSpan> time_S = new List<TimeSpan>();
            List<TimeSpan> time_e = new List<TimeSpan>();

            string cs = @"server=localhost;userid=Administrator;password=@dministrato;database=db_working_time";
            var con = new MySqlConnection(cs);
            con.Open();
            string sql2 = $"SELECT * FROM time_monitoring as tm JOIN employee as e on tm.FK_ID=e.ID WHERE e.Surname LIKE '{surname}' and e.Name LIKE '{name}'";
            var cmd2 = new MySqlCommand(sql2, con);
            var rdr_all = cmd2.ExecuteReader();
            //rdr_all.Read();
             

            while (rdr_all.Read())
            {
                //Console.WriteLine("{0} {1} {2} {3}", rdr_all.GetInt32(0), rdr_all.GetDateTime(1),
                       // rdr_all.GetTimeSpan(2), rdr_all.GetTimeSpan(3));
                time_S.Add(rdr_all.GetTimeSpan(2));
                time_e.Add(rdr_all.GetTimeSpan(3));

            }
            TimeSpan count = new TimeSpan();

            for (int i=0; i<time_S.Count; i++)
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
                //string x = ((int.Parse(count.ToString().Split('.')[0]) * 24) + int.Parse(count.ToString().Split('.')[1].Split(':')[0])).ToString();
                Console.WriteLine($"{count_convert_string}:{count_convert2[1]}:{count_convert2[2]}");
            }
            else
            {
                Console.WriteLine(count);
            }
            
        }
    }
}
