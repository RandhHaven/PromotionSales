namespace PromotionSales.Api.Domain.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

internal class Province
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int32 Id { get; private set; }
    public String Descripcion { get; set; }
    public Int32 CountryId { get; set; }
    public Country Country { get; set; }
}
