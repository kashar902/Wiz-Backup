using App.Wiz.Application.Profiles.FormulaBuilderProfiles;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.FormulaBuilderResponse;
using App.Wiz.Domain.Repositories.FormulaBuilderRepository;
using App.Wiz.Domain.Repositories.FormulaChargeFieldRepository;
using App.Wiz.Domain.ServiceDtos.FormulaBuilderDtos;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.FormulaBuilderServices;

public class FormulaBuilderService : IFormulaBuilderService
{
    private readonly IFormulaBuilderRepository _repo;
    private readonly IFormulaChargeFieldRepository _formulaChargeFieldRepository;

    public FormulaBuilderService(IFormulaBuilderRepository repo, IFormulaChargeFieldRepository formulaChargeFieldRepository)
    {
        _repo = repo;
        _formulaChargeFieldRepository = formulaChargeFieldRepository;
    }

    public async Task<ServiceResponse> AddAsync(CreateFormulaBuilderDto dto)
    {
        FormulaBuilder entity = FormulaBuilderProfiles.PrepareToEntity(dto);
        FormulaBuilder? formulaBuilder = await _repo.AddAsync(entity);
        if (formulaBuilder is null)
        {
            return ServiceResponse.Failure(Constants.AddUnsuccessful);
        }
        List<FormulaChargeFields> entities = new();
        foreach (ChargeFieldDtoId item in dto.ChargeFieldIds)
        {
            entities.Add(new() { FormulaId = formulaBuilder.Id, ChargeFieldId = item.Id });
        }
        await _formulaChargeFieldRepository.AddAsync(entities);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        FormulaBuilder? formilaBuilder = await _repo.GetAsync(x => x.Id == id);
        if (formilaBuilder is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        await _repo.DeleteAsync(formilaBuilder);

        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }

    public async Task<ServiceResponse> GetAsync()
    {
        IList<FormulaBuilder>? formilaBuilders = await _repo.GetAllAsync();
        List<FormulaBuilderResponse> response = new();
        foreach (FormulaBuilder formilaBuilder in formilaBuilders)
        {
            var res = FormulaBuilderProfiles.PrepareToViewModel(formilaBuilder);
            IList<FormulaChargeFields> formulaBuilder = await _formulaChargeFieldRepository.
                GetAllAsync(x => x.FormulaId == formilaBuilder.Id);

            List<FormulaBuilderChargeFieldDtoId> ids = new();
            foreach (FormulaChargeFields item in formulaBuilder)
            {
                ids.Add(new FormulaBuilderChargeFieldDtoId()
                {
                    Id = item.ChargeFieldId
                });
            }
            res.ChargeFieldIds = ids;
            response.Add(res);
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, response);
    }

    public async Task<ServiceResponse> GetAsync(int id)
    {
        FormulaBuilder? formilaBuilder = await _repo.GetAsync(x => x.Id == id);
        if (formilaBuilder is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

            FormulaBuilderResponse response = FormulaBuilderProfiles.PrepareToViewModel(formilaBuilder);
            IList<FormulaChargeFields> formulaBuilder = await _formulaChargeFieldRepository.GetAllAsync(x => x.FormulaId == id);
            List<FormulaBuilderChargeFieldDtoId> ids = new();
            foreach (FormulaChargeFields item in formulaBuilder)
            {
                ids.Add(new FormulaBuilderChargeFieldDtoId()
                {
                    Id = item.ChargeFieldId
                });
            }
            response.ChargeFieldIds = ids;
        return ServiceResponse.Success(Constants.LoadDataSuccess, response);
    }

    public async Task<ServiceResponse> UpdateAsync(UpdateFormulaBuilderDto dto)
    {
        FormulaBuilder? formulaBuilder = await _repo.GetAsync(x => x.Id == dto.FormulaId);
        if (formulaBuilder is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }
        FormulaBuilder entity = FormulaBuilderProfiles.PrepareToEntity(dto, formulaBuilder);
        await _repo.UpdateAsync(entity);

        List<FormulaChargeFields> entities = new();
        IList<FormulaChargeFields> bridgeTableItems = await _formulaChargeFieldRepository.GetAllAsync(x => x.FormulaId == dto.FormulaId);
        await _formulaChargeFieldRepository.DeleteAsync(bridgeTableItems.ToList());
        foreach (ChargeFieldDtoId item in dto.ChargeFieldIds)
        {
            entities.Add(new() { FormulaId = dto.FormulaId, ChargeFieldId = item.Id });
        }
        await _formulaChargeFieldRepository.AddAsync(entities);

        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }
}
