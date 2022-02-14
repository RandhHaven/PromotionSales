namespace PromotionSales.Api.Application.Common.Interfaces;

using PromotionSales.Api.Domain.Common;

public interface ITokenSignerService
{
    public string SignToken(UserResult user);
}