using System;
using System.Collections.Generic;
using Zad1.Models;

namespace Zad1.Services
{
    public interface IOrderService
    {
        public Order getOrder(int IdProduct, int Amount, DateTime CreatedAt);
        public void completeOrder(int IdOrder);
    }
}
