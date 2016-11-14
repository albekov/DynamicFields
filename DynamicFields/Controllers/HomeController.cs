using System.Linq;
using System.Web.Mvc;
using DynamicFields.Data.Services;
using DynamicFields.Models;

namespace DynamicFields.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var users = _userService.GetUsers();

            var vm = new LoginViewModel();
            vm.Users = users.Select(u => new SelectListItem {Text = u.Login, Value = u.Id.ToString()}).ToList();
            return View(vm);
        }

        public ActionResult Login(LoginViewModel vm)
        {
            Session["userId"] = vm.Id;
            return RedirectToAction("Index", "Fields");
        }

        public ActionResult LoginPartial()
        {
            string login = null;
            var id = Session["userId"];
            if (id != null)
                login = _userService.Get((int) id).Login;
            return PartialView("_LoginPartial", login);
        }

        public ActionResult Logout()
        {
            Session["userId"] = null;
            return RedirectToAction("Index");
        }
    }
}