using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DynamicFields.Data.Services.Fields;

namespace DynamicFields.Controllers
{
    public class FieldsController : Controller
    {
        private readonly IFieldService _fieldService;

        public FieldsController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        public ActionResult List()
        {
            var vm = Create();
            return View(vm);
        }

        private FieldsListViewModel Create()
        {
            var vm = new FieldsListViewModel();

            var dynamicFieldInfos = _fieldService.GetFields();
            var dynamicFields = _fieldService.GetAll();

            vm.DbFields = dynamicFields
                .Select(df =>
                {
                    var fvm = new FieldViewModel();
                    fvm.Name = df.Name;

                    var info = dynamicFieldInfos.FirstOrDefault(i => i.Name == df.Reference);
                    if (info != null)
                        fvm.Reference = info.Name;

                    return fvm;
                })
                .ToList();

            vm.UnassignedFields = dynamicFieldInfos
                .Where(dfi => !dynamicFields.Any(df => df.Reference == dfi.Name))
                .Select(dfi => new FieldViewModel {Reference = dfi.Name})
                .ToList();

            return vm;
        }
    }

    public class FieldViewModel
    {
        public string Name { get; set; }
        public string Reference { get; set; }
    }

    public class FieldsListViewModel
    {
        public List<FieldViewModel> DbFields { get; set; }
        public List<FieldViewModel> UnassignedFields { get; set; }
    }
}