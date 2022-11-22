using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuntyBCompere.Pages.Users;

public class CreateModel : PageModel
{
    private readonly AuntyBCompere.Data.AuntyBCompereContext _context;

    public CreateModel(AuntyBCompere.Data.AuntyBCompereContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public User User { get; set; }
        

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(User.PasswordHash);
        _context.Users.Add(User);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}