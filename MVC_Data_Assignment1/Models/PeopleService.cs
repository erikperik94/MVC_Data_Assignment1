using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment1.Models
{
    public class PeopleService : IPeopleService
    {
        public PeopleViewModel All()
        {
            InMemoryPeopleRepo personRepoList = new InMemoryPeopleRepo();

            PeopleViewModel personViewMod = new PeopleViewModel() { PeopleListView = personRepoList.Read() };

            return personViewMod;
        }
        public Person Add(CreatePersonViewModel person)
        {
            InMemoryPeopleRepo createAndStorePerson = new InMemoryPeopleRepo();
            Person madePerson = createAndStorePerson.Create(person.PersonName, person.PersonPhoneNumber, person.PersonCity);

            return madePerson;
        }
        public bool Remove(int id)
        {
            InMemoryPeopleRepo deletePersonFromRepo = new InMemoryPeopleRepo();
            Person personToDelete = deletePersonFromRepo.Read(id);
            deletePersonFromRepo.Delete(personToDelete);

            return true;
        }        

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            InMemoryPeopleRepo loadListForSearch = new InMemoryPeopleRepo();

            search.PeopleListView.Clear();

            foreach (Person item in loadListForSearch.Read())
            {
                if(item.PersonName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase) || item.PersonCity.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    search.PeopleListView.Add(item);
                }

            }
            if (search.PeopleListView.Count == 0)
            {
                search.SearchResultEmpty = $"No Person or City could be found, matching \"{search.FilterString}\" ";
            }
            else
            {
                search.SearchResultEmpty = "";
            }
            return search;
        }
    }
}
