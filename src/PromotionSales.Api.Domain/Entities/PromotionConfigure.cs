namespace PromotionSales.Api.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PromotionSales.Api.Domain.Common;

public class PromotionConfigure : AuditableEntity
{
    [Required]
    [Key]
    public Guid Id { get; private set; }
    public Guid PromotionId { get; private set; }
    [ForeignKey(nameof(PromotionId))]
    public virtual Promotion Promotion { get; set; }
    public Int32 MeansPaymentId { get; set; }
    public MeanPayment MeansPayment { get; set; }
    public Int32 BankId { get; set; }
    public Bank Bank { get; set; }
    public Int32 ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public Int32? DuesQuanty { get; private set; }
    public Decimal? ValorInteresCuotas { get; private set; }
    public Decimal? PorcentajeDeDescuento { get; private set; }
    public DateTime? FechaInicio { get; private set; }
    public DateTime? FechaFin { get; private set; }
    public Boolean Active { get; set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaModificacion { get; private set; }
}