using HomeGenericsLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simsy
{
    public class Estate
    {
        List<House> housesOnEstateList { get; } = new List<House>();
        List<Person> personList = new List<Person>();
        List<T> list<T>()
        {
            if (typeof(T) == typeof(House))
                return housesOnEstateList as List<T>;
            if (typeof(T) == typeof(Person))
                return personList as List<T>;
            return null;
        }
        public bool Add<T>(T Obj)
        {
            var tmp = list<T>();
            if (tmp == null || tmp.Contains(Obj)) return false;
            tmp.Add(Obj);
            return true;
        }

        public bool Delete<T>(T Obj)
        {
            var tmp = list<T>();
            if (!tmp.Contains(Obj)) { Console.WriteLine($"We cannot delete this: {Obj} ! It's not there!"); return false; }
            tmp.Remove(Obj);
            return true;
        }

        public string PeopleInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"-----(ID)-----(Name)-----(Surname)-----");
            for (int i = 0; i < personList.Count; i++)
            {
                sb.Append($"Person {i}: {personList[i].Id}, {personList[i].Name}, {personList[i].Surname}\n");
            }
            return sb.ToString();
        }

        public bool EnterTheHouse(int _idHuman, int _idHome)
        {
            Person person = personList.Select(personList => personList).Where(p => p.Id == _idHuman).FirstOrDefault(p => p.Id == _idHuman);
            House house = housesOnEstateList.Select(housesOnEstate => housesOnEstate).Where(housesOnEstate => housesOnEstate.Id == _idHome).FirstOrDefault(p => p.Id == _idHome);
            if (house.PersonListInHome.Contains(person)) { Console.WriteLine("Person is actually in this house!"); return false; }
            return house.Add(person);
        }
        public string PersonOwnsHouseInfo(string _name)
        {
            StringBuilder sb = new StringBuilder();

            var listPersonByName = personList.Select(personList => personList)
                .Where(p => p.Name == _name).ToList();

            foreach (var element in listPersonByName)
            {
                if (element.OwnsAHouse != null) sb.Append($"{element.Name} {element.Surname} has house: {element.OwnsAHouse.Address}, which have size: {element.OwnsAHouse.AreaOfTheHouse}\n");
                else sb.Append($"{element.Name} {element.Surname} has no house!\n");
            }
            return sb.ToString();
        }

        public bool AssignPersonToHome(int _idHuman, int _idHome)
        {
            Person person = personList.Select(personList => personList).Where(p => p.Id == _idHuman).FirstOrDefault(p => p.Id == _idHuman);
            House house = housesOnEstateList.Select(housesOnEstate => housesOnEstate).Where(housesOnEstate => housesOnEstate.Id == _idHome).FirstOrDefault(p => p.Id == _idHome);
            return person.BecomeHomeowner(house);
        }

        public string WhiIsWhere()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in housesOnEstateList)
            {
                sb.Append(element.WhoIsInTheHouse());
            }
            return sb.ToString();
        }
    }
}
