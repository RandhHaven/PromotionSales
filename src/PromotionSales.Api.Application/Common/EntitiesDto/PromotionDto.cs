namespace PromotionSales.Api.Application.Common.EntitiesDto;

using PromotionSales.Api.Application.Common.Mappings;
using PromotionSales.Api.Domain.Entities;

public sealed class PromotionDto : IMapFrom<Promotion>
{
    public String Code { get; set; }
    public IEnumerable<string> MediosDePago { get; set; }
    public IEnumerable<string> Bancos { get; set; }
    public IEnumerable<string> CategoriasProductos { get; set; }
    public int? MaximaCantidadDeCuotas { get; set; }
    public decimal? ValorInteresCuotas { get; set; }
    public decimal? PorcentajeDeDescuento { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public Boolean Activo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}