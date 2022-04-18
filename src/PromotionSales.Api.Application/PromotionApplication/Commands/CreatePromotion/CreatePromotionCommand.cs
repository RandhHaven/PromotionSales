using MediatR;

namespace PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;

public class CreatePromotionCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public IList<string> MediosDePago { get; set; }
    public IList<string> Bancos { get; set; }
    public IList<string> CategoriasProductos { get; set; }
    public int? MaximaCantidadDeCuotas { get; set; }
    public decimal? ValorInteresCuotas { get; set; }
    public decimal? PorcentajeDeDescuento { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public bool Active { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}
