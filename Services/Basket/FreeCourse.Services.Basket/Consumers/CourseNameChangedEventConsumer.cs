using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Services.Basket.Services;
using FreeCourse.Shared.Messages;
using FreeCourse.Shared.Services;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace FreeCourse.Services.Basket.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly RedisService _redisService;

        public CourseNameChangedEventConsumer(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            //Get user basket
            var existBasket = await _redisService.GetDb().StringGetAsync(context.Message.UserId);

            var basketDto = JsonSerializer.Deserialize<BasketDto>(existBasket);
            if (basketDto != null && basketDto.BasketItems != null)
            {
                //Update course name in user basket
                basketDto.BasketItems.ForEach(basketItem =>
                {
                    basketItem.CourseName = context.Message.CourseName;
                });
                await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            }
        }
    }
}
