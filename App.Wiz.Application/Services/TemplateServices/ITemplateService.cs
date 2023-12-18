using App.Wiz.Common.Enums;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.TemplateDtos;

namespace App.Wiz.Application.Services.TemplateServices;

public interface ITemplateService
{
    Task<ServiceResponse> Create(CreateTemplateDto dto);
    Task<ServiceResponse> GetAll(int templateTypeId);
    Task<ServiceResponse> UpdateTemplate(UpdateTemplateDto dto);
    Task<ServiceResponse> DeleteTemplate(int templateId);
    Task<ServiceResponse> GetById(int templateId, int templateTypeId);
}