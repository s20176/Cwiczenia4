using System;
using System.Data.SqlClient;
using Zad1.Configuration;

namespace Zad1.Services
{
    public class ProductWarehouseService : IProductWarehouseService
    {
        public bool checkIfOrderExists(int IdOrder)
        {
            using (var con = new SqlConnection(Settings.connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Product_Warehouse WHERE IdOrder=@param1", con);
                command.Parameters.AddWithValue("@param1", IdOrder);
                con.Open();
                var dr = command.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
            }
            return false;
        }

        public int insertNewRecord(int IdWarehouse, int IdProduct, int IdOrder, int Amount, double Price)
        {
            using (var con = new SqlConnection(Settings.connectionString))
            {
                var com = new SqlCommand($"INSERT INTO Product_Warehouse (IdWarehouse,IdProduct,IdOrder,Amount,Price,CreatedAt) VALUES (@param1,@param2,@param3,@param4,@param5,@param6);SELECT SCOPE_IDENTITY();", con);
                com.Parameters.AddWithValue("@param1", IdWarehouse);
                com.Parameters.AddWithValue("@param2", IdProduct);
                com.Parameters.AddWithValue("@param3", IdOrder);
                com.Parameters.AddWithValue("@param4", Amount);
                com.Parameters.AddWithValue("@param5", Price);
                DateTime now = DateTime.Now;
                com.Parameters.AddWithValue("@param6", now);
                con.Open();
                int primaryKey = Convert.ToInt32(com.ExecuteScalar());
                return primaryKey;
            }
        }
    }
}
