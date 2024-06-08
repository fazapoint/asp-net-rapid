// See https://aka.ms/new-console-template for more information

//string firstName = "Erick";
//string lastName = "Kurniawan";

//int age = 25;
//var height = 170.5;
//bool isMarried = false;

//string nama;
//nama = "Erick Kurniawan";


//var fullName = "Erick Kurniawan";
//fullName = "Agus Kurniawan";

//var saldo = 100_000_000;

//var strSql = @"select * from Employees 
//               where EmpId=@EmpId 
//               order by EmpId asc";


//int number1 = 99;

//Console.WriteLine("Number 1: " + number1.ToString());
//Console.WriteLine($"Nama anda: {firstName} {lastName}");
//Console.WriteLine("Nama anda : " + firstName + " " + lastName);
//Console.WriteLine(34.40M);




//using System.Collections;

//int number1 = 99;
//int number2 = number1;
//number1 = 199;

////Console.WriteLine("Number 1: " + number1);
////Console.WriteLine("Number 2: " + number2);


//Student student1 = new Student();
//student1.Name = "Erick";
//student1.Age = 25;

//Student student2 = student1;
//student1.Name = "Agus";

//Student student3 = new Student();
//student3.Name = "Erick";
//student3.Age = 25;

//Lecturer lecturer1 = new Lecturer();
//lecturer1.LecturerId = 1;
//lecturer1.LecturerName = "Budi";

//var result1 = student1 is Student;
//var result2 = student1 is Lecturer;
//var result3 = student2 == student1;
//var result4 = student3 == student1;
//var result5 = student1.Age == student3.Age;

//Console.WriteLine(result1);
//Console.WriteLine(result2);
//Console.WriteLine(result3);
//Console.WriteLine(result4);
//Console.WriteLine(result5);

//Console.WriteLine("Student 1: " + student1.Name + " " + student1.Age);
//Console.WriteLine("Student 2: " + student2.Name + " " + student2.Age);

//Hari hari1 = Hari.Senin;
//Console.WriteLine(hari1);

//string[] names = new string[3];
//names[0] = "Erick";
//names[1] = "Agus";
//names[2] = "Budi";

//foreach (var name in names)
//{
//    Console.WriteLine(name);
//}

//int[] ints = new int[3];
//ints[0] = 1;
//ints[1] = 2;
//ints[2] = 3;


////tidak disarankan untuk digunakan
//ArrayList list = new ArrayList();
//list.Add("Erick");
//list.Add("Budi");
//list.Add(12);
//list.Add("Joe");

//foreach (string item in list)
//{
//    Console.WriteLine(item);
//}

//List<string> strNama = new List<string>();
//strNama.Add("Erick");
//strNama.Add("Agus");
//strNama.Add("Joe");
//strNama.Add("Jojo");

//foreach (string nama in strNama)
//{
//    Console.WriteLine(nama);
//}

//enum Hari
//{
//    Senin = 1,
//    Selasa = 2,
//    Rabu = 3,
//    Kamis = 4,
//    Jumat = 5,
//    Sabtu = 6,
//    Minggu = 7
//}

//using RapidBootcamp.ConsoleApp;

//Console.Write("Masukan Jumlah Matakuliah: ");
//int jumlah = Convert.ToInt32(Console.ReadLine());

//List<double> lstScore = new List<double>();

//for (int i = 0; i < jumlah; i++)
//{
//    Console.Write($"Masukan Nilai Matakuliah {i + 1} (1-100) :");
//    lstScore.Add(Convert.ToDouble(Console.ReadLine()));
//}

//try
//{
//    double sumOfScore = 0;
//    foreach (double score in lstScore)
//    {
//        sumOfScore += score;
//    }

//    Stack<int> stackNumber = new Stack<int>();
//    stackNumber.Push(12);
//    stackNumber.Push(20);
//    stackNumber.Push(25);

//    Console.WriteLine(stackNumber.Pop());

//    Queue<int> queue = new Queue<int>();
//    queue.Enqueue(1);
//    queue.Enqueue(2);
//    queue.Enqueue(3);
//    queue.Enqueue(4);

//    Console.WriteLine(queue.Dequeue());

//    List<string> lstNames = new List<string>();
//    lstNames.Add("Erick");
//    lstNames.Add("Agus");

//    Console.WriteLine(lstNames[0]);

//    Dictionary<string, int> shoppingCart = new Dictionary<string, int>();
//    shoppingCart["P001"] = 2;
//    shoppingCart["K002"] = 3;


//    string gradeResult = CalculateGrade(sumOfScore);
//    Console.WriteLine($"Score: {sumOfScore} - Grade: {gradeResult}");

//    DisplayRandomNumbers();

//    //Helper myHelper = new Helper();
//    //double luasSegitiga = myHelper.HitungLuasSegitiga(10, 5);
//    //double luasPersegi = myHelper.HitungLuasPersegi(10);
//    double luasSegitiga = Helper.HitungLuasSegitiga(10, 5);
//    double luasPersegi = Helper.HitungLuasPersegi(10);
//    Console.WriteLine($"luas segitiga: {luasSegitiga}, luasPersegi: {luasPersegi}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"{ex.Message}");
//}

//string CalculateGrade(double score)
//{
//    string grade = string.Empty;
//    if (score >= 86 && score <= 100)
//    {
//        grade = "A";
//    }
//    else if (score >= 71 && score <= 85)
//    {
//        grade = "B";
//    }
//    else if (score >= 56 && score <= 70)
//    {
//        grade = "C";
//    }
//    else if (score >= 40 && score <= 55)
//    {
//        grade = "D";
//    }
//    else
//    {
//        grade = "E";
//    }
//    return grade;
//}

//void DisplayRandomNumbers()
//{
//    Random random = new Random();

//    for (int i = 0; i < 5; i++)
//    {
//        Console.Write($"{random.Next(1, 100)} ");
//    }
//}


//using RapidBootcamp.ConsoleApp.Domain;

//Student student1 = new Student();
//Student student2 = new Student();
//Student student3 = new Student("7778886543", "James");
//Student student4 = new Student("9966556654", "Affan", "Bandung");
//Student student5 = new Student
//{
//    Nim = "1122334455",
//    Name = "Budi",
//    Address = "Jakarta"
//};

//Lecturer lecturer1 = new Lecturer()
//{
//    LecturerId = 1,
//    LecturerName = "Joko",
//    Address = "Semarang"
//};
//Lecturer lecturer2 = new Lecturer(2, "Bams", "Jogja");

//student1.setNim("9988998899");
//student1.setName("Erick Kurniawan");
//try
//{
//    student1.Nim = "9988998899";
//    student1.Name = "Erick Kurniawan";
//    student1.Address = "Redmond WA";
//    Console.WriteLine(student1.Nim + "\n" + student1.Name + "\n" + student1.Address);
//    Console.WriteLine($"{student2.Nim}\n{student2.Name}\n{student2.Address}");
//    Console.WriteLine($"{student3.Nim}\n{student3.Name}\n{student3.Address}");
//    Console.WriteLine($"{student4.Nim}\n{student4.Name}\n{student4.Address}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}

//POCO
//List<Student> lstStudents = new List<Student>();

//Console.Write("Masukan Jumlah Student: ");
//int jumlah = Convert.ToInt32(Console.ReadLine());
//int counter = 0;
//while (counter < jumlah)
//{
//    Student newStudent = new Student();
//    Console.Write("Masukan Nim: ");
//    newStudent.Nim = Console.ReadLine();
//    Console.Write("Masukan Nama: ");
//    newStudent.Name = Console.ReadLine();
//    Console.Write("Masukan Address: ");
//    newStudent.Address = Console.ReadLine();

//    lstStudents.Add(newStudent);
//    counter++;
//}

//Console.WriteLine("-----------------------------------------------------------");
//Console.WriteLine("Nim\tNama\tAddress");
//foreach (Student student in lstStudents)
//{
//    Console.WriteLine($"{student.Nim} - {student.Name} - {student.Address}");
//}

using RapidBootcamp.ConsoleApp.DAL;
using RapidBootcamp.ConsoleApp.Domain;

//Person person1 = new Person();
//person1.FullName = "Erick Kurniawan";
//person1.Address = "Jakarta";
//person1.PhoneNumber = "08123456789";
//Console.WriteLine(person1.GetInfo());


//Student student1 = new Student();
//student1.FullName = "Agus Kurniawan";
//student1.Address = "Bandung";
//student1.PhoneNumber = "08123456789";
//student1.Nim = "1234567890";
//student1.IPK = 3.5;

//Student student2 = new Student("Joe", "Jogja", "23456", "9988990077", 3.9);
//Student student3 = new Student("Tery", "Jogja", "2345889", "9988990099", 3.5);

//Lecturer lecturer1 = new Lecturer();
//lecturer1.FullName = "Budi Kurniawan";
//lecturer1.Address = "Semarang";
//lecturer1.PhoneNumber = "08123456789";
//lecturer1.NIK = "1234567890";
//lecturer1.RoomNumber = "A-123";
////Console.WriteLine(lecturer1.GetInfo());

//SecondYearStudent secondYearStudent1 = new SecondYearStudent();
//secondYearStudent1.FullName = "Joko Kurniawan";
//secondYearStudent1.Address = "Surabaya";
//secondYearStudent1.PhoneNumber = "08123456789";
//secondYearStudent1.Nim = "1234567890";
//secondYearStudent1.IPK = 3.5;
//secondYearStudent1.Major = "Computer Science";
//secondYearStudent1.Class = "A-1";
////Console.WriteLine(secondYearStudent1.GetInfo());

//List<Person> persons = new List<Person>();
//persons.Add(student1);
//persons.Add(student2);
//persons.Add(student3);
//persons.Add(lecturer1);
//persons.Add(secondYearStudent1);

//ICrud crudLecturer = new Lecturer();
//crudLecturer.Insert();
//ICrud crudStudent = new Student();
//crudStudent.Insert();

//foreach (IStorable storePerson in persons)
//{
//    storePerson.Store();
//}

/*foreach (Person person in persons)
{
    person.Save();
}*/

//CategoriesDAL categoriesDAL = new CategoriesDAL();
//IEnumerable<Category> categories = new List<Category>();
//try
//{
//    categories = categoriesDAL.GetAll();
//    DisplayAllData(categories);
//    //Console.Write("Masukan CategoryId yang akan ditampilkan : ");
//    //int categoryId = Convert.ToInt32(Console.ReadLine());
//    //Category resultCategory = categoriesDAL.GetById(categoryId);
//    //if (resultCategory != null)
//    //{
//    //    Console.WriteLine($"{resultCategory.CategoryId.ToString().PadLeft(10)} {resultCategory.CategoryName.PadRight(30)}");
//    //}
//    //else
//    //{
//    //    Console.WriteLine("Data tidak ditemukan");
//    //}

//    //insert data
//    /*Console.Write("Masukan CategoryName yang akan disimpan : ");
//    string categoryName = Console.ReadLine();
//    Category newCategory = new Category
//    {
//        CategoryName = categoryName
//    };
//    Category result = categoriesDAL.Add(newCategory);
//    if (result != null)
//    {
//        Console.WriteLine($"Data Category : {newCategory.CategoryId} - {newCategory.CategoryName} berhasil ditambah !");
//    }
//    else
//    {
//        Console.WriteLine("Data gagal disimpan");
//    }*/
//    /*Console.Write("Masukan CategoryId yang akan diupdate : ");
//    int categoryId = Convert.ToInt32(Console.ReadLine());

//    //cari data yang akan diupdate
//    Category categoryToUpdate = categoriesDAL.GetById(categoryId);
//    if (categoryToUpdate != null)
//    {
//        Console.Write("Masukan CategoryName yang baru : ");

//        categoryToUpdate.CategoryName = Console.ReadLine();
//        Category result = categoriesDAL.Update(categoryToUpdate);

//        if (result != null)
//        {
//            Console.WriteLine($"Data Category : {result.CategoryId} - {result.CategoryName} berhasil diupdate !");

//            categories = categoriesDAL.GetAll();
//            DisplayAllData(categories);
//        }
//        else
//        {
//            Console.WriteLine("Data gagal diupdate");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Data tidak ditemukan");
//    }*/

//    /*Console.Write("Masukan CategoryId yang akan didelete : ");
//    int categoryId = Convert.ToInt32(Console.ReadLine());
//    Category categoryToDelete = categoriesDAL.GetById(categoryId);
//    if (categoryToDelete != null)
//    {
//        categoriesDAL.Delete(categoryId);
//        Console.WriteLine($"Data Category : {categoryToDelete.CategoryId} - {categoryToDelete.CategoryName} berhasil dihapus !");

//        categories = categoriesDAL.GetAll();
//        DisplayAllData(categories);
//    }
//    else
//    {
//        Console.WriteLine("Data tidak ditemukan");
//    }*/

//    Console.Write("Masukan CategoryName yang akan dicari : ");
//    string categoryName = Console.ReadLine();
//    IEnumerable<Category> resultCategories = categoriesDAL.GetByCategoryName(categoryName);
//    if (resultCategories != null)
//    {
//        DisplayAllData(resultCategories);
//    }
//    else
//    {
//        Console.WriteLine("Data tidak ditemukan");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}


//void DisplayAllData(IEnumerable<Category> categories)
//{
//    Console.WriteLine("-----------------------------------------------------------");
//    Console.WriteLine("CategoryId\tCategoryName");
//    foreach (Category category in categories)
//    {
//        Console.WriteLine($"{category.CategoryId.ToString().PadLeft(10)} {category.CategoryName.PadRight(30)}");
//    }
//    Console.WriteLine("-----------------------------------------------------------");
//}

ProductsDAL productsDAL = new ProductsDAL();




//Console.Write("Masukan Product Name :");
//string productName = Console.ReadLine();
//Console.Write("Masukan Category Id :");
//int categoryId = Convert.ToInt32(Console.ReadLine());
//Console.Write("Masukan Price :");
//decimal price = Convert.ToDecimal(Console.ReadLine());
//Console.Write("Masukan Stock :");
//int stock = Convert.ToInt32(Console.ReadLine());

//try
//{
//    var newProduct = new Product
//    {
//        ProductName = productName,
//        CategoryId = categoryId,
//        Price = price,
//        Stock = stock
//    };
//    Product result = productsDAL.Add(newProduct);
//    if (result != null)
//    {
//        Console.WriteLine($"Data Product : {result.ProductId} - {result.ProductName} berhasil ditambah !");
//    }
//    else
//    {
//        Console.WriteLine("Data gagal disimpan");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}


//update Products
Console.Write("Masukan ProductId yang akan diupdate : ");
int productId = Convert.ToInt32(Console.ReadLine());
Product productToUpdate = productsDAL.GetById(productId);
if (productToUpdate != null)
{
    Console.Write("Masukan ProductName yang baru : ");
    productToUpdate.ProductName = Console.ReadLine();
    Console.Write("Masukan CategoryId yang baru : ");
    productToUpdate.CategoryId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Masukan Price yang baru : ");
    productToUpdate.Price = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Masukan Stock yang baru : ");
    productToUpdate.Stock = Convert.ToInt32(Console.ReadLine());

    Product result = productsDAL.Update(productToUpdate);
    Console.WriteLine($"Data Product : {result.ProductId} - {result.ProductName} berhasil diupdate !");
}

var products = productsDAL.GetProducsWithCategory();
Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("ProductId\tProductName\tCategoryName\tPrice\t\tStock");
foreach (Product product in products)
{
    Console.WriteLine($"{product.ProductId.ToString().PadLeft(9)}\t{product.ProductName}\t{product.Category.CategoryName.ToString().PadLeft(12)}\t{string.Format("{0:N0}", product.Price)}\t{product.Stock.ToString()}");
}
Console.WriteLine("-----------------------------------------------------------");

