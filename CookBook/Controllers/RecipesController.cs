using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper;
using CookBook.SqlDataAccess;
using CookBook.ViewModels;

namespace CookBook.Controllers
{
    public class RecipesController : Controller
    {
        CookBookDb _db = new CookBookDb();

        // GET: Recipes
        public ActionResult Index()
        {
            var recipes = _db.Recipes
                .OrderBy(recipe => recipe.Name)
                .Select(Mapper.Map<RecipeViewModel>)
                .ToList();
            return View(recipes);
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(RecipeViewModel recipe)
        {
            if (ModelState.IsValid)
            {
                _db.Recipes.Add(Mapper.Map<Recipe>(recipe));
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        [HttpGet]
        public ActionResult Edit(Guid recipeId)
        {
            var model = _db.Recipes.Find(recipeId);
            if (model != null)
            {
                return View(Mapper.Map<RecipeViewModel>(model));
            }

            return new HttpNotFoundResult();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Edit(RecipeViewModel recipe)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(Mapper.Map<Recipe>(recipe)).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}