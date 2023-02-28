using CaseStudyOnCarWash.Models;
using CaseStudyOnCarWash.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrder _IOrder;


        public OrderController(IOrder IOrder)
        {
            _IOrder = IOrder;

        }


        //Get method to retrive all theOrder details
        #region
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {

            var Orders = await _IOrder.GetAllOrdersDetails();
            if (Orders == null)
            {
                return NotFound();
            }

            return Ok(Orders);
        }
        #endregion
        //Get the Order details using id
        #region

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var Order = await _IOrder.GetOrdersById(id);
            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }
        #endregion



        //To add the Order
        #region
        [HttpPost]
        public async Task<IActionResult> AddOrderDetails(Orderdetails Order)
        {
            if (Order == null)
            {
                return BadRequest();
            }
            var add = await _IOrder.AddOrders(Order);
            return Ok(new
            {
                Message = " Order placed successfully"
            });

        }
        #endregion



        //To update the details of existing  User
        #region
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Orderdetails Order)
        {
            var orders = await _IOrder.UpdateOrders(id, Order);
            return Ok(new
            {
                Message = "Updated order Details successfully"
            });
        }
        #endregion
        //To delete the Customer Details
        #region
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            await _IOrder.DeleteOrders(id);
            return Ok(new
            {
                Message = "Deleted Order Details successfully"
            });
        }
        #endregion
    }
}
