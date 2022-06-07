using System.Data.SqlClient;
using Zad1.Configuration;
using Zad1.Models;

namespace Zad1.Services
{
    public class ProductService : IProductService
    {
        public Product getProductById(int IdProduct)
        {
            Product result = null;
            using (var con = new SqlConnection(Settings.connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Product WHERE IdProduct=@param1", con);
                command.Parameters.AddWithValue("@param1", IdProduct);
                con.Open();
                var dr = command.ExecuteReader();
                if (dr.Read())
                {
                    result = new Product
                    {
                        IdProduct = int.Parse(dr["IdProduct"].ToString()),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Price = double.Parse(dr["Price"].ToString())
                    };
                }
            }
            return result;
        }
    }
}
