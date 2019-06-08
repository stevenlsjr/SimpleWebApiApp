using Microsoft.AspNetCore.Mvc;

namespace SimpleWebAPIApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public IActionResult Index()
    {
      return Redirect("/swagger");
    }
  }
}