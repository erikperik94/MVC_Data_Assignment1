using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment1.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _personList = new List<Person>();
        private static int _idCounter;

        public void CreateBasePersons()
        {
            InMemoryPeopleRepo personDataBase = new InMemoryPeopleRepo();
            personDataBase.Create("Erik Aggfelt", "072 0000000", "Gothenburg");
            personDataBase.Create("Rangar Karlsson", "072 0000000", "Gothenburg");
            personDataBase.Create("Andre Svensson", "072 0000000", "Gothenburg");
            personDataBase.Create("Louise Kling", "072 0000000", "Gothenburg");
        }

        public Person Create(string PersonName, string PersonPhoneNumber, string PersonCity)
        {
            Person newPerson = new Person(_idCounter, PersonName, PersonPhoneNumber, PersonCity);
            _personList.Add(newPerson);
            _idCounter++;
            return newPerson;
        }
        public bool Delete(Person person)
        {
            _personList.Remove(person);
            return true;
        }
        public List<Person> Read()
        {
            return _personList;
        }
        public Person Read(int id)
        {
            Person findPersonById = _personList.Find(idNr => idNr.PersonId == id);
            return findPersonById;
        }
        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
