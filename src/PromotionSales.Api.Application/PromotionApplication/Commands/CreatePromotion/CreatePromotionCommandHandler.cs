using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Domain.Entities;

namespace PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;

public sealed class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Guid>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;
    private readonly ILogger<CreatePromotionCommandHandler> logger;

    public CreatePromotionCommandHandler(IApplicationDbContext _context, IMapper _mapper, ILogger<CreatePromotionCommandHandler> _logger)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        this.logger = _logger?? throw new ArgumentNullException(nameof(_logger));
    }

    public async Task<Guid> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Promotion();
        try
        {
            entity.Active = request.Active;
            this.context.Promotions.Add(entity);

            await this.context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
        }
        return entity.Id;
    }
}