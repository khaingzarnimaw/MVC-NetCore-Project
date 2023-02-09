using Microsoft.AspNetCore.Mvc;
using RegisterandLoginApp2.Models;
using RegisterandLoginApp2.Services;

namespace RegisterandLoginApp2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Processlogin(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(userModel))
            {
                return View("LoginSuccess", userModel);
            }else
            {
                return View("LoginFailure", userModel);
            }
           
           
        }
    }

}
