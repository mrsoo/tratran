using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeEcommerce.Model.Accounts;
using ShoeEcommerce.Service;

namespace ShoeEcommerce.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private ILoggerService Logger;
        IAccountService Service;

        public AccountsController(IAccountService service, ILoggerService logger)
        {
            this.Service = service;
            this.Logger = logger;
        }
        ////You can have multiple routes on an action
        [Route("")] // Accounts
        [Route("GetAllAccount")] // ABC/GetCus
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var item = await Service.GetAllAccountsAsync();
                return Ok(item);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Some error in the GetAllAccounts method: {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
        //[HttpGet("{id}", Name = "AccountById")]
        [Route("GetAllAccountBy/{id}")]
        [HttpGet("{id}", Name = "AccountById")]
        public async Task<IActionResult> GetAccountById(string id)
        {
            try
            {
                var item = await Service.GetAccountByIdAsync(id);

                if (item == null)
                {
                    Logger.LogError($"Account with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    Logger.LogInfo($"Returned Account with id: {id}");
                    return Ok(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside GetAccountById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [Route("CreateAccount")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody]Account item)
        {
            try
            {
                if (item == null)
                {
                    Logger.LogError("Account object sent from client is null.");
                    return BadRequest("Account object is null");
                }

                if (!ModelState.IsValid)
                {
                    Logger.LogError("Invalid Account object sent from client.");
                    return BadRequest("Invalid model object");
                }

                await Service.CreateAccountAsync(item);

                return CreatedAtRoute("AccountById", new { id = item.idAccount }, item);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CreateAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [Route("UpdateAccount/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(string id, [FromBody]Account item)
        {
            try
            {
                if (item == null)
                {
                    Logger.LogError("Account object sent from client is null.");
                    return BadRequest("Account object is null");
                }

                if (!ModelState.IsValid)
                {
                    Logger.LogError("Invalid Account object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbAccount = await Service.GetAccountByIdAsync(id);
                if (dbAccount == null)
                {
                    Logger.LogError($"Account with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await Service.UpdateAccountAsync(item);

                return NoContent();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UpdateAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [Route("DeleteAccount/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            try
            {
                var item = await Service.GetAccountByIdAsync(id);
                if (item == null)
                {
                    Logger.LogError($"Custoimer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await Service.DeleteAccountAsync(item);

                return NoContent();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside DeleteAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
    }
}