using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Model.Users;
using ShoeEcommerce.Service;

namespace ShoeEcommerce.Api
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class CustomersController : ControllerBase
    {
        private ILoggerService Logger;
        ICustomerService Service;

        public CustomersController(ICustomerService service,ILoggerService logger)
        {
            this.Service = service;
            this.Logger = logger;
        }
        ////You can have multiple routes on an action
        [Route("")] // Customers
        [Route("GetAllCustomer")] // ABC/GetCus
        [HttpGet]
        public async Task<IActionResult>GetAllCustomers()
        {
            try
            {
                var item = await Service.GetAllCustomersAsync();
                return Ok(item);
            }
            catch(Exception ex)
            {
                Logger.LogError($"Some error in the GetAllCustomers method: {ex}");
                return StatusCode(500, "Internal server error");
            }
            
        }
        //[HttpGet("{id}", Name = "customerById")]
        [Route("GetAllCustomerBy/{id}")]
        [HttpGet("{id}", Name = "customerById")]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            try
            {
                var item = await Service.GetCustomerByIdAsync(id);

                if (item==null)
                {
                    Logger.LogError($"customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    Logger.LogInfo($"Returned customer with id: {id}");
                    return Ok(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside GetcustomerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [Route("CreateCustomer")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody]Customer item)
        {
            try
            {
                if (item == null)
                {
                    Logger.LogError("Customer object sent from client is null.");
                    return BadRequest("Customer object is null");
                }

                if (!ModelState.IsValid)
                {
                    Logger.LogError("Invalid Customer object sent from client.");
                    return BadRequest("Invalid model object");
                }

                await Service.CreateCustomerAsync(item);

                return CreatedAtRoute("CustomerById", new { id = item.idCustomer }, item);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CreateCustomer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [Route("UpdateCustomer/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody]Customer item)
        {
            try
            {
                if (item == null)
                {
                    Logger.LogError("Customer object sent from client is null.");
                    return BadRequest("Customer object is null");
                }

                if (!ModelState.IsValid)
                {
                    Logger.LogError("Invalid Customer object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbCustomer = await Service.GetCustomerByIdAsync(id);
                if (dbCustomer == null)
                {
                    Logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await Service.UpdateCustomerAsync(item);

                return NoContent();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UpdateCustomer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [Route("DeleteCustomer/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
            {
                var item = await Service.GetCustomerByIdAsync(id);
                if (item == null)
                {
                    Logger.LogError($"Custoimer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await Service.DeleteCustomerAsync(item);

                return NoContent();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside DeleteCustomer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}