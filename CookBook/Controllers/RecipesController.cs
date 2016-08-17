using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CookBook.SqlDataAccess;
using System.Data.Entity;

namespace CookBook.Controllers
{
    public class RecipesController : Controller
    {
        CookBookDb _db = new CookBookDb();

        // GET: Recipes
        public ActionResult Index()
        {
            var recipes = _db.Recipes.OrderBy(recipe => recipe.Name).ToList();
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
        public ActionResult Create([Bind]Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _db.Recipes.Add(recipe);
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
                return View(model);
            }

            return new HttpNotFoundResult();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Edit([Bind]Recipe recipe)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(recipe).State = EntityState.Modified;
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