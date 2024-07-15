using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EquipPayBackend.Models
{
    public class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }
        public string UserName { get; set; } = null!;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int EmployeeId { get; set; } // Foreign key to Employee
        public UserInfo? UserInfo { get; set; } // Navigation property to UserInfo
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
