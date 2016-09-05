using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;
using CookBook.Models;
using CookBook.SqlDataAccess;

namespace CookBook.Controllers
{
    public class RecipesController : BaseController
    {
        CookBookDb _db = new CookBookDb();

        // GET: Recipes
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Search(string q = "", int page = 0, int pageSize = 5)
        {
            q = q.ToLower() ?? q;

            var recipes = _db.Recipes
                .OrderBy(recipe => recipe.Name)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Where(recipe => string.IsNullOrEmpty(q) || recipe.Name.ToLower().Contains(q))
                .Select(Mapper.Map<RecipeViewModel>)
                .ToList();

            var recipePage = new RecipePageViewModel
            {
                PageCount = _db.Recipes.Count() / pageSize,
                Recipes = recipes
            };

            return Json(recipePage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int recipeId)
        {
            var model = _db.Recipes.Find(recipeId);
            if (model != null)
            {
                return View(Mapper.Map<RecipeViewModel>(model));
            }

            return new HttpNotFoundResult();
        }

        // POST: Edit
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