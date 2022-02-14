namespace PromotionSales.Api.WebUI.Areas.Users.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromotionSales.Api.Application.Common.Models;
using PromotionSales.Api.Application.UserApplication.Commands.CreateUser;
using PromotionSales.Api.Application.UserApplication.Commands.GetUser;
using PromotionSales.Api.WebUI.SharedController;

[ApiController]
[Area("Users")]
public class UsersUIController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost("Signin")]
    public async Task<ActionResult<string>> GetUser(GetUserCommand command)
    {
        return await Mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<Result>> Create(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }
}