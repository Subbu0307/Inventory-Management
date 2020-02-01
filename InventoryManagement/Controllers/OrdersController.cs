using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using OrderManagement;
using InventoryManagement;
using System.Runtime.CompilerServices;

namespace OrderManagement.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private OrdersManagementContext context = new OrdersManagementContext();

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("orders/{id}")]
        public ActionResult GetOrders(int Id)
        {

            var allitems = (from item in context.Orders.AsQueryable()
                            where item.ItemId == Id
                            select item).FirstOrDefault();

            return CreatedAtAction(nameof(GetAllOrders), allitems);


        }

        [HttpGet]
        [Route("orders")]
        public ActionResult GetAllOrders()
        {

            var allitems = (from item in context.Orders.AsQueryable()
                            select item).ToArray();

            return CreatedAtAction(nameof(GetAllOrders), allitems);

        }


        [HttpPost]
        [Route("orders")]
        public ActionResult AddOrder(Orders orders)
        {

            context.Orders.Add(orders);
            context.SaveChanges();

            return CreatedAtAction(nameof(AddOrder), orders);

        }

        [HttpPut]
        [Route("orders/{id}")]
        public ActionResult UpdateOrder(int id, Orders orders)
        {
          
            var item = context.Orders.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            
            try
            {
                context.Entry(orders).State = EntityState.Modified;
                context.SaveChanges();
                return CreatedAtAction(nameof(UpdateOrder),orders);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

           

        }

        [HttpDelete]
        [Route("orders/{id}")]
        public ActionResult<Orders> DeleteOrder(int id)
        {
            try
            {
                var Order = context.Orders.Find(id);
                if (Order == null)
                {
                    return NotFound();
                }

                context.Orders.Remove(Order);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                throw;
            }
            

           

        }
    }
}
