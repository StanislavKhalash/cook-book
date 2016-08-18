using System;
using System.ComponentModel.DataAnnotations;

namespace CookBook.ViewModels
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The recipe name is required")]
        [StringLength(160, ErrorMessage = "The recipe name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The recipe description is required")]
        [StringLength(500, ErrorMessage = "The recipe description is too long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You should rate the recipe")]
        [Range(1, 5, ErrorMessage = "The rate should be between 1 and 5")]
        public int Rate { get; set; }
    }
}