namespace PromotionSales.Api.WebUI.Areas.Promotion.Controllers;

using Microsoft.AspNetCore.Mvc;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Models;
using PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;
using PromotionSales.Api.Application.PromotionApplication.Commands.DeletePromotion;
using PromotionSales.Api.Application.PromotionApplication.Commands.UpdatePromotion;
using PromotionSales.Api.Application.PromotionApplication.Queries.GetAllPagination;
using PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;
using PromotionSales.Api.WebUI.SharedController;

public class PromotionUIController : ApiControllerBase
{
    [HttpGet("GetOrderWithPagination")]
    public async Task<ActionResult<PaginatedList<PromotionDto>>> GetOrderWithPagination([FromQuery] GetPromotionWithPagination query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("GetPromotionById/{id}")]
    public async Task<ActionResult<PromotionDto>> GetPromotionById(Guid id)
    {
        return await this.Mediator.Send(new GetPromotionByIdQuery { Id  = id });
    }

    [HttpGet("GetPromotionByValidityDate/{id}")]
    public async Task<ActionResult<GetQueryDto>> GetPromotionByValidityDate(Guid? id)
    {
        return await this.Mediator.Send(new GetPromotionByValidityDateQuery());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await this.Mediator.Send(new DeletePromotionCommand { Id = id });
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<PromotionDto>> Create(CreatePromotionCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdatePromotionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateValidityDate(Guid id, UpdatePromotionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}