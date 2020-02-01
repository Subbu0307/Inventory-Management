using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using InventoryManagement;
using System.Runtime.CompilerServices;

namespace InventoryManagement.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class InventoriesController : ControllerBase
    {
        private readonly ILogger<InventoriesController> _logger;
        private InventoriesManagementContext context = new InventoriesManagementContext();

        public InventoriesController(ILogger<InventoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("inventories/{id}")]
        public ActionResult GetInventory(int id)
        {

            var allitems = (from item in context.Inventory.AsQueryable()
                            where item.ItemId == id
                            select item).FirstOrDefault();

            return CreatedAtAction(nameof(GetAllInventory), allitems);


        }

        [HttpGet]
        [Route("inventories")]
        public ActionResult GetAllInventory()
        {

            var allitems = (from item in context.Inventory.AsQueryable()
                            select item).ToArray<Inventories>();

            return CreatedAtAction(nameof(GetAllInventory), allitems);

        }


        [HttpPost]
        [Route("inventories")]
        public ActionResult AddInventory(Inventories inventory)
        {

            context.Inventory.Add(inventory);
            context.SaveChanges();

            return CreatedAtAction(nameof(AddInventory), inventory);

        }

        [HttpPut]
        [Route("inventories/{id}")]
        public ActionResult UpdateInventory(int id, Inventories inventory)
        {
          
            var item = context.Inventory.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            
            try
            {
                context.Entry(inventory).State = EntityState.Modified;
                context.SaveChanges();
                return CreatedAtAction(nameof(UpdateInventory), inventory);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

           

        }

        [HttpDelete]
        [Route("inventories/{id}")]
        public ActionResult<Inventories> DeleteInventory(int id)
        {
            try
            {
                var inventory = context.Inventory.Find(id);
                if (inventory == null)
                {
                    return NotFound();
                }

                context.Inventory.Remove(inventory);
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
