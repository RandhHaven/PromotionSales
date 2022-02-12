namespace PromotionSales.Api.Application.Common.EntitiesDto;

using PromotionSales.Api.Application.Common.Mappings;
using PromotionSales.Api.Domain.Entities;

public sealed class PromotionSaleDto : IMapFrom<Promotion>
{
    public IEnumerable<string> MediosDePago { get; private set; }
    public IEnumerable<string> Bancos { get; private set; }
    public IEnumerable<string> CategoriasProductos { get; private set; }
    public int? MaximaCantidadDeCuotas { get; private set; }
    public decimal? ValorInteresCuotas { get; private set; }
    public decimal? PorcentajeDeDescuento { get; private set; }
}