using LanchesC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LanchesC.Models
{
    public class Cart
    {
        private readonly AppDbContext _context;

        public Cart(AppDbContext context)
        {
            _context = context;
        }

        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            //define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto 
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CartId", cartId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new Cart(context)
            {
                CartId = cartId
            };
        }

        public void AddItemToCart(Snack snack)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                     s => s.Snack.SnackId == snack.SnackId &&
                     s.CartId == CartId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = CartId,
                    Snack = snack,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(Snack snack)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                   s => s.Snack.SnackId == snack.SnackId &&
                   s.CartId == CartId);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    _context.CartItems.Remove(cartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ??
                   (CartItems =
                       _context.CartItems.Where(c => c.CartId == CartId)
                           .Include(s => s.Snack)
                           .ToList());
        }

        public void CleanCart()
        {
            var cartItems = _context.CartItems
                                 .Where(carrinho => carrinho.CartId == CartId);

            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            var total = _context.CartItems.Where(c => c.CartId == CartId)
                .Select(c => c.Snack.Price * c.Quantity).Sum();
            return total;
        }

    }
}
