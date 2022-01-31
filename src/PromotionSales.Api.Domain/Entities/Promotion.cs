using PromotionSales.Api.Domain.Common;

namespace PromotionSales.Api.Domain.Entities;

public sealed class Promotion : AuditableEntity, IHasDomainEvent
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
    public List<DomainEvent> DomainEvents { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}