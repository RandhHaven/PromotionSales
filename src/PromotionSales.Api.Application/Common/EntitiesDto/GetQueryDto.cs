namespace PromotionSales.Api.Application.Common.EntitiesDto;

public sealed class GetQueryDto
{
    public IList<PromotionDto> ListPromotions { get; set; } = new List<PromotionDto>();
}