using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Zad1.Configuration;
using Zad1.Models;

namespace Zad1.Services
{
    public class OrderService : IOrderService
    {
        public void completeOrder(int IdOrder)
        {
            using (var con = new SqlConnection(Settings.connectionString))
            {
                var com = new SqlCommand($"UPDATE [Order] SET FulfilledAt=@param1", con);
                DateTime now=DateTime.Now;
                com.Parameters.AddWithValue("@param1",now);
                con.Open();
                com.ExecuteNonQuery();
            }
        }

        public Order getOrder(int IdProduct, int Amount, DateTime CreatedAt)
        {
            Order result = null;
            using (var con = new SqlConnection(Settings.connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM [Order] WHERE IdProduct=@param1 AND Amount=@param2 AND CreatedAt<@param3", con);
                command.Parameters.AddWithValue("@param1", IdProduct);
                command.Parameters.AddWithValue("@param2", Amount);
                command.Parameters.AddWithValue("@param3", CreatedAt);
                con.Open();
                var dr = command.ExecuteReader();
                if (dr.Read())
                {
                    result = new Order
                    {
                        IdOrder = int.Parse(dr["IdOrder"].ToString()),
                        IdProduct = int.Parse(dr["IdProduct"].ToString()),
                        Amount = int.Parse(dr["Amount"].ToString()),
                        CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                    };
                    if (!dr.IsDBNull(4))
                    {
                        DateTime d = dr.GetDateTime(4);
                        result.FullfilledAt = d;
                    }
                }
            }
            return result;
        }
    }
}
