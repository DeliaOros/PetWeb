using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetWeb.Models
{
    public class Owner
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }


        //public Owner(string Name, string emailAddress)
        //{
        //    this.Name = Name;
        //    this.Email = emailAddress;
        //}

        public override string ToString()
        {
            return $"{this.Name}, {this.Email}";
        }
    }
}
