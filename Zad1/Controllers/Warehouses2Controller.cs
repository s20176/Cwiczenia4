using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using Zad1.Configuration;
using Zad1.Models;

namespace Zad1.Controllers
{
    [ApiController]
    [Route("api/warehouses2")]
    public class Warehouses2Controller : ControllerBase
    {
        [HttpPost]
        public IActionResult registerProduct(ProductWarehouse productWarehouse)
        {
            using (var con = new SqlConnection(Settings.connectionString))
            {
                SqlCommand command = new SqlCommand("AddProductToWarehouse", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("IdProduct",productWarehouse.IdProduct);
                command.Parameters.AddWithValue("IdWarehouse", productWarehouse.IdWarehouse);
                command.Parameters.AddWithValue("Amount", productWarehouse.Amount);
                command.Parameters.AddWithValue("CreatedAt", productWarehouse.CreatedAt);
                con.Open();
                var dr = command.ExecuteReader();
                string a = null;
                if (dr.Read())
                {
                    a = dr["NewId"].ToString();
                }
                return Ok(a);
            }
            
        }
    }
}
