using Microsoft.EntityFrameworkCore;

using AuntyBCompere.Data;

using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Admin");
    options.Conventions.AuthorizeFolder("/Testimonials");
    options.Conventions.AuthorizeFolder("/Users");
    options.Conventions.AllowAnonymousToPage("/Testimonials/Index");
    options.Conventions.AllowAnonymousToPage("/Testimonials/Create");

    //options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(options =>
        {
            options.LoginPath = "/Login";
        });

builder.Services.AddDbContext<AuntyBCompereContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuntyBCompereContext") ?? throw new InvalidOperationException("Connection string 'AuntyBCompereContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
