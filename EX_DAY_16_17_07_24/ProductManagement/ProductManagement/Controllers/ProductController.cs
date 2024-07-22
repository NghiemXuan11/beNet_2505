using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductManagement.Data.DTO;
using ProductManagement.Data.Interfaces;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(product);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public ActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            var products = _productRepository.SearchProductsByName(name);
            return PartialView("_ProductList", products);
        }
    }
}