using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetWeb.Models;
using PetWeb.Services;

namespace PetWeb.Controllers
{
    public class CatsController : Controller
    {
        private CatRepository catRepository;

        public IActionResult Index()
        {

            return View();
        }

        public CatsController()
        {
            catRepository = CatRepository.Instance;
        }

        [HttpGet]
        public IActionResult List()
        {
            ViewData["Time"] = DateTime.Now;

            ViewBag.TotalCats = catRepository.GetCats().Count();

            return View(catRepository.GetCats());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var catToEdit = catRepository.GetCats().Find(x => x.Id == id);

            return View(catToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Cat model)
        {
            if (ModelState.IsValid)
            {
                var catToUpdate = catRepository.GetCats().Find(x => x.Id == model.Id);

                TryUpdateModelAsync(catToUpdate);
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cat());
        }

        [HttpPost]
        public IActionResult Create(Cat model)
        {
            if (ModelState.IsValid)
            {
                int maxId;
                if (catRepository.GetCats().Count == 0)
                {
                    maxId = 1;
                }
                else
                {
                    maxId = catRepository.GetCats().Max(x => x.Id) + 1;

                    model.Id = maxId;
                }

                catRepository.AddCats(model);

                return RedirectToAction("List");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var catToDelete = catRepository.GetCatById(id);

            return View(catToDelete);

        }

        [HttpPost]
        public IActionResult Delete(Cat catToDelete)
        {

            catRepository.RemoveCatToDelete(catToDelete);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var catToDetail = catRepository.GetCats().Find(x => x.Id == id);

            return View(catToDetail);

        }


       
        //public IActionResult ListOptions(FurColor? color, PetGender? gender)
        //{
        //    var cats=catRepository.GetCats();
        //    if (color.HasValue)
        //    {
        //        cats = cats.Where(x => x.Color == color.Value).ToList();

        //        return View(cats);
        //    }
        //    if (gender.HasValue)
        //    {
        //        cats = cats.Where(x => x.Gender == gender.Value).ToList();

        //        return View(cats);
        //    }

        //    return View(cats);
        //}


    }
}