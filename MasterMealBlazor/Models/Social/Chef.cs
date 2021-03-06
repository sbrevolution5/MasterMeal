using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Models
{
    public class Chef : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string ScreenName { get; set; }
        public bool ShowFullName { get; set; }
        public int ImageId { get; set; }
        public virtual DBImage Image { get; set; }
        public List<Recipe> FavoriteRecipes { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
