namespace PromotionSales.Api.Application.Common.Interfaces;

using PromotionSales.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext
{
    DbSet<Promotion> Promotions { get; }
    DbSet<PromotionConfigure> PromotionsConfigure { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}