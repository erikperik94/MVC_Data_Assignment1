using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_Data_Assignment1.Models
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        public List<Person> PeopleListView { get; set; }
        public string FilterString { get; set; }
        public string SearchResultEmpty { get; set; }
        public PeopleViewModel()
        {
            PeopleListView = new List<Person>();
        }
    }
}
