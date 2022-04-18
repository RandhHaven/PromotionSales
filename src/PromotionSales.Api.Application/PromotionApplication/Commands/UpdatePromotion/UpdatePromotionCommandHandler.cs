namespace PromotionSales.Api.Application.PromotionApplication.Commands.UpdatePromotion;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Exceptions;
using PromotionSales.Api.Application.Common.Interfaces;

internal class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, PromotionDto>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public UpdatePromotionCommandHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        this.context = _context ?? throw new ArgumentNullException(nameof(_context));
        this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<PromotionDto> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Promotions
                 .FindAsync(new object[] { request.Id }, cancellationToken);

        if (Object.Equals(entity, null))
        {
            throw new NotFoundException($"Error Modify Promotion: {nameof(PromotionDto)}, {request.Id}");
        }

        //entity.SetValorInteresCuotas(request.ValorInteresCuotas);
        //entity.SetActivo(request.Activo);

        await this.context.SaveChangesAsync(cancellationToken);
        var entityDto = this.mapper.Map<PromotionDto>(entity);

        return entityDto;
    }
}