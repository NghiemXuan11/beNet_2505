using System.Web.Mvc;
using ClassLibrary.Interfaces;
using WebMVC.Models;

namespace YourNamespace.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser = _authService.ValidateUser(model.Username, model.Password);
                if (isValidUser)
                {
                    TempData["Success"] = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }
    }
}
