using System.ComponentModel.DataAnnotations;

namespace lab11_efcore_crud.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        public string Address { get; set; }
    }
}
