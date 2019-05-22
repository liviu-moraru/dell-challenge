using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Delete(string id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;
            _context.Remove(product);
            _context.SaveChanges();
            return MapToDto(product);

        }

        public ProductDto GetProduct(string id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;
            return MapToDto(product);
        }

        public ProductDto Update(string id, NewProductDto value)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;
            product.Name = value.Name;
            product.Category = value.Category;
            _context.SaveChanges();
            return MapToDto(product);
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
