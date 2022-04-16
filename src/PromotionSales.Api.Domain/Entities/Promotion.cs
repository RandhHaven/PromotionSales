﻿namespace PromotionSales.Api.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PromotionSales.Api.Domain.Common;

public sealed class Promotion : AuditableEntity, IHasDomainEvent
{
    [Required]
    [Key]
    public Guid Id { get; private set; }
    [NotMapped]
    public IList<string> MediosDePago { get; set; }
    [NotMapped]
    public IList<string> Bancos { get; set; }
    [NotMapped]
    public IList<string> CategoriasProductos { get; set; }
    public int? MaximaCantidadDeCuotas { get; private set; }
    public decimal? ValorInteresCuotas { get; private set; }
    public decimal? PorcentajeDeDescuento { get; private set; }
    public DateTime? FechaInicio { get; private set; }
    public DateTime? FechaFin { get; private set; }
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaModificacion { get; private set; }
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

    public void SetValorInteresCuotas(decimal? value)
    {
        this.ValorInteresCuotas = value;
    }

    public void SetActivo(Boolean value)
    {
        this.Activo = value;
    }

    public void SetMaximaCantidadDeCuotas(int? maximaCantidadDeCuotas)
    {
        this.MaximaCantidadDeCuotas = maximaCantidadDeCuotas;
    }

    public void SetPorcentajeDeDescuento(decimal? porcentajeDeDescuento)
    {
        this.PorcentajeDeDescuento = porcentajeDeDescuento;
    }
}