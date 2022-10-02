using System.ComponentModel.DataAnnotations;

namespace Web.UI.Models
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}
