using eMarket.DTO.Module;
using eMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace eMarket.Controllers
{
    public class ProductController : Controller
    {
        private HttpClient client = new HttpClient();
        // GET: Product
        public ActionResult Index()
        {
            //List<ProductDTO> products = new List<ProductDTO>();
            var products = Client.Current.GetDataAsync<List<ProductDTO>>("/api/products");

            //var getDataTask = client.GetAsync("http://localhost:52223/api/products")
            //    .ContinueWith(response =>
            //    {
            //        var result = response.Result;
            //        if (result.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            var readResult = result.Content.ReadAsAsync<List<ProductDTO>>();
            //            readResult.Wait();

            //            products = readResult.Result;
            //        }
            //    });
            //getDataTask.Wait();

            return View(products);
        }
    }
}