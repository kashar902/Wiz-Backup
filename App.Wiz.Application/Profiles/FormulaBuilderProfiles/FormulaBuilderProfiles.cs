using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.FormulaBuilderResponse;
using App.Wiz.Domain.ServiceDtos.FormulaBuilderDtos;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Profiles.FormulaBuilderProfiles;

public static class FormulaBuilderProfiles
{
    internal static FormulaBuilderResponse PrepareToViewModel(FormulaBuilder request)
    {
        return new()
        {
            FormulaId = request.Id,
            FormulaCode = request.Code,
            FormulaTitle = request.Title,
            FormulaDescription = request.Description,
            Formula = request.Formula,
            //EnvironmentVariable = request.EnvVariable,
            //ChargeFieldId = request.ChargeFieldId,
            //ChargeFieldCode = request.ChargeField?.Code,
            //ChargeFieldName = request.ChargeField?.Title
        };
    }

    internal static FormulaBuilder PrepareToEntity(CreateFormulaBuilderDto dto)
    {
        return new()
        {
            //ChargeFieldId = dto.ChargeFieldId,
            Code = dto.FormulaCode,
            Title = dto.FormulaTitle,
            Description = dto.FormulaDescription,
            Formula = dto.Formula,
            //EnvVariable = dto.EnvironmentVariable,
            CreatedBy = Global.Username,
            ModifiedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };
    }

    internal static FormulaBuilder PrepareToEntity(UpdateFormulaBuilderDto dto, FormulaBuilder entity)
    {
        entity.Id = dto.FormulaId;
        entity.Code = dto.FormulaCode;
        entity.Title = dto.FormulaTitle;
        entity.Description = dto.FormulaDescription;
        entity.Formula = dto.Formula;
        //entity.EnvVariable = dto.EnvironmentVariable;
        //entity.ChargeFieldId = dto.ChargeFieldId;
        return entity;
    }
}
