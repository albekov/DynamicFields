using System;

namespace DynamicFields.Models
{
    public class FormViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}