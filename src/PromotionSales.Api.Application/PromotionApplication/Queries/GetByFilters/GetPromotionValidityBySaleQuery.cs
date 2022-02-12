namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;

using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

public sealed class GetPromotionValidityBySaleQuery : IRequest<GetQueryPromotionSaleDto>
{
    public String MediosDePago { get; set; }
    public String Banco { get; set; }
    public IList<String> CategoriasProductos { get; set; }
}