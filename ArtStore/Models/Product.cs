using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Data;

namespace PetStore.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long id { get; set; }

        public string Name { get; set; }
        public Decimal Price { get; set; }

        public static Product Create(string _name, Decimal _price)
        {
            // Create the new Product instance
            Product prod = new Product() { Name = _name, Price = _price };

            // Save it to the database
            IDbConnection db = new SqlConnection("Server=.;Database=devbuildjoin;user id=sa;password=abc123;");
            long _id = db.Insert<Product>(prod);

            // Set the id column of the instance
            prod.id = _id;

            // Return the instance
            return prod;
        }

        public static Product Read(long _id)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=devbuildjoin;user id=sa;password=abc123;");
            Product prod = db.Get<Product>(_id);
            return prod;
        }

        public static List<Product> Read()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=devbuildjoin;user id=sa;password=abc123;");
            List<Product> prods = db.GetAll<Product>().ToList();
            return prods;
        }

        public static void Delete(long _id)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=devbuildjoin;user id=sa;password=abc123;");
            db.Delete(new Product() { id = _id });
        }

        public void Save()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=devbuildjoin;user id=sa;password=abc123;");
            db.Update(this);
        }
    }
}
