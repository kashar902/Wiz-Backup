using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.RoomViewModels;
using App.Wiz.Domain.Repositories.RoomRepository;
using App.Wiz.Domain.ServiceDtos.RoomsDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.RoomServices;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repository;
    public RoomService(IRoomRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse> Get()
    {
        IList<Room> rooms = await _repository.GetAllAsync();
        List<RoomViewModel> viewModel = new();
        foreach (Room room in rooms)
        {
            viewModel.Add(MapModelToViewModel(room));
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, viewModel);
    }
    public async Task<ServiceResponse> GetById(int id)
    {
        Room? room = await _repository.GetAsync(x => x.ID == id);
        if (room is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        RoomViewModel roomViewModel = MapModelToViewModel(room);
        return ServiceResponse.Success(Constants.LoadDataSuccess, roomViewModel);
    }
    public async Task<ServiceResponse> Delete(int id)
    {
        Room? room = await _repository.GetAsync(x => x.ID == id);
        if (room is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        await _repository.DeleteAsync(room);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }
    public async Task<ServiceResponse> Update(UpdateRoomDto dto)
    {
        Room? room = await _repository.GetAsync(x => x.ID == dto.Id);
        if (room is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        room.Description = dto.Description;
        room.RoomName = dto.RoomName;
        room.ModifiedBy = Global.Username;
        room.ModifiedDate = DateTime.UtcNow;
        await _repository.UpdateAsync(room);
        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }
    public async Task<ServiceResponse> Create(CreateRoomDto dto)
    {
        Room room = new()
        {
            RoomName = dto.RoomName,
            Description = dto.Description,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            ModifiedBy = Global.Username
        };

        _ = await _repository.AddAsync(room);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }
    private static RoomViewModel MapModelToViewModel(Room room)
    {
        return new RoomViewModel
        {
            ID = room.ID,
            Description = room.Description,
            RoomName = room.RoomName
        };
    }
}
