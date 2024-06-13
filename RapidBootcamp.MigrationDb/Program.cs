using RapidBootcamp.MigrationDb.RapidCodeFirstDb;
using RapidBootcamp.MigrationDb.RapidDb;

Console.WriteLine("Migrasi data dari RapidDb ke RapidCodeFirstDb");

var rapidDb = new RapidDbContext();
var rapidCFDb = new RapidCFDbContext();

// ============ MIGRASI UNTUK DATA TABLE CATEGORIES (WITHOUT CATEGORYID) ============

var rapidDbCategories = rapidDb.Categories.ToList();

List<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category> listCategory = new List<RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category>();

foreach (var item in rapidDbCategories)
{
    listCategory.Add(new RapidBootcamp.MigrationDb.RapidCodeFirstDb.Category
    {
        CategoryId = item.CategoryId,
        CategoryName = item.CategoryName
    });
}

rapidCFDb.Categories.AddRange(listCategory);
rapidCFDb.SaveChanges();
Console.WriteLine("Migrasi tabel Categories dari RapidDb ke RapidCodeFirstDb berhasil");



// ============ MIGRASI UNTUK DATA TABLE PRODUCTS (WITH PRODUCTID/WITHOUT AUTOINCREMENT) ============
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