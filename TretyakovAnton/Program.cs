using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            bool check = true;
            while (check) 
            {
                
                Command command = new Command();
                Console.WriteLine("Введите команду(add/srh/shw/del/q/clear)");
                string action = Console.ReadLine();

                
                if (action.ToLower() == "add" 
                    || action.ToLower() == "srh" 
                    || action.ToLower() == "shw" 
                    || action.ToLower() == "del" 
                    || action.ToLower() == "q"
                    || action.ToLower() == "clear"
                    )
                {
                    switch (action.ToLower())
                    {
                        case "add":
                            Add:
                            command.Add();
                            Console.WriteLine("Добавить еще? ((y)es/(n)o)");
                            string sol = Console.ReadLine();
                            switch(sol.ToLower())
                            {
                                case "y": goto Add;
                                case "n": break;
                            }
                            
                            break;
                        case "srh":
                            Srh:
                            command.Search();
                            Console.WriteLine("Искать еще? ((y)es/(n)o)");
                            sol = Console.ReadLine();
                            switch (sol.ToLower())
                            {
                                case "y": goto Srh;
                                case "n": break;
                            }
                            break;
                        case "shw":
                            using (StudentContext one = new StudentContext())
                            {
                                foreach (var student in one.Students)
                                {
                                    Console.WriteLine($"Id: {student.Id}, " +
                                        $"Last_Name: {student.Last_Name}, " +
                                        $"First_Name: {student.First_Name}, " +
                                        $"Age: {student.Age}, " +
                                        $"Cource: {student.Cource}");
                                }
                            }

                            break;
                        case "del":
                            Del:
                            command.Search();
                            Console.WriteLine("Удалить еще? ((y)es/(n)o)");
                            sol = Console.ReadLine();
                            switch (sol.ToLower())
                            {
                                case "y": goto Del;
                                case "n": break;
                            }

                            break;
                        case "clear":
                            Console.Clear();
                            break;
                        case "q":
                            check = false;
                            break;  

                        

                    }
                }
                else { Console.WriteLine("Нет такой команды"); }

            }
        }
    }
}
