using System.Data.Entity;

namespace CookBook.SqlDataAccess
{
    public class CookBookDb : DbContext
    {
        static CookBookDb()
        {
            Database.SetInitializer(new CookBookDbInitializer());
        }

        public CookBookDb() : base("name=DefaultConnection")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeReview> Reviews { get; set; }
    }
}
