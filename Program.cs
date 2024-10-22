using AspNetCoreHero.ToastNotification.Extensions;
using Korntest.Models.db;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

var strConn = builder.Configuration.GetConnectionString("Testdata");

builder.Services.AddDbContext<TestdataContext>(option => option.UseSqlServer(strConn));

// builder.Services.Configure<SendMail>(builder.Configuration.GetSection("SendMail"));
// builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("ApiOptions"));

builder.Services.AddHttpClient();
// builder.Services.AddTransient<NetworkServices, NetworkServices>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login/");
    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/ErrorForbidden/");
    //options.ExpireTimeSpan = TimeSpan.FromDays(1);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SystemAll", p => p.RequireRole("SystemAll"));
    options.AddPolicy("Admin", p => p.RequireRole("SystemAll", "Admin"));
    options.AddPolicy("Approve", p => p.RequireRole("SystemAll", "Admin", "Approve"));
    options.AddPolicy("UserAr", p => p.RequireRole("SystemAll", "Admin", "Approve", "UserAr"));
    options.AddPolicy("User", p => p.RequireRole("SystemAll", "Admin", "Approve", "UserAr", "User"));
});

// builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopCenter; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization("en-US");
app.UseNotyf();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
