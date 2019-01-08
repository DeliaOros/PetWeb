using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetWeb.Models;

namespace PetWeb.Controllers
{
    public class DogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult List(FurColor? color, PetGender? gender)
        {
            var dogs = PopulateDoglist();
            if (color.HasValue && gender.HasValue)
            {
                dogs = dogs.Where(x => x.Color == color.Value).Where(x => x.Gender == gender.Value).ToList();
                return View(dogs);
            }
            return View(dogs);
        }

        private List<Dog> PopulateDoglist()
        {
            List<Dog> dogs = new List<Dog>();
            dogs.Add(new Dog()
            {
                Color = FurColor.black,
                Gender = PetGender.male
            });
            dogs.Add(new Dog()
            {
                Color = FurColor.white,
                Gender = PetGender.male
            });
            dogs.Add(new Dog()
            {
                Color = FurColor.yellow,
                Gender = PetGender.female
            });
            dogs.Add(new Dog()
            {
                Color = FurColor.yellow,
                Gender = PetGender.male
            });
            return dogs;

        }
    }
}