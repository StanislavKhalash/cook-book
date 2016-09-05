using System.Collections.Generic;

namespace CookBook.Models
{
    public class RecipePageViewModel
    {
        public int PageCount { get; set; }

        public List<RecipeViewModel> Recipes { get; set; }
    }
}