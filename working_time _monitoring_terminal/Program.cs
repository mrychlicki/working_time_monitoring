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
                    Terminal_Add.add(card_number);

                }
            }
            
        }
    }
}
