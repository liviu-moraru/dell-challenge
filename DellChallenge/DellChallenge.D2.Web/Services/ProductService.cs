using System.Collections.Generic;
using DellChallenge.D2.Web.Models;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        public ProductModel Add(NewProductModel newProduct)
        {
            var apiClient = new RestClient("http://localhost:5000/api");
            var apiRequest = new RestRequest("products", Method.POST, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel GetProduct(string id)
        {
            var apiClient = new RestClient("http://localhost:5000/api");
            var apiRequest = new RestRequest($"products/{id}", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;

        }

        public void Update(ProductModel product)
        {
            var apiClient = new RestClient("http://localhost:5000/api");
            var apiRequest = new RestRequest($"products/{product.Id}", Method.PUT, DataFormat.Json);
            apiRequest.AddJsonBody(product);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);

        }

        public void Delete(string id)
        {
            var apiClient = new RestClient("http://localhost:5000/api");
            var apiRequest = new RestRequest($"products/{id}", Method.DELETE);
            apiClient.Execute(apiRequest);

        }

        public IEnumerable<ProductModel> GetAll()
        {
            
            var apiClient = new RestClient("http://localhost:5000/api");
            var apiRequest = new RestRequest("products", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);
            return apiResponse.Data;
        }
    }
}
