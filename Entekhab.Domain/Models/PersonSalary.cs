using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entekhab.Domain.Models
{
    public class PersonSalary : Base.Entity
    {
        public PersonSalary() : base()
        {
        }

         
        [System.ComponentModel.DataAnnotations.Required]
        public string FirstName { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public decimal BasicSalary { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public decimal Allowance { get; set; }
         

        [System.ComponentModel.DataAnnotations.Required]
        public decimal Transportation { get; set; }  

        
        [System.ComponentModel.DataAnnotations.Required]
        public DateTime DateMiladi { get; set; }

        public string DateShamsi { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public decimal OverTime { get; set; }
         
         
    }
}
