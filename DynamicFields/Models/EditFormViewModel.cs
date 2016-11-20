using System;
using System.Collections.Generic;
using DynamicFields.Data.Model;

namespace DynamicFields.Models
{
    public class EditFormViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<FormFieldViewModel> FormFields { get; set; }
        public FieldsListViewModel Fields { get; set; }

        public EditFormViewModel()
        {
            FormFields = new List<FormFieldViewModel>();
        }
    }

    public class FormFieldViewModel
    {
        public FieldType FieldType { get; set; }
        public string Label { get; set; }
        public bool IsRequired { get; set; }
        public bool ShowLabel { get; set; }
        public int Step { get; set; }
        public int FormId { get; set; }
        public int? FieldId { get; set; }
        public EditFieldViewModel Field { get; set; }
    }
}