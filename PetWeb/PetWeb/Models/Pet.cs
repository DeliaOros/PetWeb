using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        
        public string NickName { get; set; }
        
        public Owner Owner { get; set; }        
        
        public int DayOfBirth { get; set; }       
        
        public int MonthOfBirth { get; set; }       
       
        public int YearOfBirth { get; set; }             

        [DisplayName("Date of birth")]
        public DateTime DateOfBirth
        {
            get
            {
                if (YearOfBirth == 0 || MonthOfBirth == 0 || DayOfBirth == 0)
                    return new DateTime(1, 1, 1);

                return new DateTime(YearOfBirth, MonthOfBirth, DayOfBirth);
            }
        }

        [DisplayName("Date of birth")]
        public string DateOfBirthDisplay
        {
            get
            {
                return DateOfBirth.ToShortDateString();

            }
        }

    }
}
