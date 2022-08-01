using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Shared.Dtos;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService redisService;

        public BasketService(RedisService redisService)
        {
            this.redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await redisService.GetDb().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found!", 404);
        }

        public async Task<Response<BasketDTO>> GetBasket(string userId)
        {
            var existBasket = await redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDTO>.Fail("Basket not found!", 404);
            }
            return Response<BasketDTO>.Success(JsonSerializer.Deserialize<BasketDTO>(existBasket), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDTO basketDTO)
        {
            var status = await redisService.GetDb().StringSetAsync(basketDTO.UserId, JsonSerializer.Serialize(basketDTO));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not save or update!", 500);
        }
    }
}
