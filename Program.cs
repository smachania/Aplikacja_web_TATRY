using App_web_Tatry.Entities;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>();

//-------------------------------------------------------------------
builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Gdzie przekierowaæ, gdy brak zalogowania
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });
//------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//----------------------------------------------------------
app.UseAuthentication();
//----------------------------------------------------------
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Szlaki}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>(); 
        context.Database.Migrate(); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Wyst¹pi³ b³¹d podczas migracji bazy danych.");
    }
}


app.Run();
