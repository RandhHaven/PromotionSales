using PromotionSales.Api.Domain.Common;
using PromotionSales.Api.Domain.Entities;

namespace PromotionSales.Api.Domain.Events;

public class PromotionDeletedEvent : DomainEvent
{
    public PromotionDeletedEvent(Promotion item)
    {
        Item = item;
    }

    public Promotion Item { get; }
}
