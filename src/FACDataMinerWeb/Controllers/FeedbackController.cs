using Microsoft.AspNetCore.Mvc;

namespace FACDataMinerWeb.Controllers;

public class FeedbackController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}