using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DynamicFields.Data.Model;

namespace DynamicFields.Data.Services.Fields
{
    public class FormFieldService : IFormFieldService
    {
        public List<DynamicForm> GetAll()
        {
            using (var context = new Context())
            {
                return context.Forms.ToList();
            }
        }

        public DynamicForm Get(int id)
        {
            using (var context = new Context())
            {
                return context.Forms.FirstOrDefault(f => f.Id == id);
            }
        }

        public DynamicForm GetByName(string name)
        {
            using (var context = new Context())
            {
                return context.Forms.FirstOrDefault(f => f.Name == name);
            }
        }

        public DynamicForm Update(DynamicForm form)
        {
            using (var context = new Context())
            {
                var dbForm = context.Forms.FirstOrDefault(f => f.Id == form.Id);
                if (dbForm == null)
                    throw new InvalidOperationException();

                context.Forms.AddOrUpdate(form);
                context.SaveChanges();
                return Get(form.Id);
            }
        }

        public DynamicForm Add(DynamicForm form)
        {
            using (var context = new Context())
            {
                var dbForm = context.Forms.Add(form);
                context.SaveChanges();
                return dbForm;
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var dbForm = context.Forms.FirstOrDefault(f => f.Id == id);
                if (dbForm == null)
                    throw new InvalidOperationException();

                context.Forms.Remove(dbForm);
                context.SaveChanges();
            }
        }
    }
}