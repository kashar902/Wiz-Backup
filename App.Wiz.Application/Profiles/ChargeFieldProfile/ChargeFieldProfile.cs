using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.ChargeFieldViewModels;
using App.Wiz.Domain.ServiceDtos.ChargeFieldDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Profiles.ChargeFieldProfile
{
    public class ChargeFieldProfile
    {
        public static ChargeFieldViewModel PrepareToViewModel(ChargeField entity)
        {
            return new()
            {
                ChargeFieldId = entity.Id,
                ChargeTypeId = entity.ChargeTypeId,
                IsReadOnly = entity.IsReadOnly,
                IsRoundOff = entity.IsRoundOff,
                IsPercent = entity.IsPercent,
                Title = entity.Title,
                ChargeType = entity.ChargeType?.Name,
                Code = entity.Code,
                Description = entity.Description,
                FieldType = entity.FieldType?.Name,
                FieldTypeId = entity.FieldTypeId,
                Position = entity.Position,
            };
        }
        public static ChargeField PrepareToEntity(CreateChargeFieldDto dto)
        {
            return new()
            {
                CreatedBy = Global.Username,
                ModifiedBy = Global.Username,
                ModifiedDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                IsRoundOff = dto.IsRoundOff,
                IsReadOnly = dto.IsReadOnly,
                IsPercent = dto.IsPercent,
                FieldTypeId = dto.FieldTypeId,
                Code = dto.Code,
                ChargeTypeId = dto.ChargeTypeId,
                Description = dto.Description,
                Position = dto.Position,
                Title = dto.Title,
            };
        }
        public static ChargeField PrepareToEntity(UpdateChargeFieldDto dto, ChargeField entity)
        {
            entity.ModifiedBy = Global.Username;
            entity.ModifiedDate = DateTime.UtcNow;
            entity.ChargeTypeId = dto.ChargeTypeId;
            entity.Code = dto.Code;
            entity.FieldTypeId = dto.FieldTypeId;
            entity.IsPercent = dto.IsPercent;
            entity.IsReadOnly = dto.IsReadOnly;
            entity.IsRoundOff = dto.IsRoundOff;
            entity.Description = dto.Description;
            entity.Position = dto.Position;
            entity.Title = dto.Title;
            return entity;
        }
    }
}
