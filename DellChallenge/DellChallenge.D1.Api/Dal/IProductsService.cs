using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto Add(NewProductDto newProduct);
        ProductDto Delete(string id);
        ProductDto GetProduct(string id);
        ProductDto Update(string id, NewProductDto value);
    }
}
