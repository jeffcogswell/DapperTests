using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DapperConsole2
{

    class Categories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Northwind;user id=sa;password=abc123;");
            db.Open();

            List<Categories> cats = db.Query<Categories>("select * from Categories").AsList<Categories>();

            foreach (Categories cat in cats)
            {
                Console.WriteLine($"{cat.CategoryID} {cat.CategoryName} {cat.Description}");
            }

            db.Close();
        }
    }
}
