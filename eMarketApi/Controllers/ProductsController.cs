using eMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eMarket.DTO.Module;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace eMarketApi.Controllers
{
    public class ProductsController : ApiController
    {
        eMarketDbContext Context = new eMarketDbContext();

        // GET: api/products
        public IEnumerable<ProductDTO> GetProducts()
        {
            return Context.Products.ToList()
                .Select(product => product.ToProductDTO());
        }

        //GET: api/products/1
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await Context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductDTO());
        }


        public async Task<IHttpActionResult> PostProduct(ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product productEntity = product.ToProduct();

            Context.Products.Add(productEntity);
            await Context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productEntity.Id }, productEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Context.Dispose();

            base.Dispose(disposing);
        }

        
    }
}
