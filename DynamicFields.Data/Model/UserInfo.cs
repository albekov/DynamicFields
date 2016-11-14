using System;
using DynamicFields.Data.Services.Fields;

namespace DynamicFields.Data.Model
{
    [DynamicClass]
    public class UserInfo : User
    {
        public DateTime Created { get; set; }
        public UserInfoGeneralInfo GeneralInfo { get; set; }
        public UserInfoBankInfo BankInfo { get; set; }
    }
}