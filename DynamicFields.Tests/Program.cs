using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFields.Data.Services.Fields;

namespace DynamicFields.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new FieldService();
            var dynamicFieldInfos = service.GetFields();
            var dynamicFields = service.GetAll();

            service.AddFieldsFromModel();
        }
    }
}
