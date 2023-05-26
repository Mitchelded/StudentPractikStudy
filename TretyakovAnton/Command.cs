using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class Command
    {
        public void Delete()
        {
        Try4:
            try
            {
                using (var db = new StudentContext())
                {
                    Console.WriteLine("По какому принципу удалять?(id(id)/last_name(ln)/first_name(fn)/age(age)/cource(crc))");
                    string action3 = Console.ReadLine();
                Try3:
                    try
                    {
                        switch (action3.ToLower())
                        {
                            case "id":
                                Console.WriteLine("Введите id нужного студента");
                                int id = int.Parse(Console.ReadLine());
                                var student = db.Students.FirstOrDefault(p => p.Id == id);
                                if (student != null)
                                {
                                    db.Students.Remove(student);
                                    db.SaveChanges();
                                }
                                break;
                            case "l_n":
                                Console.WriteLine("Введите фамилию");
                                string last_name = Console.ReadLine();
                                student = db.Students.FirstOrDefault(p => p.Last_Name.ToLower() == last_name.ToLower());
                                if (student != null)
                                {
                                    db.Students.Remove(student);
                                    db.SaveChanges();
                                }

                                break;
                            case "f_n":
                                Console.WriteLine("Введите имя");
                                string first_name = Console.ReadLine();
                                student = db.Students.FirstOrDefault(p => p.First_Name.ToLower() == first_name.ToLower());
                                if (student != null)
                                {
                                    db.Students.Remove(student);
                                    db.SaveChanges();
                                }

                                break;

                            case "age":
                                Console.WriteLine("Введите возраст нужного студента");
                                int age = int.Parse(Console.ReadLine());
                                student = db.Students.FirstOrDefault(p => p.Age == age);
                                if (student != null)
                                {
                                    db.Students.Remove(student);
                                    db.SaveChanges();
                                }
                                break;
                            case "crc":
                                Console.WriteLine("Введите курс нужного студента");
                                int cource = int.Parse(Console.ReadLine());
                                student = db.Students.FirstOrDefault(p => p.Cource == cource);
                                if (student != null)
                                {
                                    db.Students.Remove(student);
                                    db.SaveChanges();
                                }
                                break;

                        }

                    }
                    catch (Exception ex) { Console.WriteLine($"Неверный формат данных \n {ex}"); goto Try3; }
                }

            }
            catch (Exception ex) { Console.WriteLine($"Неверная команда \n {ex}"); goto Try4; }
        }
        public void Search()
        {
        Try5:
            try
            {
                Console.WriteLine("По какому принципу искать? (id(id)/last_name(ln)/first_name(fn)/age(age)/cource(crc)");
                string action2 = Console.ReadLine();
                Student student = new Student();

            Try2:
                try
                {
                    switch (action2.ToLower())
                    {
                        case "id":
                            using (var db = new StudentContext())
                            {
                                Console.WriteLine("Введите id");
                                int id = int.Parse(Console.ReadLine());
                                var persons = db.Students.Where(p => p.Id == id);



                                if (persons != null)
                                {
                                    foreach (var person in persons)
                                    {
                                        Console.WriteLine($"Id: {person.Id}, " +
                                            $"Last_Name: {person.Last_Name}, " +
                                            $"First_Name: {person.First_Name}, " +
                                            $"Age: {person.Age}, " +
                                            $"Cource: {person.Cource}");
                                    }
                                }
                                else { Console.WriteLine("id не найден"); }

                            }
                            break;
                        case "l_n":
                            using (var db = new StudentContext())
                            {
                                Console.WriteLine("Введите фамилию");
                                string last_name = Console.ReadLine();
                                var persons = db.Students.Where(p => p.Last_Name == last_name).ToList();


                                foreach (var person in persons)
                                {
                                    Console.WriteLine($"Id: {person.Id}, " +
                                        $"Last_Name: {person.Last_Name}, " +
                                        $"First_Name: {person.First_Name}, " +
                                        $"Age: {person.Age}, " +
                                        $"Cource: {person.Cource}");
                                }
                            }
                            break;
                        case "f_n":
                            using (var db = new StudentContext())
                            {
                                Console.WriteLine("Введите имя");
                                string first_name = Console.ReadLine();
                                var persons = db.Students.Where(p => p.First_Name == first_name).ToList();


                                foreach (var person in persons)
                                {
                                    Console.WriteLine($"Id: {person.Id}, " +
                                        $"Last_Name: {person.Last_Name}, " +
                                        $"First_Name: {person.First_Name}, " +
                                        $"Age: {person.Age}, " +
                                        $"Cource: {person.Cource}");
                                }
                            }
                            break;
                        case "age":
                            using (var db = new StudentContext())
                            {
                                Console.WriteLine("Введите возраст");
                                int age = int.Parse(Console.ReadLine());
                                var persons = db.Students.Where(p => p.Age == age);


                                foreach (var person in persons)
                                {
                                    Console.WriteLine($"Id: {person.Id}, " +
                                        $"Last_Name: {person.Last_Name}, " +
                                        $"First_Name: {person.First_Name}, " +
                                        $"Age: {person.Age}, " +
                                        $"Cource: {person.Cource}");
                                }
                            }
                            break;
                        case "crc":
                            using (var db = new StudentContext())
                            {
                                Console.WriteLine("Введите курс");
                                int cource = int.Parse(Console.ReadLine());
                                var persons = db.Students.Where(p => p.Cource == cource);


                                foreach (var person in persons)
                                {
                                    Console.WriteLine($"Id: {person.Id}, " +
                                        $"Last_Name: {person.Last_Name}, " +
                                        $"First_Name: {person.First_Name}, " +
                                        $"Age: {person.Age}, " +
                                        $"Cource: {person.Cource}");
                                }
                            }
                            break;

                    }
                    
                }
                catch (Exception ex) { Console.WriteLine($"Неверный формат данных \n {ex}"); goto Try2; }
            }
            catch (Exception ex) { Console.WriteLine($"Неверный команда \n {ex}"); goto Try5; }
        }

        public static List<Student> students = new List<Student>();
        public void Add()
        {
            using (StudentContext one = new StudentContext())
            {
            Try6:
                try
                {
                    Console.WriteLine("Количество студентов: ");
                    int numberStudent = int.Parse(Console.ReadLine());
                    Student Student = new Student();
                    for (int i = 0; i < numberStudent; i++)
                    {
                    Try1:
                        try
                        {
                            Console.WriteLine("First_Name: ");
                            string first_name = Console.ReadLine();

                            Console.WriteLine("Last_Name: ");
                            string last_name = Console.ReadLine();
                            int age, cource;

                            Console.WriteLine("Age: ");
                            age = int.Parse(Console.ReadLine());

                            Console.WriteLine("Cource: ");
                            cource = int.Parse(Console.ReadLine());

                            students.Add(new Student
                            {
                                First_Name = first_name,
                                Last_Name = last_name,
                                Age = age,
                                Cource = cource
                            });
                        }
                        catch (Exception ex) { Console.WriteLine($"Введен неверный формат данных\n {ex}"); goto Try1; }

                    }
                    one.Students.AddRange(students);
                    one.SaveChanges();
                }
                catch (Exception ex) { Console.WriteLine($"Введен неверное количество студентов\n {ex}"); goto Try6; }

            }



        }

    }
}
