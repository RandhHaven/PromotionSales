namespace PromotionSales.Api.Application.PromotionApplication.Commands.UpdatePromotionByValidityDate;

using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

public sealed class UpdatePromotionValidityDateCommand : IRequest<PromotionDto>
{
    public Guid Id { get; private set; }
    public DateTime? FechaInicio { get; private set; }
    public DateTime? FechaFin { get; private set; }
}