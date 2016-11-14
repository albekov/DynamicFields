namespace DynamicFields.Models
{
    public class FieldViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Reference { get; set; }
        public FieldInfoViewModel ReferenceField { get; set; }
    }
}