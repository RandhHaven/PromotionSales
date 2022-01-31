using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetAll;

public sealed class GetPromotionAllQuery : IRequest<GetQueryDto>
{
}
