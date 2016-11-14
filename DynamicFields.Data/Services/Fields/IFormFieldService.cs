using System.Collections.Generic;
using DynamicFields.Data.Model;

namespace DynamicFields.Data.Services.Fields
{
    public interface IFormFieldService : IService
    {
        List<DynamicForm> GetAll();
        DynamicForm Get(int id);
        DynamicForm GetByName(string name);
        DynamicForm Update(DynamicForm form);
        DynamicForm Add(DynamicForm form);
        void Delete(int id);
    }
}