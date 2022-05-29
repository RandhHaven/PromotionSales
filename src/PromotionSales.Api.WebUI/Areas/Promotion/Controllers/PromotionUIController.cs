namespace PromotionSales.Api.WebUI.Areas.Promotion.Controllers;

using Microsoft.AspNetCore.Mvc;
using PromotionSales.Api.Application.Common.EntitiesDto;
using PromotionSales.Api.Application.Common.Models;
using PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;
using PromotionSales.Api.Application.PromotionApplication.Commands.DeletePromotion;
using PromotionSales.Api.Application.PromotionApplication.Commands.UpdatePromotion;
using PromotionSales.Api.Application.PromotionApplication.Commands.UpdatePromotionByValidityDate;
using PromotionSales.Api.Application.PromotionApplication.Queries.GetAll;
using PromotionSales.Api.Application.PromotionApplication.Queries.GetAllPagination;
using PromotionSales.Api.Application.PromotionApplication.Queries.GetByFilters;
using PromotionSales.Api.WebUI.SharedController;

[ApiController]
[Area("Promotion")]
public class PromotionUIController : ApiControllerBase
{
    [HttpGet("GetOrderWithPagination")]
    public async Task<ActionResult<PaginatedList<PromotionDto>>> GetOrderWithPagination([FromQuery] GetPromotionWithPagination query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    public async Task<ActionResult<GetQueryDto>> Get()
    {
        return await this.Mediator.Send(new GetPromotionAllQuery());
    }

    [HttpGet("GetPromotionById/{id}")]
    public async Task<ActionResult<PromotionDto>> GetPromotionById(Guid id)
    {
        return await this.Mediator.Send(new GetPromotionByIdQuery { Id  = id });
    }

    [HttpGet("GetPromotionValiditys")]
    public async Task<ActionResult<GetQueryDto>> GetPromotionValiditys()
    {
        return await this.Mediator.Send(new GetPromotionValiditysQuery());
    }

    [HttpGet("GetPromotionValidityByDate/{validateDate}")]
    public async Task<ActionResult<GetQueryDto>> GetPromotionValidityByDate(String validateDate)
    {
        DateTime dateTime;
        if (!DateTime.TryParse(validateDate, out dateTime))
        {
            return BadRequest();
        }
        return await this.Mediator.Send(new GetPromotionValidityByDateQuery { Date = dateTime });
    }

    [HttpGet("GetPromotionValidityBySale")]
    public async Task<ActionResult<GetQueryPromotionSaleDto>> GetPromotionValidityBySale(String mediosPago)
    {
        return await this.Mediator.Send(new GetPromotionValidityBySaleQuery { MediosDePago = mediosPago });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await this.Mediator.Send(new DeletePromotionCommand { Id = id });
        return NoContent();
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult<Guid>> Create(CreatePromotionCommand command)
    {
        try
        {
            return await Mediator.Send(command);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [Route("[action]/{id}")]
    public async Task<ActionResult> Update(Guid id, UpdatePromotionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut]
    [Route("[action]/{id}/{fechaInicio}/{fechaFin}")]
    public async Task<ActionResult> UpdateValidityDate(Guid id, string fechaInicio, string fechaFin, UpdatePromotionValidityDateCommand command)
    {
        if (id != command.Id || fechaInicio != command.FechaInicio.ToString() || fechaFin != command.FechaFin.ToString())
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}