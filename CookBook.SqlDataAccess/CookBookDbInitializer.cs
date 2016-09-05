using System;
using System.Data.Entity;

namespace CookBook.SqlDataAccess
{
    internal sealed class CookBookDbInitializer : DropCreateDatabaseAlways<CookBookDb>
    {
        protected override void Seed(CookBookDb context)
        {
            for(int i = 0; i < 10; ++i)
            {
                context.Recipes.Add(new Recipe() { Name = "Ceasar Salad", Description = "It's the best salad!", Rate = 3 });
            }

            for (int i = 0; i < 10; ++i)
            {
                context.Recipes.Add(new Recipe() { Name = "Guakamole", Description = "It's the best sauce!", Rate = 4 });
            }

            base.Seed(context);
        }
    }
}
