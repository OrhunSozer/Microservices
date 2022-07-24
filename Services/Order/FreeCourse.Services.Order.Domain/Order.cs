using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        //EF Core Future;
        //-Owned Types
        //-Shadow Property
        //-Backing Fields

        //Shadow property: There is this field in EF but there is not here
        //public int Id { get; set; }
        public DateTime CreatedDate { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }

        //Backing fields..
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order(string buyerId, Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
        }

        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                _orderItems.Add(new OrderItem(productId, productName, pictureUrl, price));
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
