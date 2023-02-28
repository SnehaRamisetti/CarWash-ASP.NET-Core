using CaseStudyOnCarWash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
    public interface IOrder
    {
        Task<List<Orderdetails>> GetAllOrdersDetails();

        Task<Orderdetails> GetOrdersById(int id);

        Task<Orderdetails> AddOrders(Orderdetails order);

        Task<Orderdetails> UpdateOrders(int id, Orderdetails order);

        Task DeleteOrders(int id);
    }
}
