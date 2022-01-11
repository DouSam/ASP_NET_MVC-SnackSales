using LanchesC.Models;
using LanchesC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesC.Components
{
    public class CartResume : ViewComponent
    {
        private readonly Cart _cart;

        public CartResume(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _cart.GetCartItems();

            _cart.CartItems = itens;

            var carVM = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };

            return View(carVM);
        }
    }
}
