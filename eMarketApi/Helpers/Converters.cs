using eMarket.DTO.Module;
using eMarketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMarketApi
{
    public static class Converters
    {
        public static ProductDTO ToProductDTO(this Product product)
        {
            if (product == null) return null;

            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = Converters.ToCategoryDTO(product.Category),
                Price = product.Price,
                Weight = product.Weight
            };
        }

        public static CategoryDTO ToCategoryDTO(this Category category)
        {
            if (category == null)
                return null;

            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Parent = Converters.ToCategoryDTO(category.Parent)
            };
        }


        public static Product ToProduct(this ProductDTO product)
        {
            if (product == null) return null;

            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.Category.Id,
                Price = product.Price,
                Weight = product.Weight
            };
        }

        public static Category ToCategory(this CategoryDTO category)
        {
            if (category == null)
                return null;

            return new Category()
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.Parent?.Id
            };
        }
    }
}