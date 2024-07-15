using EquipPayBackend.Models;
using System.ComponentModel.DataAnnotations;
namespace EquipPayBackend.DTOs.UserDTO
{
    public class AddUserDTO
    {
        public string UserFullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        [RegularExpression(@"([0-9]{9}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; } = null!;
        public string UserGender { get; set; } = string.Empty;

        public Role 
        public bool IsCurrentlyActive { get; set; } = true;
        public DateTime? DateOfTermination { get; set; }
    }
}



