using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DynamicFields.Data.Model;
using DynamicFields.Data.Services.Fields;
using DynamicFields.Helpers;
using DynamicFields.Models;
using Newtonsoft.Json;

namespace DynamicFields.Controllers
{
    public class FormsController : Controller
    {
        private readonly IFormFieldService _formFieldService;
        private readonly IFieldService _fieldService;

        public FormsController(
            IFormFieldService formFieldService,
            IFieldService fieldService)
        {
            _formFieldService = formFieldService;
            _fieldService = fieldService;
        }

        public ActionResult Index()
        {
            var vm = CreateFormsListViewModel();
            return View(vm);
        }

        public ActionResult Edit(int? id = null)
        {
            var vm = id.HasValue
                ? Mapper.Map<EditFormViewModel>(_formFieldService.Get(id.Value))
                : new EditFormViewModel();

            vm.Fields = ViewModelHelper.CreateFieldsListViewModel(_fieldService);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(EditFormViewModel vm)
        {
            var form = Mapper.Map<DynamicForm>(vm);

            int id;
            if (form.Id == 0)
                id= _formFieldService.Add(form).Id;
            else
                id = _formFieldService.Update(form).Id;

            return Json(new {ok = "ok", id = id});
        }

        public ActionResult Delete(int id)
        {
            _formFieldService.Delete(id);
            return RedirectToAction("Index");
        }


        private FormsListViewModel CreateFormsListViewModel()
        {
            var vm = new FormsListViewModel();

            var forms = _formFieldService.GetAll();
            vm.Forms = Mapper.Map<List<FormViewModel>>(forms);

            return vm;
        }

        public ActionResult SaveForm()
        {
            return Content("Saved!");
        }

        [HttpPost]
        public ActionResult Info(int formId)
        {
            var form = _formFieldService.Get(formId);
            var obj = new
            {
                DateUpdated = form.DateUpdated
            };
            var str = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return Content(str, "application/json");
        }
    }
}