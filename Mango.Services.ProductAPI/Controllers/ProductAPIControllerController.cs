﻿using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Models;

using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIControllerController : ControllerBase
    {

        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIControllerController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task <object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetId(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _productRepository.Delete(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }
    }
}
