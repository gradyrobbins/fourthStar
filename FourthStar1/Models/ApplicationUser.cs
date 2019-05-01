using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FourthStar1.Models;
using Microsoft.AspNetCore.Identity;

namespace StudentExercises.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        // Set up PK -> FK relationships to other objects
        public virtual ICollection<Drill> Drills { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

    }
}