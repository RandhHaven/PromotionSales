using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionSales.Api.Domain.Entities;

internal class Localities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int32 Id { get; private set; }
    public String Descripcion { get; set; }
    public Int32 CountryId { get; set; }
    public Country Country { get; set; }
    public Int32 ProvinceId { get; set; }
}
