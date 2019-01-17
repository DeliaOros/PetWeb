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
        [MaxLength(8)]
        private DateTime dateOfBirth;

        //private Owner owner;

        public FurColor Color { get; set; }

        public PetGender Gender { get; set; }

        [MinLength(1)]
        public int Id { get; set; }

        [MinLength(1), MaxLength(20)]
        public string NickName { get; set; }

        public Owner Owner { get; set; }

        [Range(1, 31)]
        public int DayOfBirth { get; set; }

        [Range(1, 12)]
        public int MonthOfBirth { get; set; }

        [MinLength(4)]
        public int YearOfBirth { get; set; }

        public DateTime DateOfBirth
        {
            get
            {
                DateTime dayOfBirth = new DateTime(this.YearOfBirth, this.MonthOfBirth, this.DayOfBirth);
                return dayOfBirth;
            }
            set
            {
                int day = 0;
                int month = 0;
                int year = 0;
                var dateOfBirth = new DateTime(year, month, day);
                this.dateOfBirth = dateOfBirth;
            }
        }


    }
}
