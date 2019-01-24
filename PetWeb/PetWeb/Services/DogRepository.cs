using PetWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetWeb.Services
{
    //SINGLETON pattern
    public class DogRepository
    {

        static List<Dog> dogs = new List<Dog>();

        private static DogRepository instance;

        public static DogRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DogRepository();
                    dogs = InitializeList();
                }
                return instance;
            }
        }

        
        public void AddDogs(Dog dogToAdd)
        {

            dogs.Add(dogToAdd);

        }

        public List<Dog> GetDogs()
        {
            return dogs;
        }

        private int GetIndex(int id)
        {
            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs[i].Id == id)
                    return i;
            }

            return -1;
        }

        public Dog GetDogById(int id)
        {
            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs[i].Id == id)
                    return dogs[i];
            }               

            return null;
        }

        public void RemoveDogById(int id)//used also for Gina, when delete without asking both on button Delete in List or in browser dogs/delete/id, pair with Delete2 method
        {
            int index = GetIndex(id);
            if (index >= 0)
            {
                dogs.RemoveAt(index);
            }
        }

        public void RemoveDogToDelete(Dog model)
        {
            var dogToDelete = dogs.Find(x => x.Id == model.Id);

            dogs.Remove(dogToDelete);

        }

        //See Delete3 method commentented in DogController
        //public void Delete1(int id)
        //{
        //    int index = GetIndex(id);
        //    if (index >= 0)
        //        Dogs.RemoveAt(index);
        //}

        private static List<Dog> InitializeList()
        {
            List<Dog> dogs = new List<Dog>
            {
                new Dog()
                {
                    Id = 1,
                    NickName = "Doggy1",
                    Gender = PetGender.Female,
                    Color = FurColor.White,
                    DayOfBirth=6,
                    MonthOfBirth=4,
                    YearOfBirth=2012,
                    Owner=new Owner {Name="John",Email="john@gmail.com"}

                },
                new Dog()
                {
                    Id = 2,
                    NickName = "Doggy2",
                    Gender = PetGender.Female,
                    Color = FurColor.Yellow,
                    DayOfBirth=16,
                    MonthOfBirth=2,
                    YearOfBirth=2016,
                    Owner=new Owner {Name="Anna",Email="anna@yahoo.com"}

                },
                new Dog()
                {
                    Id = 3,
                    NickName = "Doggy3",
                    Gender = PetGender.Male,
                    Color = FurColor.Black,
                    DayOfBirth=15,
                    MonthOfBirth=2,
                    YearOfBirth=2016,
                    Owner=new Owner {Name="Ben",Email="ben@yahoo.com"}

                },
                new Dog()
                {
                    Id = 4,
                    NickName = "Doggy4",
                    Gender = PetGender.Male,
                    Color = FurColor.White,
                    DayOfBirth=15,
                    MonthOfBirth=2,
                    YearOfBirth=2016,
                    Owner=new Owner {Name="Mary",Email="mary@yahoo.com"}

                },
                new Dog()
                {
                    Id = 5,
                    NickName = "Doggy5",
                    Gender = PetGender.Female,
                    Color = FurColor.White,
                    DayOfBirth=1,
                    MonthOfBirth=8,
                    YearOfBirth=2015,
                    Owner=new Owner {Name="George",Email="george@yahoo.com"}
                }
            };

            return dogs;
        }



    }
}
