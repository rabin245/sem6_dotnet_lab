using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace lab11_test.Models
{
    public class PhonebookModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [DisplayName("Contact Number")]
        public string Number { get; set; }
    }
}
