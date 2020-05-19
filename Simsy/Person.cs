using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simsy
{
    class Person
    {
        static int id;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public House OwnsAHouse { get; private set; } = null;
        public Person()
        {

        }

        public Person(string _name, string _surname, House _house = null)
        {
            this.Id = id++;
            this.Name = _name;
            this.Surname = _surname;
            this.OwnsAHouse = null;
        }

        public bool BecomeHomeowner(House _house)
        {
            if (OwnsAHouse != null) { Console.WriteLine("This person has home!"); return false; }
            this.OwnsAHouse = _house;
            return true;
        }

        public bool LoseHouse()
        {
            if (OwnsAHouse == null) { Console.WriteLine("This person has no home!"); return false; }
            this.OwnsAHouse = null;
            return true;
        }

        public string ShowInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {Id} name: {Name}, surname: {Surname}, has house: {OwnsAHouse.Address}\n");
            return sb.ToString();
        }
    }
}
