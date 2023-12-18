using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.ControlAccountViewModels;
using App.Wiz.Domain.ServiceDtos.ControlAccountDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Profiles.ControlAccountProfiles
{
    public static class ControlAccountMapper
    {
        public static ControlAccountViewModel ToControlAccountViewModel(AccControlAccount request)
        {
            request.AccountCode = request != null ? request.AccountCode.Remove(0, 1) : "";
            return new()
            {
                AccountCode = request.AccountCode,
                ControlAccountId = request.ID.ToString(),
                IsActive = request.IsActive,
                ParentAccountId = request.ParentAccountId,
                SuperTypeId = request.SuperTypeId,
                SuperTypeName = request.SuperType.Name,
                Title = request.Title,
            };
        }

        public static AccControlAccount ToAccControlAccount(CreateControlAccountDto request)
        {
            return new()
            {
                ID = Guid.NewGuid(),
                AccountCode = "1" + request.AccountCode,
                CreatedBy = Global.Username,
                ModifiedBy = Global.Username,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsActive = request.IsActive,
                ParentAccountId = request.ParentAccountId,
                SuperTypeId = request.SuperTypeId,
                Title = request.Title
            };
        }
        public static AccControlAccount ToAccControlAccount(UpdateControlAccountDto request, AccControlAccount previous)
        {
            previous.ModifiedBy = Global.Username;
            previous.ModifiedDate = DateTime.UtcNow;
            previous.Title = request.Title;
            previous.ParentAccountId = request.ParentAccountId;
            previous.AccountCode = "1" + request.AccountCode;
            previous.SuperTypeId = request.SuperTypeId;
            previous.IsActive = request.IsActive;
            return previous;
        }
    }
}
