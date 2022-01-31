using PromotionSales.Api.Domain.Common;
using PromotionSales.Api.Domain.Entities;

namespace PromotionSales.Api.Domain.Events;

public class PromotionCreatedEvent : DomainEvent
{
    public PromotionCreatedEvent(Promotion item)
    {
        Item = item;
    }

    public Promotion Item { get; }
}
