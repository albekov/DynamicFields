using System.Collections.Generic;

namespace DynamicFields.Models
{
    public class FieldsListViewModel
    {
        public List<FieldViewModel> DbFields { get; set; }
        public List<FieldInfoViewModel> UnassignedFields { get; set; }
    }
}