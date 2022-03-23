namespace PromotionSales.Api.WebUI.Helpers;

public class AppSettings
{
    public const string Section = "AppSettings";
    public AppSettingsJwt Jwt { get; set; }
    public AppSettingsAzureBlob Blob { get; set; }
    public AppSettingsEmpresa Empresa { get; set; }
    public string CacheRemotoBaseApi { get; set; }
}
