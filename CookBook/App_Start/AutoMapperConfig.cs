using AutoMapper;
using CookBook.ViewModels;
using CookBook.SqlDataAccess;

namespace CookBook.App_Start
{
    internal static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Recipe, RecipeViewModel>());
        }
    }
}
