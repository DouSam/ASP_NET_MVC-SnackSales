using LanchesC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesC.Repositories.Interfaces
{
    interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
