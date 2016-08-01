using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.SqlDataAccess
{
    public class CookBookDb : DbContext
    {
        public CookBookDb() : base("name=DefaultConnection")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeReview> Reviews { get; set; }
    }
}
