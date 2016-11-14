using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFields.Data.Model
{
    public class UserInfoGeneralInfo : IdentityEntity<int>
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public short? NumberOfHomeLivingChildren { get; set; }
        public short? NumberOfHomeLivingAdult { get; set; }
        public string Working { get; set; }
        public string HouseType { get; set; }
        public bool? HaveCar { get; set; }
        public decimal? YearsHartACar { get; set; }
    }
}