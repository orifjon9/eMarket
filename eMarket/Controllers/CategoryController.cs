using eMarket.DTO.Module;
using eMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMarket.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var categories = Client.Current.GetDataAsync<List<CategoryDTO>>("/api/categories");
            
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}