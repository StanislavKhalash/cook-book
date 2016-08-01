using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CookBook.SqlDataAccess;

namespace CookBook.Controllers
{
    public class RecipesController : Controller
    {
        CookBookDb _db = new CookBookDb();

        // GET: Recipes
        public ActionResult Index()
        {
            var recipes = _db.Recipes.ToList();

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}