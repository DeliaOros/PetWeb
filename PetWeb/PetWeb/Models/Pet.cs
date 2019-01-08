using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetWeb.Models
{
    public enum FurColor
    {
        black,
        white,
        yellow
    }
    public enum PetGender
    {
        male,
        female
    }

    public class Pet
    {
        public FurColor Color { get; set; }
        public PetGender Gender { get; set; }
    }
}
