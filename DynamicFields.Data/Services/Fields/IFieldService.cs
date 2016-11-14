using System.Collections.Generic;

namespace DynamicFields.Data.Services.Fields
{
    public interface IFieldService : IService
    {
        List<DynamicFieldInfo> GetDynamicFields();
    }
}