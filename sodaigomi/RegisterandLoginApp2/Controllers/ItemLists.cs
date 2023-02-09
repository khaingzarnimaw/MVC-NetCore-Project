using Microsoft.AspNetCore.Mvc;

namespace RegisterandLoginApp2.Controllers
{
    public class ItemLists : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
