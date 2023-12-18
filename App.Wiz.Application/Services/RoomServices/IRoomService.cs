using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.RoomsDto;

namespace App.Wiz.Application.Services.RoomServices;

public interface IRoomService
{
    Task<ServiceResponse> Create(CreateRoomDto dto);
    Task<ServiceResponse> Delete(int id);
    Task<ServiceResponse> Get();
    Task<ServiceResponse> GetById(int id);
    Task<ServiceResponse> Update(UpdateRoomDto dto);
}
