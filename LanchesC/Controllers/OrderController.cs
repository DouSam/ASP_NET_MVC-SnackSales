using LanchesC.Models;
using LanchesC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LanchesC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int totalItens = 0;
            decimal priceTotalOrder = 0.0m;

            List<CartItem> items = _cart.GetCartItems();
            _cart.CartItems = items;

            if(_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("","Your cart is empty.");
            }

            foreach (var item in items)
            {
                totalItens += item.Quantity;
                priceTotalOrder += (item.Snack.Price * item.Quantity);
            }

            order.OrderItensTotal = totalItens;
            order.OrderTotal = priceTotalOrder;

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);

                ViewBag.CheckoutCompleteMessage = "Order completed :)";
                ViewBag.TotalOrder = _cart.GetCartTotal();

                _cart.CleanCart();
                return View("~/Views/Order/CheckoutResume.cshtml", order);
            }

            return View();
        }
    }
}
