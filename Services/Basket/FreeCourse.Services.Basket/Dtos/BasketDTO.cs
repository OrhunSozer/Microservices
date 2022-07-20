using System.Collections.Generic;
using System.Linq;

namespace FreeCourse.Services.Basket.Dtos
{
    public class BasketDTO
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItemDTO> Items { get; set; }
        public decimal TotalPrice
        {
            get => Items.Sum(s => s.Price * s.Quantity); 
        }

    }
}
