using Mango.Web.Models;

using Mango.Web.Service.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Web.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) { _productService = productService; }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var reponse = await _productService.GEtAllProductAsync<ResponseDto>(accessToken);

            if (reponse != null && reponse.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(reponse.Result));
            }
            return View(list);
        }
        public async Task<IActionResult> ProductCreate()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var reponse = await _productService.CreateProductAsync<ResponseDto>(model, accessToken);
            if (ModelState.IsValid)
            {
                if (reponse != null && reponse.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }


            }
            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var reponse = await _productService.GEtProductByIdAsync<ResponseDto>(productId, accessToken);
            if (ModelState.IsValid)
            {
                if (reponse != null && reponse.IsSuccess)
                {
                    ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(reponse.Result));

                    return View(model);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var reponse = await _productService.UpdateProductAsync<ResponseDto>(model, accessToken);
            if (ModelState.IsValid)
            {
                if (reponse != null && reponse.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var reponse = await _productService.GEtProductByIdAsync<ResponseDto>(productId, accessToken);
            if (ModelState.IsValid)
            {
                if (reponse != null && reponse.IsSuccess)
                {
                    ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(reponse.Result));

                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var reponse = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId, accessToken);
            if (ModelState.IsValid)
            {
                if ( reponse.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }
    }
}
