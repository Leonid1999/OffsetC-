using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManeger
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataContext db = new DataContext())
            {
                // создаем два объекта User
                Messege user1 = new SMS {Id=1, Name = "Tom" };
                Messege user2 = new MMS { Id = 2, Name = "Mark" };
                Messege user3 = new VideoMess { Id = 3, Name = "Lucy"};

                // добавляем их в бд
                db.Messege.Add(user1);
                db.Messege.Add(user2);
                db.Messege.Add(user3);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var messeges = db.Messege;
                Console.WriteLine("Список объектов:");
                foreach (Messege u in messeges)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Type);
                }

                int number1 = db.Messege.Count();
                // найдем кол-во моделей, которые в названии содержат Samsung
                int number2 = db.Messege.Count(p => p.Type.Contains("SMS"));

                Console.WriteLine(number1);
                Console.WriteLine(number2);

                var mess = db.Messege.Where(p => p.Type.Contains("SMS"))
       .Union(db.Messege.Where(p => p.Name.Contains("Mark")));
                foreach (var item in mess)
                    Console.WriteLine(item.Name, item.Type);

            }
            Console.Read();
        }
    }
}