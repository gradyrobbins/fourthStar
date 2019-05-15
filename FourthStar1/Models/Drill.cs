﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourthStar1.Models
{
    public class Drill
    {
        
    // You must define a type for representing a drill. 

            public int Id { get; set; }

            [Display(Name = "Drill Name")]
            [Required]
            public string DrillName { get; set; }

            [Display(Name = "Description")]
            [Required]
            public string DrillDescription { get; set; }

            [Display(Name = "Players Required")]
            [Required]
            public int PlayersRequired { get; set; }

            [ForeignKey("ApplicationUser")]
            [Required]
            public string UserId { get; set; }

            [ForeignKey("CategoryId")]
            [Required]
            public int CategoryId { get; set; }

            [Required]
            public Category Category { get; set; }

            [Display(Name = "Date Created")]
            //[DataType(DataType.Date)]
            //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime DateCreated { get; set; }

    }

}








