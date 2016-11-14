namespace DynamicFields.Data.Model
{
    public class User : IdentityEntity<int>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}