using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lab10_phonebook_crud.Models
{
    public class PhonebookModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = "";
        [Required]
        [Display(Name = "Phone Number")]
        public string Number { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Address { get; set; } = "";
    }
}
