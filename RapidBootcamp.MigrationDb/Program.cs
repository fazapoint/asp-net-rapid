using Azure;
using CsvHelper;
using RapidBootcamp.MigrationDb.RapidCodeFirstDb;
using RapidBootcamp.MigrationDb.RapidDb;
using System.Globalization;
using System.Text;
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
//var httpClient = new HttpClient();
//try
//{
//    var response = await httpClient.GetAsync("http://localhost:5200/api/Categories");
//    if (response.IsSuccessStatusCode)
//    {
//        var data = await response.Content.ReadAsStringAsync();
//        var categories = JsonSerializer.Deserialize<List<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category>>(data);
//        foreach (var item in categories)
//        {
//            Console.WriteLine($"{item.CategoryId} - {item.CategoryName}");
//        }
//        rapidCFDb.Categories.AddRange(categories);
//        rapidCFDb.SaveChanges();
//        Console.WriteLine("Migrasi tabel Categories dari API ke RapidCodeFirstDb berhasil");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}


//// =============== Get Product By Id (from API) ===============
//try
//{
//    Console.Write("Masukkan ID Product: ");
//    var id = Convert.ToInt32(Console.ReadLine());
//    var httpClient = new HttpClient();
//    var response = await httpClient.GetAsync($"http://localhost:5200/api/Products/{id}");
//    if (response.IsSuccessStatusCode)
//    {
//        var data = await response.Content.ReadAsStringAsync();
//        RapidBootcamp.MigrationDb.RapidDb.Product product = JsonSerializer.Deserialize<RapidBootcamp.MigrationDb.RapidDb.Product>(data);
//        Console.WriteLine($"{product.ProductId} - {product.ProductName} - {product.Price} - {product.Category.CategoryName}");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.InnerException.Message);
//}


// =============== Insert Category From Csv Through API to RapidDb ===============
//var httpClient = new HttpClient();
//using (var reader = new StreamReader("D:\\csv\\RapidDb_Categories.csv"))
//{
//    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//    {
//        var records = csv.GetRecords<RapidBootcamp.MigrationDb.RapidDb.Category>();
//        foreach (var item in records)
//        {
//            var newCategory = JsonSerializer.Serialize<RapidBootcamp.MigrationDb.RapidDb.Category>(item);
//            var content = new StringContent(newCategory, Encoding.UTF8, "application/json");
//            var response = await httpClient.PostAsync("http://localhost:5200/api/Categories", content);
//            if (response.IsSuccessStatusCode)
//            {
//                Console.WriteLine($"Data Category {item.CategoryName} berhasil di insert");
//            }
//            else
//            {
//                Console.WriteLine($"Data Category {item.CategoryName} gagal di insert");
//            }
//        }
//    }
//}


// =============== Update Products from rapidDb to RapidCodeFirstDb through API ===============
var httpClient = new HttpClient();
var db2Products = rapidCFDb.Products.ToList();
foreach (var item in db2Products)
{
    var db1Product = new RapidBootcamp.MigrationDb.RapidDb.Product
    {
        ProductId = item.ProductId,
        CategoryId = item.CategoryId,
        ProductName = item.ProductName,
        Price = item.Price,
        Stock = item.Stock
    };

    var serializeProduct = JsonSerializer.Serialize<RapidBootcamp.MigrationDb.RapidDb.Product>(db1Product);
    var content = new StringContent(serializeProduct, Encoding.UTF8, "application/json");
    var response = await httpClient.PutAsync($"http://localhost:5200/api/Products/{item.ProductId}", content);
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Data Product {item.ProductName} berhasil di update");
    }
    else
    {
        Console.WriteLine($"Data Product {item.ProductName} gagal di update");
    }
}

