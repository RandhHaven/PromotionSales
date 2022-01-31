using PromotionSales.Api.Application.Common.Interfaces;

namespace PromotionSales.Api.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
