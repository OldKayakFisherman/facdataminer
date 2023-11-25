using Microsoft.AspNetCore.Mvc;

namespace FACDataMinerWeb.Controllers;

public class SearchController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}