using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

namespace PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;

public class CreatePromotionCommand : IRequest<PromotionDto>
{
    public Guid Id { get; set; }
    public String Title { get; set; }
    public Boolean Activo { get; set; }
}
