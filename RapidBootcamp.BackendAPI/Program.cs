using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackendAPI.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddJsonOption for ignoring upper case or lower case in json
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register entity framework (EF)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// DI (Dependency Injection) using ADO .net
//builder.Services.AddScoped<ICategory, CategoriesDAL>();
//builder.Services.AddScoped<IProduct, ProductsDAL>();
//builder.Services.AddScoped<IOrderHeader, OrderHeadersDAL>();
//builder.Services.AddScoped<IOrderDetail, OrderDetailsDAL>();
//builder.Services.AddScoped<IWallet, WalletsDAL>();

// DI (Dependency Injection) using Entity Framework (EF)
builder.Services.AddScoped<ICategory, CategoriesEF>();
builder.Services.AddScoped<IProduct, ProductsEF>();
builder.Services.AddScoped<IOrderHeader, OrderHeadersDAL>();
builder.Services.AddScoped<IOrderDetail, OrderDetailsDAL>();
builder.Services.AddScoped<IWallet, WalletsDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
