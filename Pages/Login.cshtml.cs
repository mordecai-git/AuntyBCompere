using AuntyBCompere.Data;
using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Security.Claims;

using Microsoft.EntityFrameworkCore;

namespace AuntyBCompere.Pages;

public class LoginModel : PageModel
{
    private readonly AuntyBCompereContext _context;
    public LoginModel(AuntyBCompereContext context) { _context = context; }


    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }

    public async Task OnGetAsync()
    {
        // Clear the existing external cookie
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> OnPostAsync( )
    {
        string username = Username.ToLower().Trim();

        var user = _context.Users
                           .FirstOrDefault(u =>
                                u.Email.ToLower().Trim() == username || u.Username == username);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        bool authenticated = BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash);

        if (!authenticated)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email),
            new("FullName", $"{user.LastName} {user.FirstName}")
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(claimsIdentity));

        return RedirectToPage("./Testimonials/Index");
    }

    private async Task<User> AuthenticateUser(string username, string password)
    {
        var user = await _context.Users
                           .FirstOrDefaultAsync(u =>
                                u.Email.ToLower().Trim() == username || u.Username == username);

        if (user == null) return null;

        bool authenticated = BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash);

        if (!authenticated) return null;

        return new User {Email = user.Email, FirstName = user.FirstName, LastName = user.LastName};
    }
}