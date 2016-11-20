using System.Web.Mvc;
using DynamicFields.Data.Model;
using DynamicFields.Data.Services.Fields;

namespace DynamicFields.Controllers
{
    public class PreviewController : Controller
    {
        private readonly IFormFieldService _formFieldService;

        public PreviewController(IFormFieldService formFieldService)
        {
            _formFieldService = formFieldService;
        }

        public ActionResult Form(int formId)
        {
            var form = _formFieldService.Get(formId);

            var userInfo = new UserInfo();

            var vm = new PreviewFormViewModel<UserInfo> {Form = form, Data = userInfo};

            return View(vm);
        }
    }

    public class PreviewFormViewModel<T>
    {
        public DynamicForm Form { get; set; }
        public T Data { get; set; }
    }
}