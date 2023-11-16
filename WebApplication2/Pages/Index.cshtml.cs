using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<Employee> Employees { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Employees = context.Employees.AsNoTracking().ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Employees.FindAsync(id);

            if (user != null)
            {
                context.Employees.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}
