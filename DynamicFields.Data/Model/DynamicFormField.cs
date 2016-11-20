using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFields.Data.Model
{
    public class DynamicFormField : IdentityEntity<int>
    {
        public FieldType FieldType { get; set; }

        public string Label { get; set; }

        public bool IsRequired { get; set; }

        public bool ShowLabel { get; set; }

        public int Step { get; set; }

        public int FormId { get; set; }

        [ForeignKey("FormId")]
        public DynamicForm Form { get; set; }

        public int? FieldId { get; set; }

        [ForeignKey("FieldId")]
        public DynamicField Field { get; set; }
    }
}