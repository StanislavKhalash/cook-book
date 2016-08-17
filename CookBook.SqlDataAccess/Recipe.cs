using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.SqlDataAccess
{
    public class Recipe
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rate { get; set; }

        public virtual List<RecipeReview> Reviews { get; set; }
    }
}
