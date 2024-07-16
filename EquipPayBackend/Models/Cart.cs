using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipPayBackend.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public bool IsPaid { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
