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

        private List<Dog> PopulateDoglist()
        {
            List<Dog> dogs = new List<Dog>();
            dogs.Add(new Dog()
            {
                Color = FurColor.Black,
                Gender = PetGender.Male
            });
            dogs.Add(new Dog()
            {
                Color = FurColor.White,
                Gender = PetGender.Male
            });
            dogs.Add(new Dog()
            {
                Color = FurColor.Yellow,
                Gender = PetGender.Female
            });
            dogs.Add(new Dog()
            {
                Color = FurColor.Yellow,
                Gender = PetGender.Male
            });
            return dogs;

        }
    }
}