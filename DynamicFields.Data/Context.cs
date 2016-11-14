using System.Data.Entity;
using DynamicFields.Data.Model;

namespace DynamicFields.Data
{
    public class Context : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}