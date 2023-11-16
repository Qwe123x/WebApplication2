using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class PositionEditModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Position? Position { get; set; }

        public PositionEditModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Position = await context.Positions.FindAsync(id);

            if (Position == null) return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Positions.Update(Position!);
            await context.SaveChangesAsync();
            return RedirectToPage("Position");
        }
    }
}
