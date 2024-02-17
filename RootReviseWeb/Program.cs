using Microsoft.EntityFrameworkCore;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.DbInitializer;
using RootRevise.DataAccess.Repository;
using RootRevise.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using RootRevise.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => {
   options.LoginPath = $"/Identity/Account/Login";
   options.LogoutPath = $"/Identity/Account/Logout";
   options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
   app.UseExceptionHandler("/Home/Error");
   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();

app.UseAuthorization();
SeedDatabase();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase() {
   using var scope = app.Services.CreateScope();
   var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
   dbInitializer.Initialize();
}
