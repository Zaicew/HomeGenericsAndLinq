using Simsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGenericsLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Daniel", "Agata", "Dawid", "Józek", "Weronika", "Justyna", "Adrian" };
            string[] surnames = { "Kowalski", "Nowicki", "Kabacki", "Leszcz", "Gołąb", "Sobstyl", "Zmierch" };
            string[] addresses = { "Parkowa 1", "Ścianowa 2", "Myślicielska 3", "Kwiecista 1", "Kolejna 3", "Główna 1", "Piastów 14/7" };
            double[] areasOfHouse = { 122.55, 131, 56.58, 55.54, 81.29, 100, 150 };
            Random rnd = new Random();

            Estate estate = new Estate();
            Person person = new Person("Justyna", "Zajas");
            House house = new House("Farum 402E", 130);

            {
                // houses
                addresses.ToList().ForEach(a => estate.Add(
                    new House(addresses[rnd.Next(1, 7)], areasOfHouse[rnd.Next(1, 7)])
                    ));
                // peoples
                for (int i = 0; i < 20; i++)
                    estate.Add(
                        new Person(names[rnd.Next(1, 7)], surnames[rnd.Next(1, 7)]));
                //adding houses to peoples as owners
                for (int i = 0; i < 10; i++)
                    estate.AssignPersonToHome(rnd.Next(1, 20), rnd.Next(1, 7));
                //entering to home by different persons
                for (int i = 0; i < 10; i++)
                    estate.EnterTheHouse(rnd.Next(1, 20), rnd.Next(1, 7));
            }

            Console.WriteLine("-----------Which house has Justyna?---------------");
            Console.WriteLine(estate.PersonOwnsHouseInfo("Justyna"));
            Console.WriteLine("-----------Which house has Adrian?---------------");
            Console.WriteLine(estate.PersonOwnsHouseInfo("Adrian"));
            Console.WriteLine("-----------Who is in house?---------------");
            Console.WriteLine(estate.WhiIsWhere());

            Console.ReadKey();

        }
    }
}
