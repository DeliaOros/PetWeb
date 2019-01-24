using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetWeb.Models
{
    public class Cat : Pet
    {
        
        public override bool Equals(object obj)
        {
            return (this.Id==((Cat)obj).Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
