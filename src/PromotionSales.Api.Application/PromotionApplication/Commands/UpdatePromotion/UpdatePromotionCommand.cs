namespace PromotionSales.Api.Application.PromotionApplication.Commands.UpdatePromotion;

using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

public class UpdatePromotionCommand : IRequest<PromotionDto>
{
    public Guid Id { get; set; }
    public bool Activo { get; set; }
}