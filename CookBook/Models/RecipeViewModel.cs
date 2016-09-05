using System;

namespace CookBook.Models
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rate { get; set; }
    }
}
