using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PromotionSales.Api.Application.Common.EntitiesDto;

namespace PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;

public class GetPromotionByValidityDateQuery : IRequest<GetQueryDto>
{
}
