using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.SqlDataAccess
{
    public class RecipeReview
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int RecipeId { get; set; }
    }
}
