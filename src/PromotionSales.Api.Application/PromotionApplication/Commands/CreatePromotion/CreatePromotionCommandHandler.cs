using AutoMapper;
using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Domain.Entities;

namespace PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;

public sealed class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Guid>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public CreatePromotionCommandHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<Guid> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Promotion();

        entity.Activo = request.Activo;
        this.context.Promotions.Add(entity);

        await this.context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}