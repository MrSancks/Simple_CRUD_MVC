using System.ComponentModel.DataAnnotations;

namespace CrudMVC.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El numero de telefono es obligatorio")]
        public string PhoneNumber { get; set; }
        public DateTime DateCreation { get; set; }

    }
}
