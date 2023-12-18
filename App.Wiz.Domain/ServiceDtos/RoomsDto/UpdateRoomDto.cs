using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.RoomsDto;

public class UpdateRoomDto : UpdateDtoBaseEntities
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? RoomName { get; set; }
    [MaxLength(50, ErrorMessage = "Description must not exceed 50 characters.")]
    public string? Description { get; set; }
}