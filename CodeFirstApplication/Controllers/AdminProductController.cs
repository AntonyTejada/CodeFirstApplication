using CodeFirstApplication.Data;
using CodeFirstApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstApplication.Controllers
{
    public class AdminProductController : Controller
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();

        public IActionResult Products()
        {
            var products = _dbContext.Products;
            List<ProductModel> productsList = products.ToList();
            return View(productsList);
        }

        public IActionResult UpsertProduct(int? id)
        {
            var products = _dbContext.Products;
            IEnumerable<SelectListItem> productsList = GetCategories(); //(IEnumerable<SelectListItem>)products.ToList();

            NewProduct newProduct = new NewProduct();
            newProduct.CategoryList = productsList;

            if (id != null)
            {
                List<ProductModel> productList = _dbContext.Products.ToList();
                ProductModel product = productList.Where(x => x.IdProduct == id).FirstOrDefault();
                newProduct.Product = product;
                return View(newProduct);
            }
            else {
                newProduct.Product = new ProductModel();
            }
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult UpsertProduct(NewProduct productFormData)
        {
            //var products = _dbContext.Products;
            //IEnumerable<SelectListItem> productsList = (IEnumerable<SelectListItem>)products.ToList();

            if (ModelState.IsValid)
            {
                if (productFormData.Product.IdProduct != 0)
                {
                    ProductModel existingProduct = _dbContext.Products.FirstOrDefault(p => p.IdProduct == productFormData.Product.IdProduct);
                    existingProduct.NameProduct = productFormData.Product.NameProduct;
                    existingProduct.DescriptionProduct = productFormData.Product.DescriptionProduct;
                    existingProduct.ImageUrlProduct = productFormData.Product.ImageUrlProduct;
                    existingProduct.MemoryProduct = productFormData.Product.MemoryProduct;
                    existingProduct.StorageCapacityProduct = productFormData.Product.StorageCapacityProduct;
                    existingProduct.ResolutionImageProduct = productFormData.Product.ResolutionImageProduct;
                    existingProduct.PriceProduct = productFormData.Product.PriceProduct;
                    existingProduct.CategoryId = productFormData.Product.CategoryId;

                    _dbContext.Update(existingProduct);
                    _dbContext.SaveChanges();
                }
                else
                {
                    ProductModel newProduct = new ProductModel();
                    newProduct = productFormData.Product;

                    _dbContext.Update(newProduct);
                    _dbContext.SaveChanges();
                }

                return RedirectToAction(nameof(Products));
            }
            else {
                productFormData.CategoryList = GetCategories(); //productsList;
                if (productFormData.Product.IdProduct != 0) {
                    productFormData.Product = _dbContext.Products.FirstOrDefault(p => p.IdProduct == productFormData.Product.IdProduct);
                }
            }

            return View(productFormData);
        }


        public IActionResult DeleteProduct(int? id)
        {
            var products = _dbContext.Products;
            IEnumerable<SelectListItem> productsList = GetCategories(); //(IEnumerable<SelectListItem>)products.ToList();

            NewProduct newProduct = new NewProduct();
            newProduct.CategoryList = productsList;

            if (id != null)
            {
                List<ProductModel> productList = _dbContext.Products.ToList();
                ProductModel product = productList.Where(x => x.IdProduct == id).FirstOrDefault();
                newProduct.Product = product;
                return View(newProduct);
            }
            else {
                return RedirectToAction(nameof(Products));
            }
        }


        [HttpPost]
        public IActionResult DeleteProduct(NewProduct productFormData) 
        {
            if (ModelState.IsValid)
            {
                if (productFormData.Product.IdProduct != 0)
                {
                    _dbContext.Remove(_dbContext.Products.Single(p => p.IdProduct == productFormData.Product.IdProduct));
                    _dbContext.SaveChanges();
                    return RedirectToAction(nameof(Products));
                }
            }
            return RedirectToAction(nameof(Products));
        }


        public List<SelectListItem> GetCategories()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() {Value = "1" , Text = "Smartphone" },
                new SelectListItem() {Value = "2" , Text = "Consoles" },
                new SelectListItem() {Value = "3" , Text = "Laptops" }
            };
        }
    }
}
