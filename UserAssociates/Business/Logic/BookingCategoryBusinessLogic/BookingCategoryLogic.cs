using Commons.Messages;
using UserAssociates.Business.Dtos.BookingCategoryDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.BookingCategoryService;

namespace UserAssociates.Business.Logic.BookingCategoryBusinessLogic;

public class BookingCategoryLogic : IBookingCategoryLogic
{

	private readonly IBookingCategoryService _bookingCategoryService;
	public BookingCategoryLogic(IBookingCategoryService bookingCategoryService)
	{
		_bookingCategoryService = bookingCategoryService;
	}
	public async Task<string> CreateBookingCategory(CreateBookingCategoryDto bookingCategoryDto)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(bookingCategoryDto.Description)
				|| string.IsNullOrWhiteSpace(bookingCategoryDto.Title)
				|| bookingCategoryDto.CategoryType == 0)
			{
				return Constants.IsNullValue;
			}
			BookingCategory bookingCategory = new()
			{
				CategoryType = bookingCategoryDto.CategoryType,
				Title = bookingCategoryDto.Title,
				Description = bookingCategoryDto.Description
			};
			_ = await _bookingCategoryService.AddBookingCategory(bookingCategory);
			return Constants.BookingCategory.CreateSuccessfull;
		}
		catch (CustomException)
		{
			throw;
		}
	}
	public async Task<string> UpdateBookingCategory(UpdateBookingCategoryDto updateBookingCategoryDto)
	{
		try
		{
			BookingCategory? bookingCategory = await _bookingCategoryService.GetBookingCategory(updateBookingCategoryDto.Id);
			if (bookingCategory is null)
			{
				return Constants.NotFound;
			}

			if (!string.IsNullOrWhiteSpace(updateBookingCategoryDto.Description))
			{
				bookingCategory.Description = updateBookingCategoryDto.Description;
			}

			if (!string.IsNullOrWhiteSpace(updateBookingCategoryDto.Title))
			{
				bookingCategory.Title = updateBookingCategoryDto.Title;
			}

			if (updateBookingCategoryDto.CategoryType != 0)
			{
				bookingCategory.CategoryType = updateBookingCategoryDto.CategoryType;
			}

			int successCount = await _bookingCategoryService.UpdateBookingCategory(bookingCategory);
			return successCount != 0 ? Constants.BookingCategory.UpdateSuccessfull : Constants.Error;
		}
		catch (CustomException)
		{
			throw;
		}
	}
	public async Task<BookingCategoryViewModel?> GetBookingCategory(int Id)
	{
		try
		{
			BookingCategory? bookingCategory = await _bookingCategoryService.GetBookingCategory(Id);
			if (bookingCategory is null)
			{
				return null;
			}
			BookingCategoryViewModel bookingCategoryViewModel = new()
			{
				CategoryType = bookingCategory.CategoryType,
				Title = bookingCategory.Title,
				Description = bookingCategory.Description,
				Id = Id,
			};
			return bookingCategoryViewModel;
		}
		catch (CustomException)
		{
			throw;
		}
	}
	public async Task<List<BookingCategory>> GetAllBookingCategories()
	{
		try
		{
			return await _bookingCategoryService.GetAllBookingCategories();
		}
		catch (CustomException)
		{
			throw;
		}
	}
	public async Task<string> DeleteBookingCategory(int id)
	{
		try
		{
			BookingCategory? bookingCategory = await _bookingCategoryService.GetBookingCategory(id);
			if (bookingCategory is null)
			{
				return Constants.NotFound;
			}

			int successCount = await _bookingCategoryService.DeleteBookingCategory(bookingCategory);
			return successCount != 0 ? Constants.BookingCategory.DeleteSuccessfull : Constants.Error;
		}
		catch (CustomException)
		{
			throw;
		}
	}
}
