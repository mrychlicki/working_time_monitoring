using System;

namespace working_time__monitoring_terminal
{
    class Program
    {
        static void Main(string[] args)
        {
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
         

        }
    }
}
