using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Mime;
using DynamicFields.Data.Model;

namespace DynamicFields.Data.Services.Fields
{
    public class FieldService : IFieldService
    {
        private static readonly Lazy<List<DynamicFieldInfo>> DynamicFields =
            new Lazy<List<DynamicFieldInfo>>(GetAllDynamicFields);

        public List<DynamicFieldInfo> GetFields()
        {
            return DynamicFields.Value;
        }

        private static List<DynamicFieldInfo> GetAllDynamicFields()
        {
            var classes = typeof(FieldService).Assembly
                .GetTypes()
                .Where(DynamicClassInfo.IsDynamicClass)
                .ToDictionary(DynamicFieldHelper.GetClassInfo, DynamicFieldHelper.GetFields);

            //classes.Add(GetClassInfo(typeof(UserInfo)), GetFields(typeof(UserInfo)));

            return classes.Values.SelectMany(f => f).ToList();
        }

        public List<DynamicField> GetAll()
        {
            using (var context = new Context())
            {
                return context.DynamicFields.ToList();
            }
        }

        public DynamicField Get(int id)
        {
            using (var context = new Context())
            {
                return context.DynamicFields.FirstOrDefault(f => f.Id == id);
            }
        }

        public DynamicField GetByName(string name)
        {
            using (var context = new Context())
            {
                return context.DynamicFields.FirstOrDefault(f => f.Name == name);
            }
        }

        public DynamicField Update(DynamicField field)
        {
            using (var context = new Context())
            {
                var dbField = context.DynamicFields.FirstOrDefault(f => f.Id == field.Id);
                if (dbField == null)
                    throw new InvalidOperationException();

                context.DynamicFields.AddOrUpdate(field);
                context.SaveChanges();
                return Get(field.Id);
            }
        }

        public DynamicField Add(DynamicField field)
        {
            using (var context = new Context())
            {
                var dbField = context.DynamicFields.Add(field);
                context.SaveChanges();
                return dbField;
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var dbField = context.DynamicFields.FirstOrDefault(f => f.Id == id);
                if (dbField == null)
                    throw new InvalidOperationException();

                context.DynamicFields.Remove(dbField);
                context.SaveChanges();
            }
        }

        public void AddFieldsFromModel()
        {
            var dynamicFields = GetAll();
            var dynamicFieldInfos = GetAllDynamicFields();

            var fieldInfos = dynamicFieldInfos
                .Where(fi => dynamicFields.All(f => f.Reference != fi.Name))
                .ToList();

            foreach (var fi in fieldInfos)
            {
                var dynamicField = new DynamicField
                {
                    Name = fi.Name,
                    Label = fi.Name,
                    Reference = fi.Name
                };
                Add(dynamicField);
            }
        }
    }
}