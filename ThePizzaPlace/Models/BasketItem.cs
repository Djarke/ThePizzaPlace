using System.ComponentModel.DataAnnotations;

namespace ThePizzaPlace.Models
{
    public class BasketItem
    {
        [Required]
        public int StockID { get; set; }
        [Required]
        public int BasketID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
