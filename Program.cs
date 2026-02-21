using Microsoft.EntityFrameworkCore;
using Mission06_Corrigan.Models;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Build the FULL path to your SQLite database
var dbPath = Path.Combine(
    builder.Environment.ContentRootPath,
    "App_Data",
    "JoelHiltonMovieCollection.sqlite"
);

// Register DbContext with SQLite
builder.Services.AddDbContext<MovieCollectionContext>(options =>
    options.UseSqlite($"Data Source={dbPath}")
);

var app = builder.Build();

// Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();