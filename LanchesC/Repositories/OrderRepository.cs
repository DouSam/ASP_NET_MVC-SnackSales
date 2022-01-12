using LanchesC.Data;
using LanchesC.Models;
using LanchesC.Repositories.Interfaces;
using System;

namespace LanchesC.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly Cart _cart;

        public OrderRepository(AppDbContext appDbContext, Cart cart)
        {
            _appDbContext = appDbContext;
            _cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.DateOrder = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var cartItens = _cart.CartItems;

            foreach (var cartItem in cartItens)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = cartItem.Quantity,
                    SnackId = cartItem.Snack.SnackId,
                    OrderId = order.OrderId,
                    Price = cartItem.Snack.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
