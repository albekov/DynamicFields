namespace DynamicFields.Data.Model
{
    public class DynamicField : IdentityEntity<int>
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Reference { get; set; }
        public string Values { get; set; }
    }
}