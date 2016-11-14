using System.Data.Entity;
using DynamicFields.Data.Model;

namespace DynamicFields.Data
{
    public class Context : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserInfoGeneralInfo> UserInfoGeneralInfos { get; set; }
        public DbSet<UserInfoBankInfo> UserInfoBankInfos { get; set; }
        public DbSet<DynamicField> DynamicFields { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<UserInfo>();
        }
    }
}