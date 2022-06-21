namespace PromotionSales.Api.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bank
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int32 Id { get; private set; }
    public String Descripcion { get; set; }
}