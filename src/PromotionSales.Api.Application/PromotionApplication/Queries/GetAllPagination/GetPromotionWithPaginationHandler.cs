namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetAllPagination;

using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Application.Common.Mappings;
using PromotionSales.Api.Application.Common.Models;

internal class GetPromotionWithPaginationHandler : IRequestHandler<GetPromotionWithPagination, PaginatedList<PromotionDto>>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetPromotionWithPaginationHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<PaginatedList<PromotionDto>> Handle(GetPromotionWithPagination request, CancellationToken cancellationToken)
    {
        return await this.context.Promotions
           .OrderBy(x => x.Active)
           .ProjectTo<PromotionDto>(this.mapper.ConfigurationProvider)
           .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}