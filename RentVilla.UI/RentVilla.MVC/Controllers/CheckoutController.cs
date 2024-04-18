﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using RentVilla.MVC.Models.Cart;
using RentVilla.MVC.Services.HttpClientService;
using System.Text.Json;

namespace RentVilla.MVC.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientService _clientService;
        public CheckoutController(INotyfService notyf, IConfiguration configuration, IHttpClientService clientService)
        {
            _notyf = notyf;
            _configuration = configuration;
            _clientService = clientService;
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _clientService.GetHttpResponse("CartItems");
            var contentResponse = await response.Content.ReadAsStringAsync();
            List<GetCartItemVM> cartItems = JsonSerializer.Deserialize<List<GetCartItemVM>>(contentResponse);
            var reservationCart = new ReservationCartVM();
            reservationCart.CartItems = cartItems;
            HttpContext.Response.Cookies.Append("RentVilla.Cookie_SC", cartItems.Count().ToString(), new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
            return View(reservationCart);

        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(AddCartItemVM model, int shortestRent)
        {
            if (!User.Identity.IsAuthenticated)
            {
                _notyf.Error("Please login to continue!");
                string returnUrl = $"/Products/GetDetails/{model.ProductId}";

                return RedirectToAction("Login", "Account", new { returnUrl = returnUrl });

            }
            if (HttpContext.Request.Cookies["RentVilla.Cookie_SC"] != null)
            {
                int cartCount = Convert.ToInt32(HttpContext.Request.Cookies["RentVilla.Cookie_SC"]);
                if (cartCount >= 1)
                {
                    _notyf.Error("You can add only 1 item to your cart.");
                    return RedirectToAction("GetDetails", "Products", new { id = model.ProductId });
                }
            }
            var rentPeriod = model.EndDate - model.StartDate;
            int totalDays = Convert.ToInt32(rentPeriod.TotalDays);
            if (totalDays < shortestRent)
            {
                _notyf.Error("Please select a valid date range!");
                return RedirectToAction("GetDetails", "Products", new {id = model.ProductId});
            }

            double adultCost = Convert.ToDouble(totalDays * model.AdultNumber * model.ProductPrice);
            double childCost = Convert.ToDouble(totalDays * model.ChildrenNumber * model.ProductPrice) * 0.5;
            model.TotalCost = Convert.ToDecimal(adultCost + childCost);

                var requestData = new
                {
                    cartItemDTO = new
                    {
                        productId = model.ProductId,
                        startDate = model.StartDate,
                        endDate = model.EndDate,
                        adultNumber = model.AdultNumber,
                        childrenNumber = model.ChildrenNumber,
                        note = model.Note,
                        price = model.ProductPrice,
                        totalCost = model.TotalCost
                    }
                };
                var httpResponse = await _clientService.PostHttpRequest("CartItems", requestData);
                if (httpResponse.IsSuccessStatusCode)
                {
                    _notyf.Success("Reservation request added to chart successfully. You can complete your payment.");
                    return RedirectToAction("Index");
                }
                else
                {
                    _notyf.Error("An error occurred while adding request. Please try again.");
                    return RedirectToAction("GetDetails", "Product", model);

                }
        }
        public async Task<IActionResult> UpdateItemInCart(string cartItemId, int _adultNumber, int _childrenNumber, int rentDays)
        {
            try
            {
                var httpResponse = await _clientService.GetHttpResponse($"CartItems/{cartItemId}");
                string contentResponse = await httpResponse.Content.ReadAsStringAsync();
                GetCartItemVM model = JsonSerializer.Deserialize<GetCartItemVM>(contentResponse);
                model.AdultNumber = _adultNumber;
                model.ChildrenNumber = _childrenNumber;
                double adultCost = Convert.ToDouble(rentDays * _adultNumber * model.Price);
                double childCost = Convert.ToDouble(rentDays * _childrenNumber * model.Price) * 0.5;
                model.TotalCost = Convert.ToDecimal(adultCost + childCost);
                var requestData = new
                {
                    cartItemDTO = new
                    {
                        cartItemId = model.CartItemId,
                        startDate = model.StartDate,
                        endDate = model.EndDate,
                        adultNumber = _adultNumber,
                        childrenNumber = _childrenNumber,
                        note = model.Note,
                        price = model.Price,
                        totalCost = model.TotalCost
                    }
                };
                HttpResponseMessage httpResponse2 = await _clientService.PutHttpRequest("CartItems", requestData);
                if (httpResponse.IsSuccessStatusCode)
                    {
                        _notyf.Success("Reservation choices edited successfully. You can complete your payment.");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _notyf.Error("An error occurred while editing request. Please try again.");
                        return RedirectToAction("GetDetails", "Product", model);

                    }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> DeleteFromCart(string cartItemId)
        {
            try
            {
                HttpResponseMessage httpResponse = await _clientService.DeleteHttpRequest($"CartItems/{cartItemId}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    _notyf.Success("Item removed from cart successfully.");
                    return RedirectToAction("Index");
                }
                else
                {
                    _notyf.Error("An error occurred while removing item from cart. Please try again.");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
