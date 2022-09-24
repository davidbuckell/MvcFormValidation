using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MvcFormTest.Extensions;
using MvcFormTest.Models;

namespace MvcFormTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new FormModel();
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Submit(FormData data)
    {
        var isValid = ModelState.IsValid;
        var viewHtml = await this.RenderViewAsync(isValid ? "_FormSuccess" : "_FormData", data, true);
        var model = new FormResult { IsFormSuccess = isValid, View = viewHtml};
        return Content(JsonSerializer.Serialize(model));
    }
}