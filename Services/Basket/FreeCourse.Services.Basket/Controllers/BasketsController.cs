using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Services.Basket.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IBasketService basketService;
        private readonly ISharedIdentityService sharedIdentityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            this.basketService = basketService;
            this.sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await basketService.GetBasket(sharedIdentityService.GetUserId);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDTO basketDTO)
        {
            var response = await basketService.SaveOrUpdate(basketDTO);
            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return CreateActionResultInstance(await basketService.Delete(sharedIdentityService.GetUserId));
        }
    }
}
