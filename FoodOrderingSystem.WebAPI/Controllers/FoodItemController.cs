using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController(IFoodItemService foodItemService) : ControllerBase
    {
        private readonly IFoodItemService _foodItemService = foodItemService;

        [HttpPost]
        [Route("add-fooditem")]
        public async Task<IActionResult> AddFoodItemAsync([FromBody] FoodItemDto foodItemDto, CancellationToken cancellationToken)
        {
            try
            {
                FoodItemDto validFoodItem = foodItemDto ?? throw new ArgumentNullException(nameof(foodItemDto));

                Application.Shared.IResult result = await _foodItemService.AddAsync(validFoodItem, cancellationToken);

                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }
            catch (Exception)
            {
                return BadRequest(Result<FoodItemDto>.Failure(ErrorType.BadRequest));
            }
        }
    }
}
