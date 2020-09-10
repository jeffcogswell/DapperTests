using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DapperConsole1
{

    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<OrderDetails> orders;
            using (IDbConnection db = new SqlConnection("Server=.;Database=Northwind;user id=sa;password=abc123"))
            {
                orders = db.Query<OrderDetails>("select top 10 * from [Order Details]").AsList<OrderDetails>();
                foreach (OrderDetails detail in orders)
                {
                    Console.WriteLine($"{detail.OrderId} {detail.ProductId} {detail.Quantity} {detail.UnitPrice} {detail.Discount}");
                }
            }

            Console.WriteLine("All Done");
        }
    }
}
