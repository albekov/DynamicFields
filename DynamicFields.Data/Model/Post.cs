namespace DynamicFields.Data.Model
{
    public class Post : IdentityEntity<int>
    {
        public string Title { get; set; }
    }
}