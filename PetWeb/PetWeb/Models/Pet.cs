using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetWeb.Models
{
    public enum FurColor
    {
        Black,
        White,
        Yellow
    }
    public enum PetGender
    {
        Male,
        Female
    }

    public class Pet
    {      

        public FurColor Color { get; set; }

        public PetGender Gender { get; set; }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string NickName { get; set; }

        public Owner Owner { get; set; }

        [Required]
        [Range(1, 31)]
        public int DayOfBirth { get; set; }

        [Range(1, 12)]
        public int MonthOfBirth { get; set; }


        public int YearOfBirth { get; set; }

        private DateTime dateOfBirth;


        //primesc eroare:
        //An unhandled exception occurred while processing the request.
        //ArgumentOutOfRangeException: Year, Month, and Day parameters describe an un-representable DateTime.
        //System.DateTime.DateToTicks(int year, int month, int day)
        //pt rd.57


        //public DateTime DateOfBirth
        //{
        //    get
        //    {           

        //        return new DateTime(YearOfBirth, MonthOfBirth, DayOfBirth);               
        //    }
        //    set
        //    {
        //        this.dateOfBirth = new DateTime(YearOfBirth, MonthOfBirth, DayOfBirth);
                
        //    }
        //}


        public DateTime DateOfBirth
        {
            get
            {
                DateTime dayOfBirth = new DateTime(1, 1, 1);
                try
                {
                    dayOfBirth = new DateTime(this.YearOfBirth, this.MonthOfBirth, this.DayOfBirth);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return dayOfBirth;
            }
        }
    }
}
