using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using StudentExercises.Models;

namespace FourthStar1.Models
{
    public class Team
    {
        // You must define a type for representing a team in code.
        // The team's name 
        // The collection of users on the team.
        
            public int Id { get; set; }

            [Display(Name = "Team Details")]
            public string Name { get; set; }
            public List<ApplicationUser> rosterOfPlayers { get; set; } = new List<ApplicationUser>();

    }

  





}

