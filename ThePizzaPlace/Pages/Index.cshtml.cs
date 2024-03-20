using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThePizzaPlace.Data;
using ThePizzaPlace.Models;

namespace ThePizzaPlace.Pages
{
    [Authorize (Roles = "Admin, Member")]
    public class IndexModel : PageModel
    {

        private readonly ThePizzaPlace.Data.ThePizzaPlaceContext _context;

        public IndexModel(ThePizzaPlace.Data.ThePizzaPlaceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Search { get; set; }

        public IList<FoodItem> FoodItem { get;set; } = default!;

        private readonly ThePizzaPlaceContext _db;

        public void OnGet()
        {
            FoodItem = _context.FoodItems.FromSqlRaw("SELECT * FROM FoodItem").ToList();
        }

        public IActionResult OnPostSearch() 
        {
            FoodItem = _context.FoodItems
                .FromSqlRaw("SELECT * FROM FoodItem WHERE Item_name LIKE '" + Search + "%'").ToList();
            return Page();
        }
    }
}
