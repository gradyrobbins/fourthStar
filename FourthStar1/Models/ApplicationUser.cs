using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FourthStar1.Models;
using Microsoft.AspNetCore.Identity;

namespace FourthStar1.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        //public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

       

        // Set up PK -> FK relationships to other objects
        // public virtual ICollection<Drill> Drills { get; set; }

        public  int? TeamId { get; set; }

        public  Team Team { get; set; }

}
}