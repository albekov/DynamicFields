using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DynamicFields.Data.Model;
using DynamicFields.Data.Services.Fields;

namespace DynamicFields.Controllers
{
    public class FormsController : Controller
    {
        private readonly IFormFieldService _formFieldService;

        public FormsController(IFormFieldService formFieldService)
        {
            _formFieldService = formFieldService;
        }

        public ActionResult Index()
        {
            var vm = CreateFormsListViewModel();
            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            var form = _formFieldService.Get(id);
            var vm = Mapper.Map<EditFormViewModel>(form);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(EditFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var form = Mapper.Map<DynamicForm>(vm);
                _formFieldService.Update(form);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public ActionResult Add()
        {
            var vm = new EditFormViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(EditFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var field = Mapper.Map<DynamicForm>(vm);
                _formFieldService.Add(field);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        private FormsListViewModel CreateFormsListViewModel()
        {
            var vm = new FormsListViewModel();

            var forms = _formFieldService.GetAll();
            vm.Forms = Mapper.Map<List<FormViewModel>>(forms);

            return vm;
        }
    }

    public class EditFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class FormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class FormsListViewModel
    {
        public List<FormViewModel> Forms { get; set; }
    }
}