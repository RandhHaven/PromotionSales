namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;

using System.Threading;
using AutoMapper;
using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Exceptions;
using PromotionSales.Api.Application.Common.Interfaces;

public sealed class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionByIdQuery, PromotionDto>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetPromotionByIdQueryHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper)); ;
    }

    public async Task<PromotionDto> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Promotions
               .FindAsync(new object[] { request.Id }, cancellationToken);
        if (Object.Equals(entity, null))
        {
            throw new NotFoundException($"Error Get By Id Product: {nameof(PromotionDto)}, {request.Id}");
        }
        var entityDto = this.mapper.Map<PromotionDto>(entity);
        return entityDto;
    }
}