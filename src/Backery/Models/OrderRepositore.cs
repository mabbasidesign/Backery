using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backery.Models
{
    public class OrthereRepositore : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrthereRepositore(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
             _appDbContext.Orders.Add(order);

            var Item = _shoppingCart.ShoppingCartItems;

            foreach (var ShoppingCartItem in Item)
            {
                var ortherDetail = new OrderDetail()
                {
                    BreadId = ShoppingCartItem.Bread.BreadId,
                    Amount = ShoppingCartItem.Amount,
                    OrderId = ShoppingCartItem.ShoppingCartItemId,
                    Price = ShoppingCartItem.Bread.Price
                };
                _appDbContext.OrderDetails.Add(ortherDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
