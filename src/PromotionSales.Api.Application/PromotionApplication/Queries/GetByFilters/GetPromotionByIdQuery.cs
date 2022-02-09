using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;

public sealed class GetPromotionByIdQuery : IRequest<PromotionDto>
{
    public Guid Id { get; set; }
}
