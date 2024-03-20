using System.ComponentModel.DataAnnotations;

namespace ThePizzaPlace.Models
{
    public class Basket
    {
        [Key]
        public int BasketID { get; set; }
    }
}
