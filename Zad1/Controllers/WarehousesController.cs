using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Zad1.Models;
using Zad1.Services;

namespace Zad1.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehousesController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IWarehouseService _warehouseService;
        private readonly IOrderService _orderService;
        private readonly IProductWarehouseService _productWarehouseService;

        public WarehousesController(IProductService productService,IWarehouseService warehouseService,IOrderService orderService,IProductWarehouseService productWarehouseService)
        {
            _productService = productService;
            _warehouseService = warehouseService;
            _orderService = orderService;
            _productWarehouseService = productWarehouseService;
        }

        [HttpPost]
        public IActionResult registerProduct(ProductWarehouse productWarehouse)
        {
            
                Product product = _productService.getProductById(productWarehouse.IdProduct);
                if (product == null)
                {
                    return NotFound("Nie istnieje produkt o podanym id");
                }
                Warehouse warehouse = _warehouseService.getWarehouseById(productWarehouse.IdWarehouse);
                if (warehouse == null)
                {
                    return NotFound("Nie istnieje hurtownia o podanym id");
                }
            Order order = _orderService.getOrder(productWarehouse.IdProduct,productWarehouse.Amount,productWarehouse.CreatedAt);
            if (order == null)
            {
                return NotFound("Nie znaleziono zamówienia");
            }
            bool orderCompleted = _productWarehouseService.checkIfOrderExists(order.IdOrder);
            if (orderCompleted)
            {
                return BadRequest("Zamówienie zostało już zrealizowane");
            }
            _orderService.completeOrder(order.IdOrder);
            double totalPrice = product.Price * order.Amount;
            int primaryKey=_productWarehouseService.insertNewRecord(warehouse.IdWarehouse,product.IdProduct,order.IdOrder,order.Amount,totalPrice);
                return Ok(primaryKey);
            
        }
    }
}
