namespace PromotionSales.Api.Application.PromotionApplication.Commands.DeletePromotion;

using MediatR;
using Microsoft.EntityFrameworkCore;
using PromotionSales.Api.Application.Common.Exceptions;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Domain.Entities;

internal sealed class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, Guid?>
{
    private readonly IApplicationDbContext context;

    public DeletePromotionCommandHandler(IApplicationDbContext _context)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<Guid?> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var entityDelete = await this.context.Promotions
               .Where(x => x.Id == request.Id)
               .SingleOrDefaultAsync(cancellationToken);

       
        if (Object.Equals(entityDelete, null))
        {
            throw new NotFoundException($"Error Delete Promotion {nameof(Promotion) } - {request.Id}");
        }

        this.context.Promotions.Remove(entityDelete);

        await this.context.SaveChangesAsync(cancellationToken);

        return entityDelete.Id;
    }
}