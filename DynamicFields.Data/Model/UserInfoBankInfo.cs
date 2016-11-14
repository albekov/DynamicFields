using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFields.Data.Model
{
    public class UserInfoBankInfo : IdentityEntity<int>
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public bool? PropertyOwner { get; set; }
        public string CurrentBank { get; set; }
        public string BankProduct { get; set; }
        public string CustomerType { get; set; }
        public bool? HaveChildrenSavings { get; set; }
        public int? ChildrenSavingsInAccount { get; set; }
        public decimal? IncomeBeforeTax { get; set; }
        public decimal? IncomeAfterTax { get; set; }
    }
}