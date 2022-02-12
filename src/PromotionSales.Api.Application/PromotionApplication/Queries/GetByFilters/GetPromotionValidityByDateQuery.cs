using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;

public class GetPromotionValidityByDateQuery : IRequest<GetQueryDto>
{
    public DateTime? Date { get; set; } 
}
