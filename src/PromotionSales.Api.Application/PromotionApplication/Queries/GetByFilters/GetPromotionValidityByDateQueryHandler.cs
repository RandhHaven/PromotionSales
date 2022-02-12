namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Exceptions;
using PromotionSales.Api.Application.Common.Interfaces;

internal class GetPromotionValidityByDateQueryHandler : IRequestHandler<GetPromotionValidityByDateQuery, GetQueryDto>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetPromotionValidityByDateQueryHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper)); ;
    }

    public async Task<GetQueryDto> Handle(GetPromotionValidityByDateQuery request, CancellationToken cancellationToken)
    {
        var listEntity = await this.context.Promotions
            .Where(x => x.FechaInicio == request.Date)
            .AsNoTracking()
            .ProjectTo<PromotionDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (Object.Equals(listEntity, null))
        {
            throw new NotFoundException($"Error Get By Promotion Validity by Date: {nameof(PromotionDto)}, {request.Date}");
        }
        var listVm = new GetQueryDto
        {
            ListPromotions = listEntity
        };

        return listVm;
    }
}