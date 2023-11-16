using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class EmployeeEditModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Employee? Employee { get; set; }
        public List<Position> Positions { get; private set; } = new();
        public EmployeeEditModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Positions = context.Positions.AsNoTracking().ToList();
            Employee = await context.Employees.FindAsync(id);

            if (Employee == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Positions = context.Positions.AsNoTracking().ToList();
                return Page();
            }

            context.Employees.Update(Employee!);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        
    }
}
