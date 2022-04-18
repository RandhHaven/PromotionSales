namespace PromotionSales.Api.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PromotionSales.Api.Domain.Common;

public class PromotionConfigure : AuditableEntity, IHasDomainEvent
{
    [Required]
    [Key]
    public Guid Id { get; private set; }
    public Guid PromotionId { get; private set; }
    [ForeignKey(nameof(PromotionId))]
    public virtual Promotion Promotion { get; set; }
    public MeanPayment MeansPaymentId { get; set; }
    public Bank BankId { get; set; }    
    public ProductCategory ProductCategoryId { get; set; }
    public int? DuesQuanty { get; private set; }
    public decimal? ValorInteresCuotas { get; private set; }
    public decimal? PorcentajeDeDescuento { get; private set; }
    public DateTime? FechaInicio { get; private set; }
    public DateTime? FechaFin { get; private set; }
    public bool Active { get; set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaModificacion { get; private set; }
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

    public void SetValorInteresCuotas(decimal? value)
    {
        this.ValorInteresCuotas = value;
    }

    public void SetActivo(Boolean value)
    {
        this.Active = value;
    }

    public void SetMaximaCantidadDeCuotas(int? duesQuanty)
    {
        this.DuesQuanty = duesQuanty;
    }
    public void SetPorcentajeDeDescuento(decimal? porcentajeDeDescuento)
    {
        this.PorcentajeDeDescuento = porcentajeDeDescuento;
    }
}