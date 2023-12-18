using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos.CustomerTypeDto;
using UserAssociates.Business.Logic.CutomerTypeBusinessLogic;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        private readonly ICustomerTypeLogic _customerTypeLogic;
        public CustomerTypeController(ICustomerTypeLogic customerTypeLogic)
        {
            _customerTypeLogic = customerTypeLogic;
        }

        [HttpGet("Get")]
        public async Task<ActionResult> Get()
        {
            try
            {
                List<CustomerType> value = await _customerTypeLogic.GetAllCustomerTypes();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get/{Id}")]
        public async Task<ActionResult> Get(int Id)
        {
            try
            {
                CustomerTypeViewModel? value = await _customerTypeLogic.GetCustomerType(Id);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CreateCustomerTypeDto model)
        {
            try
            {
                string value = await _customerTypeLogic.CreateCustomerType(model);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerTypeDto model)
        {
            try
            {
                string value = await _customerTypeLogic.UpdateCustomerType(model);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                string value = await _customerTypeLogic.DeleteCustomerType(Id);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
