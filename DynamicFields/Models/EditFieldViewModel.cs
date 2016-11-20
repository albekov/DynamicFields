using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DynamicFields.Models
{
    public class EditFieldViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Reference { get; set; }
        public string Values { get; set; }
        public List<SelectListItem> References { get; set; }
    }
}