using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PromotionSales.Api.Domain.Common;

namespace PromotionSales.Api.Domain.Entities;

public sealed class Promotion : AuditableEntity, IHasDomainEvent
{
    [Required]
    [Key]
    public Guid Id { get; private set; }
    [NotMapped]
    public IList<string> MediosDePago { get; set; }
    [NotMapped]
    public IList<string> Bancos { get; set; }
    [NotMapped]
    public IList<string> CategoriasProductos { get; set; }
    public int? MaximaCantidadDeCuotas { get; private set; }
    public decimal? ValorInteresCuotas { get; private set; }
    public decimal? PorcentajeDeDescuento { get; private set; }
    public DateTime? FechaInicio { get; private set; }
    public DateTime? FechaFin { get; private set; }
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaModificacion { get; private set; }
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}