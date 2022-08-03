using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlogApp.Data;
using BlogApp.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

if (builder.Environment.IsDevelopment())
{
    // builder.Services.AddDbContext<MvcMovieContext>(options =>
    //     options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext")));
    builder.Services.AddDbContext<MvcArticleContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcArticleContext") ?? throw new InvalidOperationException("Connection string 'MvcArticleContext' not found.")));

}
else
{
    builder.Services.AddDbContext<MvcArticleContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcArticleContext")));
    // builder.Services.AddDbContext<MvcMovieContext>(options =>
    //     options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcMovieContext")));
}
var app = builder.Build();

// using( var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     SeedData.Initialize(services);
// }
using( var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedDataArticles.Initialize(services);
}

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Articles}/{action=Index}/{id?}");

app.Run();
