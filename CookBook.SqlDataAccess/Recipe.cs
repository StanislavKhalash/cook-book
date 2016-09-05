using System;
using System.Collections.Generic;

namespace CookBook.SqlDataAccess
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rate { get; set; }

        public Image Picture { get; set; }

        public virtual List<RecipeReview> Reviews { get; set; }
    }
}
