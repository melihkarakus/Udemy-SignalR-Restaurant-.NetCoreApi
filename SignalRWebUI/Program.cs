using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//KUllanýcý giriþ yapmadan admin tarafýna eriþemez. 
var requiredAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

// Add services to the container.
//Bunu yazmazsan register sayfasý çalýþmaz
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();


builder.Services.AddHttpClient();
//Authorize iþlemi yukarý yazýldýktan sonra buraya eklenmeler yapýldý.
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requiredAuthorizePolicy));
});

//Proje otantike olmadan login sayfamýza gönderme iþlemi
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index";
});

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
app.UseAuthentication();//Otantike ekle
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
