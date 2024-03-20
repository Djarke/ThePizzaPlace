using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThePizzaPlace.Models;

namespace ThePizzaPlace.Data
{
    public class ThePizzaPlaceContext : IdentityDbContext
    {
        public ThePizzaPlaceContext (DbContextOptions<ThePizzaPlaceContext> options)
            : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<CheckoutCustomer> CheckoutCustomers { get; set; } = default!;
        public DbSet<Basket> Baskets { get; set; } = default!;
        public DbSet<BasketItem> BasketItem { get; set; } = default!;
        public DbSet<OrderHistory> OrderHistories { get; set; } = default!;
        public DbSet<OrderItems> OrderItems { get; set; } = default!;
        [NotMapped]
        public DbSet<CheckoutItems> CheckoutItems { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FoodItem>().ToTable("FoodItem");

            modelBuilder.Entity<BasketItem>().HasKey(t => new { t.StockID, t.BasketID });

        }
    }
}
