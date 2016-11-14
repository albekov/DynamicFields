using System.Collections.Generic;
using System.Web.Mvc;

namespace DynamicFields.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public List<SelectListItem> Users { get; set; }
    }
}