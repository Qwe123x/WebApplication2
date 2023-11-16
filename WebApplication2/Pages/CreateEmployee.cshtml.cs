using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class CreateEmployeeModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Employee Employee { get; set; } = new();
        public List<Position> Positions { get; private set; } = new();

        public CreateEmployeeModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                Positions = context.Positions.AsNoTracking().ToList();
                return Page();
            }

            Employee.HireDate = DateTime.UtcNow;
            context.Employees.Add(Employee);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        public void OnGet()
        {
            Positions = context.Positions.AsNoTracking().ToList();
        }


    }
}
