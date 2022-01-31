namespace PromotionSales.Api.Application.Common.EntitiesDto;

using PromotionSales.Api.Application.Common.Mappings;
using PromotionSales.Api.Domain.Entities;

public sealed class PromotionDto : IMapFrom<Promotion>
{
    public Guid Id { get; private set; }
    public IEnumerable<string> MediosDePago { get; private set; }
    public IEnumerable<string> Bancos { get; private set; }
    public IEnumerable<string> CategoriasProductos { get; private set; }
    public int? MaximaCantidadDeCuotas { get; private set; }
    public decimal? ValorInteresCuotas { get; private set; }
    public decimal? PorcentajeDeDescuento { get; private set; }
    public DateTime? FechaInicio { get; private set; }
    public DateTime? FechaFin { get; private set; }
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaModificacion { get; private set; }
}