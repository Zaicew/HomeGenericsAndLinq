using HomeGenericsLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simsy
{
    class House
    {
        static int id = 0;
        public int Id { get; private set; }
        public string Address { get; private set; }
        public double AreaOfTheHouse { get; private set; }
        public int Capacity { get; private set; }

        List<Door> Doors = new List<Door>();

        public List<Person> PersonListInHome = new List<Person>();

        public House()
        {

        }
        public House(string _address, double _areaOfTheHouse)
        {
            this.Id = id++;
            this.Address = _address;
            this.AreaOfTheHouse = _areaOfTheHouse;
            this.Capacity = this.Capacity = Convert.ToInt16(Math.Round(AreaOfTheHouse / 15));
        }

        List<T> list<T>()
        {
            if (typeof(T) == typeof(Door))
                return Doors as List<T>;
            if (typeof(T) == typeof(Person))
                return PersonListInHome as List<T>;
            return null;
        }
        public bool Add<T>(T Obj)
        {
            var tmp = list<T>();
            if (tmp == null || tmp.Contains(Obj)) return false;
            if (Obj is Person && PersonListInHome.Capacity >= Capacity) { Console.WriteLine("In the house is too many people!"); return false; }
            tmp.Add(Obj);
            Console.WriteLine($"Added: {Obj}, to: {tmp}");
            return true;
        }

        public bool Delete<T>(T Obj)
        {
            var tmp = list<T>();
            if (!tmp.Contains(Obj)) { Console.WriteLine($"We cannot delete this: {Obj} ! It's not there!"); return false; }
            tmp.Remove(Obj);
            return true;
        }

        public string WhoIsInTheHouse()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in PersonListInHome)
                sb.Append($"{element.Name}, {element.Surname} is in house {Address}\n");
            return sb.ToString();
        }

    }
}