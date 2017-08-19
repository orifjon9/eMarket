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
            return Context.Products
                .Select(product => ConvertProductDTO(product));
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

            return Ok(ConvertProductDTO(product));
        }


        public async Task<IHttpActionResult> PostProduct(ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product productEntity = new Product();
            productEntity.Name = product.Name;
            productEntity.Description = product.Description;
            productEntity.Price = product.Price;
            productEntity.Weight = product.Weight;
            productEntity.CategoryId = product.Category.Id;

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

        private ProductDTO ConvertProductDTO(Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = ConvertCategoryDTO(product.Category),
                Price = product.Price,
                Weight = product.Weight
            };
        }

        private CategoryDTO ConvertCategoryDTO(Category category)
        {
            if (category == null)
                return null;

            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Parent = ConvertCategoryDTO(category.Parent)
            };
        }
    }
}
