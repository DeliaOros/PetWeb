using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetWeb.Models
{
    public class Owner
    {
       
      
        
        public string Name { get; set; }    
              
        public string Email { get; set; }


        [DisplayName("Owner")]
        public string GetNameAndEmail
        {
            get
            {
                return $@"Name: {Name}, Email: {Email}";

            }
        }


        public override string ToString()
        {
            return $"{this.Name}, {this.Email}";
        }
    }

   
}
