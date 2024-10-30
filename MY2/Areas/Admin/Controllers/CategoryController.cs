using MY2.Context;
using MY2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MY2.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        TravelContext context = new TravelContext();
        [Authorize]

        [HttpGet]
        public ActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult CategoryList(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

        public ActionResult DeleteCategory(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = context.Categories.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
           
            var values = context.Categories.Find(category.CategoryID);
            values.CategoryName = category.CategoryName;
          
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

    }
}