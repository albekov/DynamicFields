using System;

namespace DynamicFields.Data.Model
{
    public class DynamicField : IdentityEntity<int>
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Reference { get; set; }
        public string Values { get; set; }
    }
}