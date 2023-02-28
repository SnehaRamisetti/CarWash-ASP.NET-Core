using CaseStudyOnCarWash.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
    public class OrdersRepo : IOrder
    {
        private readonly CarDbcontext _cardb;

        //constructor injection
        public OrdersRepo(CarDbcontext cardb)
        {

            _cardb = cardb;

        }
        public async Task<Orderdetails> AddOrders(Orderdetails order)
        {
            try
            {
                var addorder = _cardb.Orderdetails.Add(order);
                await _cardb.SaveChangesAsync();
                return (order);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteOrders(int id)
        {
            try
            {
                var order = await _cardb.Orderdetails.FindAsync(id);
                _cardb.Orderdetails.Remove(order);
                await _cardb.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Orderdetails>> GetAllOrdersDetails()
        {
            try
            {
                var orders = await _cardb.Orderdetails.ToListAsync();
                return orders;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Orderdetails> GetOrdersById(int id)
        {
            try
            {
                var order = await _cardb.Orderdetails.FindAsync(id);
                return order;
            }
            catch
            {
                throw;
            }
        }

        public  async Task<Orderdetails> UpdateOrders(int id, Orderdetails order)
        {
            try
            {
                var update = await _cardb.Orderdetails.FindAsync(id);
                if (update != null)
                {
                    update.WashingInstructions = order.WashingInstructions;
                    update.Date = order.Date;
                    update.status = order.status;
                    update.packagename = order.packagename;
                    update.description = order.description;
                    update.price = order.price;
                    update.city = order.city;
                    update.pincode = order.pincode;


                    await _cardb.SaveChangesAsync();
                }
                return update;
            }
            catch
            {
                throw;
            }
        }
    }
}
