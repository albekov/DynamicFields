using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DynamicFields.Data.Model;
using DynamicFields.Data.Services.Fields;
using DynamicFields.Models;

namespace DynamicFields.Controllers
{
    public class FieldsController : Controller
    {
        private readonly IFieldService _fieldService;

        public FieldsController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        public ActionResult Index()
        {
            var vm = ViewModelHelper.CreateFieldsListViewModel(_fieldService);
            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            var field = _fieldService.Get(id);
            var vm = Mapper.Map<EditFieldViewModel>(field);
            vm.References = GetReferences();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(EditFieldViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var field = Mapper.Map<DynamicField>(vm);
                _fieldService.Update(field);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public ActionResult Add(string reference = null)
        {
            var vm = new EditFieldViewModel {Reference = reference};
            vm.References = GetReferences();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(EditFieldViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var field = Mapper.Map<DynamicField>(vm);
                _fieldService.Add(field);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public ActionResult AssignAll()
        {
            _fieldService.AddFieldsFromModel();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetReferences()
        {
            var items = _fieldService.GetFields()
                .Select(f => new SelectListItem {Text = $"{f.Name} ({f.Type.Name})", Value = f.Name})
                .ToList();
            return items;
        }
    }
}