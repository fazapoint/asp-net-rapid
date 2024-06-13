using CsvHelper;
using RapidBootcamp.MigrationDb.RapidCodeFirstDb;
using RapidBootcamp.MigrationDb.RapidDb;
using System.Globalization;
using System.Text.Json;

Console.WriteLine("Migrasi data dari RapidDb ke RapidCodeFirstDb");

var rapidDb = new RapidDbContext();
var rapidCFDb = new RapidCFDbContext();

// ============ MIGRASI UNTUK DATA TABLE CATEGORIES (From sqlserver to sqlserver) ============

//var rapidDbCategories = rapidDb.Categories.ToList();

//List<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category> listCategory = new List<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category>();

//foreach (var item in rapidDbCategories)
//{
//    listCategory.Add(new RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category
//    {
//        CategoryId = item.CategoryId,
//        CategoryName = item.CategoryName
//    });
//}

//rapidCFDb.Categories.AddRange(listCategory);
//rapidCFDb.SaveChanges();
//Console.WriteLine("Migrasi tabel Categories dari RapidDb ke RapidCodeFirstDb berhasil");



// ============ MIGRASI UNTUK DATA TABLE PRODUCTS (From sqlserver to sqlserver) ============
//var rapidDbProducts = rapidDb.Products.ToList();

//List<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Product> listProduct = new List<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Product>();

//foreach (var item in rapidDbProducts)
//{
//    listProduct.Add(new RapidBootcamp.MigrationDb.RapidCodeFirstDb.Product
//    {
//        ProductId = item.ProductId,
//        CategoryId = item.CategoryId,
//        ProductName = item.ProductName,
//        Stock = item.Stock,
//        Price = item.Price
//    });
//}

//rapidCFDb.Products.AddRange(listProduct);
//rapidCFDb.SaveChanges();
//Console.WriteLine("Migrasi tabel Products dari RapidDb ke RapidCodeFirstDb berhasil");


// ============ MIGRASI UNTUK DATA TABLE Categories (From CSV) ============ 
//using (var reader = new StreamReader("D:\\csv\\RapidDb_Categories.csv"))
//{
//    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//    {
//        var records = csv.GetRecords<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category>();
//        foreach (var item in records)
//        {
//            rapidCFDb.Categories.Add(item);
//        }
//        rapidCFDb.SaveChanges();
//    }
//}
//Console.WriteLine("Migrasi tabel Categories dari csv ke RapidCodeFirstDb berhasil");

// ============ MIGRASI UNTUK DATA TABLE Categories (From API) ============ 
var httpClient = new HttpClient();
try
{
    var response = await httpClient.GetAsync("http://localhost:5200/api/Categories");
    if (response.IsSuccessStatusCode)
    {
        var data = await response.Content.ReadAsStringAsync();
        var categories = JsonSerializer.Deserialize<List<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category>>(data);
        foreach (var item in categories)
        {
            Console.WriteLine($"{item.CategoryId} - {item.CategoryName}");
        }
        rapidCFDb.Categories.AddRange(categories);
        rapidCFDb.SaveChanges();
        Console.WriteLine("Migrasi tabel Categories dari API ke RapidCodeFirstDb berhasil");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
