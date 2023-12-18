using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.RoomsDto;

public class CreateRoomDto : CreateDtoBaseEntities
{
    [Required]
    public string? RoomName { get; set; }
    [MaxLength(50, ErrorMessage = "Description must not exceed 50 characters.")]
    public string? Description { get; set; }
}