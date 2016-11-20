using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                return context.DynamicForms.ToList();
            }
        }

        public DynamicForm Get(int id)
        {
            using (var context = new Context())
            {
                return context.DynamicForms.Include(f => f.FormFields).FirstOrDefault(f => f.Id == id);
            }
        }

        public DynamicForm GetByName(string name)
        {
            using (var context = new Context())
            {
                return context.DynamicForms.FirstOrDefault(f => f.Name == name);
            }
        }

        public DynamicForm Update(DynamicForm form)
        {
            using (var context = new Context())
            {
                var dbForm = context.DynamicForms.FirstOrDefault(f => f.Id == form.Id);
                if (dbForm == null)
                    throw new InvalidOperationException();

                var formFields = form.FormFields.ToList();

                context.DynamicFormFields.RemoveRange(context.DynamicFormFields.Where(f => f.FormId == form.Id));
                context.DynamicFormFields.AddRange(formFields);

                form.FormFields.Clear();
                form.DateCreated = dbForm.DateCreated;
                form.DateUpdated = DateTime.UtcNow;
                context.DynamicForms.AddOrUpdate(form);

                context.SaveChanges();

                var frm = Get(form.Id);
                return frm;
            }
        }

        public DynamicForm Add(DynamicForm form)
        {
            using (var context = new Context())
            {
                var formFields = form.FormFields.ToList();
                form.FormFields.Clear();
                form.DateCreated = DateTime.UtcNow;
                form.DateUpdated = DateTime.UtcNow;
                var dbForm = context.DynamicForms.Add(form);

                formFields.ForEach(ff => ff.Form = dbForm);
                context.DynamicFormFields.AddRange(formFields);

                context.SaveChanges();
                return dbForm;
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var dbForm = context.DynamicForms.FirstOrDefault(f => f.Id == id);
                if (dbForm == null)
                    throw new InvalidOperationException();

                context.DynamicForms.Remove(dbForm);
                context.SaveChanges();
            }
        }
    }
}