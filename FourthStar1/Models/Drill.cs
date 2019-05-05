using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourthStar1.Models
{
    public class Drill
    {
        
    // You must define a type for representing an drill. 

            public int Id { get; set; }

            [Display(Name = "Drill Name")]
            public string DrillName { get; set; }

            [Display(Name = "Description")]
            public string DrillDescription { get; set; }

            [Display(Name = "Players Required")]
            public int PlayersRequired { get; set; }

            [ForeignKey("ApplicationUser")]
            public string UserId { get; set; }

            [ForeignKey("Category Id")]
            public int CategoryId { get; set; }

            [Display(Name = "Date Created")]
            public DateTime DateCreated { get; set; }

    }

}








