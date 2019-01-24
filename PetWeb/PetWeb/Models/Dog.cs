using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetWeb.Models
{
    
    public class Dog :Pet
    {
        public override bool Equals(object obj)
        {
            return (this.Id == ((Dog)obj).Id);
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
