namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Interfaces;

internal sealed class GetPromotionValidityBySaleQueryHandler : IRequestHandler<GetPromotionValidityBySaleQuery, GetQueryPromotionSaleDto>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetPromotionValidityBySaleQueryHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper)); ;
    }

    public async Task<GetQueryPromotionSaleDto> Handle(GetPromotionValidityBySaleQuery request, CancellationToken cancellationToken)
    {
        var listVm = new GetQueryPromotionSaleDto
        {
            ListPromotionsSale = await context.Promotions
           .AsNoTracking()
           .ProjectTo<PromotionSaleDto>(mapper.ConfigurationProvider)
           .ToListAsync(cancellationToken)
        };
        return listVm;
    }
}