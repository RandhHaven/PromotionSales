namespace PromotionSales.Api.Domain.Common;

public sealed class ImagenBase64
{
    public string Nombre { get; set; }
    public string Imagen { get; set; }

    public ImagenBase64()
    {
    }

    public ImagenBase64(string nombre, string imagen)
    {
        Nombre = nombre;
        Imagen = imagen;
    }
}