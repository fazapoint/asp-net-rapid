using CsvHelper;
using System.Globalization;

using (var reader = new StreamReader("D:\\csv\\RapidDb_Categories.csv"))
{
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var records = csv.GetRecords<>();
    }
}
