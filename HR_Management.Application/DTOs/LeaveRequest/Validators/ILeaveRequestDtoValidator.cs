using FluentValidation;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<IleaveRequestDto>
    {
        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}.");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}.");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) =>
                {
                    return !await leaveTypeRepository.Exits(id);
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
