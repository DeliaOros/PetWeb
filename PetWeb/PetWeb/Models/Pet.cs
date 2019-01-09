using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
