using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetWeb.Models;
using PetWeb.Services;

namespace PetWeb.Controllers
//trebuie rezolvat la EDIT fara Id sa ma duca la List, nu are rost o pagina goala
{
    public class DogsController : Controller
    {
        private DogRepository dogRepository; //field

        public IActionResult Index()//l-am pus eu sa fie dar nu tb neaparat
        {
            return View();
        }

        public DogsController() //ctor pt DogsController class
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

            //Dog dogToEdit = dogRepository.GetDogs().Find(x => x.Id == id); pt cele doua linii de cod de mai sus

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
                int maxId;
                if (dogRepository.GetDogs().Count == 0)
                {
                    maxId = 1;
                }
                else
                {
                    maxId = dogRepository.GetDogs().Max(x => x.Id) + 1;

                    model.Id = maxId;
                }                   

                dogRepository.AddDogs(model);

                return RedirectToAction("List");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dogToDelete = dogRepository.GetDogById(id);

            return View(dogToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Dog dogToDelete)
        {
            dogRepository.RemoveDogToDelete(dogToDelete);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var dogToDetail = dogRepository.GetDogs().Find(x => x.Id == id);

            return View(dogToDetail);
        }

        [HttpGet]
        public IActionResult ListOptions(FurColor? color, PetGender? gender)
        {
            var dogs = dogRepository.GetDogs();
            if (color.HasValue)
            {
                dogs = dogs.Where(x => x.Color == color.Value).ToList();

                return View(dogs);
            }
            if (gender.HasValue)
            {
                dogs = dogs.Where(x => x.Gender == gender.Value).ToList();

                return View(dogs);
            }

            return View(dogs);
        }


    }
}

