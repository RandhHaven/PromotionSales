using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

namespace PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;

public class CreatePromotionCommand : IRequest<PromotionDto>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool Activo { get; set; }
}
