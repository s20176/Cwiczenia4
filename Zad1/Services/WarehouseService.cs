using System.Data.SqlClient;
using Zad1.Configuration;
using Zad1.Models;

namespace Zad1.Services
{
    public class WarehouseService : IWarehouseService
    {
        public Warehouse getWarehouseById(int IdWarehouse)
        {
            Warehouse result = null;
            using (var con = new SqlConnection(Settings.connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Warehouse WHERE IdWarehouse=@param1", con);
                command.Parameters.AddWithValue("@param1", IdWarehouse);
                con.Open();
                var dr = command.ExecuteReader();
                if (dr.Read())
                {
                    result = new Warehouse
                    {
                        IdWarehouse = int.Parse(dr["IdWarehouse"].ToString()),
                        Name = dr["Name"].ToString(),
                        Address = dr["Address"].ToString()
                    };
                }
            }
            return result;
        }
    }
}
