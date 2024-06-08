using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.DAL;

var builder = WebApplication.CreateBuilder(args);

// Register dbcontext untuk EF (entity framework)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//menambahkan modul mvc
builder.Services.AddControllersWithViews();

//menambahkan DI (Dependency Injection) dengan DAL
//builder.Services.AddScoped<ICategory, CategoriesDAL>();

// menambahkan dengan EF
builder.Services.AddScoped<ICategory, CategoriesEF>();


builder.Services.AddScoped<ICustomer, CustomersEF>();

builder.Services.AddScoped<IProduct, ProductsEF>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
