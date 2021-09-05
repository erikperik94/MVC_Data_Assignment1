using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Data_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment1.Controllers
{
    public class PeopleController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Eriks Project";

            PeopleService checkListView = new PeopleService();
            PeopleViewModel peopleList = new PeopleViewModel();

            InMemoryPeopleRepo makeBaseList = new InMemoryPeopleRepo();

            peopleList.PeopleListView = checkListView.All().PeopleListView;
            
            if(peopleList.PeopleListView == null || peopleList.PeopleListView.Count == 0)
            {
                makeBaseList.CreateBasePersons();
            }
            
            return View(peopleList);
        }
        
        [HttpPost]
        public IActionResult Index(PeopleViewModel viewModel)
        {
            PeopleService filterString = new PeopleService();

            viewModel = filterString.FindBy(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel personViewModel)
        {
            var newModel = new PeopleViewModel();
            PeopleService repoList = new PeopleService();

            if (ModelState.IsValid)
            {
                newModel.PersonName = personViewModel.PersonName;
                newModel.PersonPhoneNumber = personViewModel.PersonPhoneNumber;
                newModel.PersonCity = personViewModel.PersonCity;

                newModel.PeopleListView = repoList.All().PeopleListView;

                repoList.Add(personViewModel);

                ViewBag.Mess = "Person Added!";
                return View("Index", newModel);
            }

            newModel.PersonName = personViewModel.PersonName;
            newModel.PersonPhoneNumber = personViewModel.PersonPhoneNumber;
            newModel.PersonCity = personViewModel.PersonCity;

            newModel.PeopleListView = repoList.All().PeopleListView;
            return View("index", newModel);
        }

        public IActionResult DeletePerson(int id)
        {
            PeopleService deleteById = new PeopleService();
            deleteById.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
