using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp
{
    public static class Helper
    {
        public static double HitungLuasSegitiga(double alas, double tinggi)
        {
            return 0.5 * alas * tinggi;
        }

        public static double HitungLuasPersegi(double sisi)
        {
            return sisi * sisi;
        }
    }
}
