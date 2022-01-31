using PromotionSales.Api.Domain.Common;

namespace PromotionSales.Api.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}