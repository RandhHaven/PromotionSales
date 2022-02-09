using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Models;

namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetAllPagination;

public class GetPromotionWithPagination : IRequest<PaginatedList<PromotionDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
