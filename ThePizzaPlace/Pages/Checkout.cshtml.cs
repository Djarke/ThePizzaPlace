using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using ThePizzaPlace.Data;
using ThePizzaPlace.Models;

namespace ThePizzaPlace.Pages
{
	[Authorize(Roles = "Admin, Member")]
	public class CheckoutModel : PageModel
    {
        
        private readonly ThePizzaPlaceContext _db;
        private readonly UserManager<IdentityUser> _UserManager;
        public IList<CheckoutItems> Items { get; private set; }
        public decimal Total;
        public long AmountPayable;

        public CheckoutModel(ThePizzaPlaceContext db, UserManager<IdentityUser> UserManager)
        {
            _db = db;
            _UserManager = UserManager;
        }

        public async Task OnGetAsync()
        {
            var user = await _UserManager.GetUserAsync(User);
            CheckoutCustomer customer = await _db.CheckoutCustomers.FindAsync(user.Email);

            //Items = _db.CheckoutItems.FromSqlRaw(
            //    "SELECT FoodItem.ID, FoodItem.Price, " +
            //    "FoodItem.Item_Name" +
            //    "Basketitems.BasketID, BasketItems.Quantity " +
            //    "FROM Fooditem INNER JOIN Basketitems " +
            //    "ON FoodItem.ID = BasketItems.StockID " +
            //    "WHERE BasketID = {0}", customer.BasketID
            //    ).ToList();

            //Total = 0;

            //foreach (var item in Items)
            //{
            //    Total += (item.Quantity * item.Price);
            //}
            //AmountPayable = (long)Total;
        }
        
    }
}
