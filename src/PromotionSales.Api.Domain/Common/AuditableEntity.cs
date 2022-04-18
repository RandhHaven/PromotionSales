namespace PromotionSales.Api.Domain.Common;

public abstract class AuditableEntity
{
    public DateTime DateCreated { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? LastDateModified { get; set; }

    public string? LastModifiedByUserId { get; set; }
}
