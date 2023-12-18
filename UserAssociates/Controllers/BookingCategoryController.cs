using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos.BookingCategoryDto;
using UserAssociates.Business.Logic.BookingCategoryBusinessLogic;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingCategoryController : ControllerBase
{
    private readonly IBookingCategoryLogic _bookingCategoryLogic;
    public BookingCategoryController(IBookingCategoryLogic bookingCategoryLogic)
    {
        _bookingCategoryLogic = bookingCategoryLogic;
    }

    [HttpGet("Get")]
    public async Task<ActionResult> Get()
    {
        try
        {
            List<BookingCategory> value = await _bookingCategoryLogic.GetAllBookingCategories();
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
            BookingCategoryViewModel? value = await _bookingCategoryLogic.GetBookingCategory(Id);
            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Add")]
    public async Task<ActionResult> Add([FromBody] CreateBookingCategoryDto model)
    {
        try
        {
            string value = await _bookingCategoryLogic.CreateBookingCategory(model);
            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult> Update([FromBody] UpdateBookingCategoryDto model)
    {
        try
        {
            string value = await _bookingCategoryLogic.UpdateBookingCategory(model);
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
            string value = await _bookingCategoryLogic.DeleteBookingCategory(Id);
            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
