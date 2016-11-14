using System.Linq;
using AutoMapper;
using DynamicFields.Data.Services.Fields;
using DynamicFields.Models;

namespace DynamicFields.Controllers
{
    public static class ViewModelHelper
    {
        public static FieldsListViewModel CreateFieldsListViewModel(IFieldService fieldService)
        {
            var vm = new FieldsListViewModel();

            var dynamicFieldInfos = fieldService.GetFields();
            var dynamicFields = fieldService.GetAll();

            vm.DbFields = dynamicFields
                .Select(df =>
                {
                    var fvm = Mapper.Map<FieldViewModel>(df);
                    var fi = dynamicFieldInfos.FirstOrDefault(i => i.Name == df.Reference);
                    fvm.ReferenceField = Mapper.Map<FieldInfoViewModel>(fi);
                    return fvm;
                })
                .ToList();

            vm.UnassignedFields = dynamicFieldInfos
                .Where(fi => dynamicFields.All(df => df.Reference != fi.Name))
                .Select(fi => Mapper.Map<FieldInfoViewModel>(fi))
                .ToList();

            return vm;
        }
    }
}