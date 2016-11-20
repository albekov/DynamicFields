using System;
using System.Collections.Generic;

namespace DynamicFields.Data.Model
{
    public class DynamicForm : IdentityEntity<int>
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<DynamicFormField> FormFields { get; set; }
    }
}