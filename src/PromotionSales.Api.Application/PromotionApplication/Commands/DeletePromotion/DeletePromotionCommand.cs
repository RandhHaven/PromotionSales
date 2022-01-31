using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PromotionSales.Api.Application.PromotionApplication.Commands.DeletePromotion;

public class DeletePromotionCommand : IRequest<Guid?>
{
    public Guid Id { get; set; }
}
