namespace PromotionSales.Api.Domain.Entities;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

internal class Country
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int32 Id { get; private set; }
    public String Descripcion { get; set; }
    public ICollection<Province> Provinces { get; set; }

}
