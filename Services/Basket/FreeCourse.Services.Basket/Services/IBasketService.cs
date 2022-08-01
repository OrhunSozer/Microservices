using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Shared.Dtos;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDTO>> GetBasket(string userId);

        Task<Response<bool>> SaveOrUpdate(BasketDTO basketDTO);

        Task<Response<bool>> Delete(string userId);
    }
}
