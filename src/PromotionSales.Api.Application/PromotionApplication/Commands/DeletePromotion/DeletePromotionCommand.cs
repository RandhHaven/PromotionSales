using MediatR;

namespace PromotionSales.Api.Application.PromotionApplication.Commands.DeletePromotion;

public class DeletePromotionCommand : IRequest<Guid?>
{
    public Guid Id { get; set; }
}
