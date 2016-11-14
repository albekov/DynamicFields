using System.Collections.Generic;
using DynamicFields.Data.Model;

namespace DynamicFields.Data.Services.Fields
{
    public interface IFieldService : IService
    {
        List<DynamicFieldInfo> GetFields();

        List<DynamicField> GetAll();
        DynamicField Get(int id);
        DynamicField GetByName(string name);
        DynamicField Update(DynamicField field);
        DynamicField Add(DynamicField field);
        void Delete(int id);
        void AddFieldsFromModel();
    }
}