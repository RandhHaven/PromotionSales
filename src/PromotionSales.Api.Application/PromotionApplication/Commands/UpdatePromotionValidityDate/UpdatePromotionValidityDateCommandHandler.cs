namespace PromotionSales.Api.Application.PromotionApplication.Commands.UpdatePromotionByValidityDate;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Exceptions;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Domain.Entities;

internal class UpdatePromotionValidityDateCommandHandler : IRequestHandler<UpdatePromotionValidityDateCommand, PromotionDto>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public UpdatePromotionValidityDateCommandHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<PromotionDto> Handle(UpdatePromotionValidityDateCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Promotions
                .FindAsync(new object[] { request.Id, request.FechaInicio.Value, request.FechaFin.Value }, cancellationToken);

        if (Object.Equals(entity, null))
        {
            throw new NotFoundException($"Error Modify Promotion: {nameof(PromotionDto)}, {request.Id}");
        }
        entity.SetActivo(true);

        await this.context.SaveChangesAsync(cancellationToken);
        var entityDto = this.mapper.Map<PromotionDto>(entity);

        return entityDto;
    }
}
