using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos.VoucherType;
using UserAssociates.Business.Logic.VoucherTypeBusinessLogic;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherTypeController : ControllerBase
    {
        private readonly IVoucherTypeBusinessLogic _voucherTypeLogic;
        public VoucherTypeController(IVoucherTypeBusinessLogic voucherTypeLogic)
        {
            _voucherTypeLogic = voucherTypeLogic;
        }

        [HttpGet("Get")]
        public async Task<ActionResult> Get()
        {
            try
            {
                List<VoucherType> value = await _voucherTypeLogic.GetAllVoucherTypes();
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
                VoucherTypeViewModel? value = await _voucherTypeLogic.GetVoucherType(Id);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CreateVoucherTypeDto model)
        {
            try
            {
                string value = await _voucherTypeLogic.CreateVoucherType(model);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateVoucherTypeDto model)
        {
            try
            {
                string value = await _voucherTypeLogic.UpdateVoucherType(model);
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
                string value = await _voucherTypeLogic.DeleteVoucherType(Id);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
