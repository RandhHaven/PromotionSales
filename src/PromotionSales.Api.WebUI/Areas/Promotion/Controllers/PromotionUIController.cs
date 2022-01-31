using Microsoft.AspNetCore.Mvc;

namespace PromotionSales.Api.WebUI.Areas.Promotion.Controllers;
public class PromotionUIController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
