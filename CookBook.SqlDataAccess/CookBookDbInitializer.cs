using System;
using System.Data.Entity;

namespace CookBook.SqlDataAccess
{
    internal sealed class CookBookDbInitializer : DropCreateDatabaseAlways<CookBookDb>
    {
        protected override void Seed(CookBookDb context)
        {
            context.Recipes.Add(new Recipe() { Id = Guid.NewGuid(), Name = "Ceasar Salad", Description = "It's the best salad!", Rate = 3 });

            base.Seed(context);
        }
    }
}
