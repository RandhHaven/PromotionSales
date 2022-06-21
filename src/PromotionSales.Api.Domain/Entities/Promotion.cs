namespace PromotionSales.Api.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using PromotionSales.Api.Domain.Common;

public sealed class Promotion : AuditableEntity, IHasDomainEvent
{
    public Promotion()
    {
        PromotionsConfigure = new HashSet<PromotionConfigure>();
    }

    [Required]
    [Key]
    public Guid Id { get; private set; }
    public String Code { get; private set; }
    public string PromocionName { get; private set; }
    public ICollection<PromotionConfigure> PromotionsConfigure { get; set; }
    public DateTime? EffectiveDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public Boolean Active { get; set; }
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}