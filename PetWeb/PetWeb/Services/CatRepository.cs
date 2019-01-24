using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetWeb.Models;

namespace PetWeb.Services
{
    public class CatRepository
    {
        static List<Cat> cats = new List<Cat>();

        private static CatRepository instance;

        public static CatRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CatRepository();

                    cats = InitializeCatList();
                }

                return instance;
            }
        }

        public void AddCats(Cat catToAdd)
        {
            cats.Add(catToAdd);

        }

        public List<Cat> GetCats()
        {

            return cats;

        }

        private int GetIndex(int id)
        {
            for (int i = 0; i < cats.Count; i++)
            {
                if (cats[i].Id == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public Cat GetCatById(int id)
        {
            for (int i = 0; i < cats.Count; i++)
            {
                if (cats[i].Id == id)
                {
                    return cats[i];
                }
            }
            return null;
        }

        public void RemoveCatById(int id)
        {
            int index = GetIndex(id);
            if (index >= 0)
            {
                cats.RemoveAt(index);
            }
        }

        public void RemoveCatToDelete(Cat model)
        {
            var catToDelete = cats.Find(x => x.Id == model.Id);

            cats.Remove(catToDelete);
        }


        private static List<Cat> InitializeCatList()
        {
            List<Cat> cats = new List<Cat>
            {
            new Cat()
            {
                Id = 1,
                NickName = "Kitty1",
                Gender = PetGender.Female,
                Color = FurColor.Black,
                DayOfBirth = 3,
                MonthOfBirth = 5,
                YearOfBirth = 2017,
                Owner = new Owner { Name = "owner1", Email = "owner1@mail.com" }
            },
            new Cat()
            {
                Id = 2,
                NickName = "Kitty2",
                Gender = PetGender.Male,
                Color = FurColor.Black,
                DayOfBirth = 23,
                MonthOfBirth = 5,
                YearOfBirth = 2015,
                Owner = new Owner{ Name = "owner2", Email = "owner2@gmail.com" }
            },
            new Cat()
            {
                Id = 3,
                NickName = "Kitty3",
                Gender = PetGender.Female,
                Color = FurColor.White,
                DayOfBirth = 30,
                MonthOfBirth = 5,
                YearOfBirth = 2014,
                Owner = new Owner{ Name = "owner3", Email = "owner3@gmail.com" }
            },
            new Cat()
            {
                Id = 4,
                NickName = "Kitty4",
                Gender = PetGender.Female,
                Color = FurColor.Yellow,
                DayOfBirth = 5,
                MonthOfBirth = 8,
                YearOfBirth = 2014,
                Owner = new Owner{ Name = "owner4", Email = "owner4@gmail.com" }
            },
            new Cat()
            {
                Id = 5,
                NickName = "Kitty5",
                Gender = PetGender.Male,
                Color = FurColor.Black,
                DayOfBirth = 1,
                MonthOfBirth = 1,
                YearOfBirth = 2017,
                Owner = new Owner{ Name = "owner5", Email = "owner5@mail.com" }
            }
            };

            return cats;

        }
    }
}


