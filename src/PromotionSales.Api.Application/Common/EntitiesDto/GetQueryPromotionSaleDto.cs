namespace PromotionSales.Api.Application.Common.EntitiesDto;

public sealed class GetQueryPromotionSaleDto
{
    public IList<PromotionSaleDto> ListPromotionsSale { get; set; } = new List<PromotionSaleDto>();
}