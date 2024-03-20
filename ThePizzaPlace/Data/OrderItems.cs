﻿using System.ComponentModel.DataAnnotations;

namespace ThePizzaPlace.Data
{
    public class OrderItems
    {
        [Key, Required]
        public int OrderNo { get; set; }
        [Required]
        public int StockID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}