namespace PromotionSales.Api.Application.UserApplication.Commands.CreateUser;

using MediatR;
using PromotionSales.Api.Application.Common.Models;

public sealed class CreateUserCommand : IRequest<Result>
{
    public String Email { get; set; }
    public String Password { get; set; }
}
