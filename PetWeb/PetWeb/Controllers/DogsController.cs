using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetWeb.Models;
using PetWeb.Services;

namespace PetWeb.Controllers
{
    public class DogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private DogRepository dogRepository;

        public DogsController()
        {
            dogRepository = DogRepository.Instance;
        }

        //GET:/Dogs/List
        public IActionResult List()
        {
            return View(dogRepository.GetDogs());
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var allExistingDogs = dogRepository.GetDogs();

            Dog dogToEdit = allExistingDogs.Find(x => x.Id == id);

            return View(dogToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Dog model)
        {
            if (ModelState.IsValid)
            {
                var dogToUpdate = dogRepository.GetDogs().Find(x => x.Id == model.Id);
                TryUpdateModelAsync(dogToUpdate);

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Dog());
        }

        [HttpPost]
        public IActionResult Create(Dog model)
        {
            if (ModelState.IsValid)
            {
                var maxId = dogRepository.GetDogs().Max(x => x.Id) + 1;
                model.Id = maxId;
                dogRepository.AddDogs(model);
                return RedirectToAction("List");
            }
            return View(model);
        }
        
    }
}
