using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class CreatePositionModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Position Position { get; set; } = new();
        public CreatePositionModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Positions.Add(Position);
            await context.SaveChangesAsync();
            return RedirectToPage("Position");
        }
    }
}
