using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipPayBackend.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserAccount")]
        public int CustomerId { get; set; }
        public UserAccount User { get; set; }
        public DateTime OrderDate { get; set; }
        //public List<OrderItem> Items { get; set; }
        public RecipeIngredient Recipe { get; set; }
        public string Location { get; set; }
        public bool IsPaid { get; set; }
        public string ReceiptNumber { get; set; }

    }
}
