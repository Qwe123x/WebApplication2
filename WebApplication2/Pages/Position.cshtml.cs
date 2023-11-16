using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class PositionModel : PageModel
    {
        ApplicationContext context;
        public List<Position> Positions { get; private set; } = new();
        public PositionModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Positions = context.Positions.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Positions.FindAsync(id);

            if (user != null)
            {
                context.Positions.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
