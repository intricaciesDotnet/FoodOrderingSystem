﻿using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingSystem.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    
    [HttpPost]
    [Route("add-user")]
    public async Task<IActionResult> AddUserAsync([FromBody] UserDto userDto, CancellationToken cancellationToken)
    {
		try
		{
            UserDto validDto = userDto ?? throw new ArgumentNullException(nameof(userDto));
            Application.Shared.IResult userResult = await _userService.AddAsync(validDto, cancellationToken);

            return userResult.IsSuccess ?
                Ok(userResult) :
                BadRequest(userResult);
		}
		catch (UserNotCreatedException ex)
		{
			var response = Result<UserDto>.Failure(ErrorType.UnableToCreate);
			return BadRequest(response);
		}
    }

    [HttpPut]
    [Route("update-user")]
    public async Task<IActionResult> UpdateUserAsync([FromQuery]string Id, [FromBody] UserDto userDto, CancellationToken cancellationToken)
    {
        try
        {
            Application.Shared.IResult updatedUser = await _userService.UpdateAsync(Id, userDto, cancellationToken);
            return updatedUser.IsSuccess ? Ok(updatedUser) : BadRequest(updatedUser);
            
        }
        catch (FoodOrderException ex)
        {
            var response = Result<FoodOrderingSystem.Core.Entities.User>.Failure(ErrorType.UnableToCreate);
            return BadRequest(response);
        }
    }

    [HttpGet]
    [Route("all-users")]
    public async Task<IActionResult> GetAllUserAsync(CancellationToken cancellationToken)
    {
        try
        {
            Application.Shared.IResult list = await _userService.GetAllAsync(cancellationToken);  
            return list.IsSuccess ? Ok(list) : BadRequest(list);
           
        }
        catch (FoodOrderException ex)
        {
            var response = Result<FoodOrderingSystem.Core.Entities.User>.Failure(ErrorType.UnableToCreate);
            return BadRequest(response);
        }
    }

    [HttpGet]
    [Route("user-id")]
    public async Task<IActionResult> GetUserByIdAsync([FromQuery]string Id, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new ArgumentException(nameof(Id));
            }

            Application.Shared.IResult list = await _userService.GetByIdAsync(Id, cancellationToken);

            return list.IsSuccess ? Ok(list) : BadRequest(list);

        }
        catch (FoodOrderException ex)
        {
            var response = Result<FoodOrderingSystem.Core.Entities.User>.Failure(ErrorType.UnableToCreate);
            return BadRequest(response);
        }
    }
}
