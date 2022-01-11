using LanchesC.Models;
using LanchesC.Models.ViewModels;
using LanchesC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LanchesC.Controllers
{
    public class CartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly Cart _cart;

        public CartController(ISnackRepository snackRepository, Cart cart)
        {
            _snackRepository = snackRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var itens = _cart.GetCartItems();
            _cart.CartItems = itens;

            var cartViewModel = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };

            return View(cartViewModel);
        }
        public IActionResult AddItemToCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks
                                    .FirstOrDefault(p => p.SnackId == snackId);

            if (selectedSnack != null)
            {
                _cart.AddItemToCart(selectedSnack);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks
                                    .FirstOrDefault(p => p.SnackId == snackId);

            if (selectedSnack != null)
            {
                _cart.RemoveFromCart(selectedSnack);
            }
            return RedirectToAction("Index");
        }
    }
}
