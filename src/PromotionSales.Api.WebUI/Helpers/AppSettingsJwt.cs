namespace PromotionSales.Api.WebUI.Helpers;

public class AppSettingsJwt
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string expires_in { get; set; }
}