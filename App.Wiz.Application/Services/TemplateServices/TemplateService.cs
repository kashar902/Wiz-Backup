using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.TemplateViewModels;
using App.Wiz.Domain.Repositories.SubsidaryAccountRepository;
using App.Wiz.Domain.Repositories.TemplatesRepositories;
using App.Wiz.Domain.ServiceDtos.TemplateDtos;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.TemplateServices;

public class TemplateService : ITemplateService
{
    private readonly ITemplateTypeRepository _templateTypeRepository;
    private readonly ITemplateRepository _templateRepository;
    private readonly ITemplateFieldsRepository _templateFieldsRepository;
    private readonly ISubsidaryAccountRepository _subsidaryAccountRepository;

    public TemplateService(ITemplateTypeRepository templateTypeRepository,
        ITemplateRepository templateRepository,
        ITemplateFieldsRepository templateFieldsRepository,
        ISubsidaryAccountRepository subsidaryAccountRepository)
    {
        _templateTypeRepository = templateTypeRepository;
        _templateRepository = templateRepository;
        _templateFieldsRepository = templateFieldsRepository;
        _subsidaryAccountRepository = subsidaryAccountRepository;

    }
    public async Task<ServiceResponse> Create(CreateTemplateDto dto)
    {
        Template entity = dto.PrepareToTemplate();

        Template template = await _templateRepository.AddAsync(entity);

        if (template.ID == 0)
        {
            return ServiceResponse.Failure(Constants.AddUnsuccessful);
        }
        List<TemplateField> result = new();
        foreach (CreateTemplateFieldDto createTemplateFieldDtos in dto.CreateTemplateFieldDtos)
        {
            result.Add(createTemplateFieldDtos.PrepareToTemplateField(template.ID));
        }
        await _templateFieldsRepository.AddAsync(result);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }

    public async Task<ServiceResponse> GetAll(int templateTypeId)
    {
        IList<Template>? templates = await _templateRepository.GetAllAsync(
        x => x.TemplateType!,
        x => x.TemplateFields!);

        List<TemplateViewModel>? response = new();
        foreach (Template? template in templates.Where(x => x.TemplateTypeId == templateTypeId))
        {
            response.Add(template.PrepareToViewModel());
        }

        return ServiceResponse.Success(Constants.LoadDataSuccess, response);
    }

    public async Task<ServiceResponse> UpdateTemplate(UpdateTemplateDto dto)
    {
        Template? template = await _templateRepository.GetById(dto.TemplateId);

        if (template is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        // Update the template using the provided DTO
        template = dto.PrepareToTemplate(template);
        await _templateRepository.UpdateAsync(template);

        if (template.TemplateFields?.Any() == true)
        {
            List<TemplateField> results = dto.UpdateTemplateFieldDtos
                .SelectMany(item => item.PrepareToTemplateField(template.TemplateFields!.ToList()))
                .ToList();

            foreach (TemplateField templateField in results)
            {
                await _templateFieldsRepository.UpdateAsync(templateField);
            }
        }

        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }

    public async Task<ServiceResponse> DeleteTemplate(int templateId)
    {
        Template? template = await _templateRepository.GetById(templateId);
        if (template is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        await _templateRepository.DeleteAsync(template);

        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }

    public async Task<ServiceResponse> GetById(int templateId, int templateTypeId)
    {
        Template? template = await _templateRepository.GetById(templateId, templateTypeId);
        if (template is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        TemplateViewModel? master = template.PrepareToViewModel();
        List<TemplateFieldsViewModel?>? list = new();
        foreach (TemplateField TemplateField in template.TemplateFields!)
        {
            TemplateFieldsViewModel perparedModel = TemplateField.PrepareToTemplateFieldsViewModel();
            perparedModel = await PrepareTemplateFieldsViewModel(perparedModel, TemplateField);
            list.Add(perparedModel);
        }
        master.TemplateFields = list;
        return ServiceResponse.Success(Constants.LoadDataSuccess, master);
    }
    private async Task<TemplateFieldsViewModel> PrepareTemplateFieldsViewModel(TemplateFieldsViewModel perparedModel, TemplateField templateField)
    {
        if (!string.IsNullOrWhiteSpace(templateField.CustomerCredit))
        {
            AccSubsidaryAccount? customerCredit = await _subsidaryAccountRepository.GetAsync(x => x.ID == Guid.Parse(templateField.CustomerCredit));
            perparedModel.CustomerCreditName = customerCredit?.Title;

        }
        if (!string.IsNullOrWhiteSpace(templateField.CustomerDebit))
        {
            AccSubsidaryAccount? customerDebit = await _subsidaryAccountRepository.GetAsync(x => x.ID == Guid.Parse(templateField.CustomerDebit));
            perparedModel.CustomerDebitName = customerDebit?.Title;
        }
        if (!string.IsNullOrWhiteSpace(templateField.SupplierCredit))
        {
            AccSubsidaryAccount? supplierCredit = await _subsidaryAccountRepository.GetAsync(x => x.ID == Guid.Parse(templateField.SupplierCredit));
            perparedModel.SupplierCreditName = supplierCredit?.Title;

        }
        if (!string.IsNullOrWhiteSpace(templateField.SupplierDebit))
        {
            AccSubsidaryAccount? supplierDebit = await _subsidaryAccountRepository.GetAsync(x => x.ID == Guid.Parse(templateField.SupplierDebit));
            perparedModel.SupplierDebitName = supplierDebit?.Title;
        }
        return perparedModel;
    }
}