namespace PromotionSales.Api.Application.Common.EntitiesDto;

using PromotionSales.Api.Application.Common.Mappings;
using PromotionSales.Api.Domain.Entities;

public sealed class GetQueryPromotionSaleDto
{
    public IList<PromotionSaleDto> ListPromotionsSale { get; set; } = new List<PromotionSaleDto>();
}