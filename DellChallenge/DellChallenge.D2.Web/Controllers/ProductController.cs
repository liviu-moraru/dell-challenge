using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(newProduct);
            }
            else
            {
                return View(viewName: nameof(Add));
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);

        }

        [HttpPost]
        public IActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
            }
            else
            {
                return View(viewName: nameof(Edit), model: product);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}