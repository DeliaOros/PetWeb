using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetWeb.Models;

namespace PetWeb.Controllers
{
    public class CatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult List(FurColor? color, PetGender? gender)
        {
            var cats = Populatelist();
            if (color.HasValue | gender.HasValue)
            {
                cats = cats.Where(x => x.Color == color.Value).Where(x => x.Gender == gender.Value).ToList();

                return View(cats);

            }
            return View(cats);
        }

        private List<Cat> Populatelist()
        {
            List<Cat> cats = new List<Cat>();
            cats.Add(new Cat()
            {
                Color = FurColor.Black,
                Gender = PetGender.Female
            });
            cats.Add(new Cat()
            {
                Color = FurColor.Black,
                Gender = PetGender.Female
            });
            cats.Add(new Cat()
            {
                Color = FurColor.White,
                Gender = PetGender.Male
            });
            cats.Add(new Cat()
            {
                Color = FurColor.Yellow,
                Gender = PetGender.Male
            });
            return cats;
        }
    }
}