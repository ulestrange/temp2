using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7
{
    public class Person
    {

        
        public string ID { get; set; }

        [Required]
        [Display (Name= "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
