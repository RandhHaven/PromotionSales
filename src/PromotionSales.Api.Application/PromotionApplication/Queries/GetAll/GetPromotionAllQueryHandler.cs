using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Interfaces;

namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetAll;

public sealed class GetOrderShopAllQueryHandler : IRequestHandler<GetPromotionAllQuery, GetQueryDto>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetOrderShopAllQueryHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<GetQueryDto> Handle(GetPromotionAllQuery request, CancellationToken cancellationToken)
    {
        var listVm = new GetQueryDto
        {
            ListPromotions = await context.Promotions
            .AsNoTracking()
            .ProjectTo<PromotionDto>(mapper.ConfigurationProvider)

            .OrderBy(t => t.Activo)
            .ToListAsync(cancellationToken)
        };
        return listVm;
    }
}