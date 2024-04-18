﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentVilla.MVC.Models.Cart;
using RentVilla.MVC.Models.Product;
using RentVilla.MVC.Services.HttpClientService;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RentVilla.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientService _clientService;

        public ProductsController(IConfiguration configuration, IHttpClientService clientService)
        {
            _configuration = configuration;
            _clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseMessage = await _clientService.GetHttpResponse("products/get");
            string contentResponseApi = await responseMessage.Content.ReadAsStringAsync();
            List<ProductVM> response = JsonSerializer.Deserialize<List<ProductVM>>(contentResponseApi);

            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(string id)
        {
            HttpResponseMessage responseMessage = await _clientService.GetHttpResponse($"products/getbyid?ProductId={id}");
            string contentResponseApi = await responseMessage.Content.ReadAsStringAsync();
            ProductVM response = JsonSerializer.Deserialize<ProductVM>(contentResponseApi);
            return View(response);
        }
    }
}
