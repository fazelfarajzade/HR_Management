using FluentValidation;
using HR_Management.Application.Persistence.Contracts;
using System;

namespace HR_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be grater than {ComparisonValue}.");


            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}.");


            RuleFor(p => p.LeaveTypeId)
                .NotNull().WithMessage("{PropertyName} can not be null.")
                .GreaterThan(0).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) =>
                {
                    return !await leaveTypeRepository.Exits(id);

                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
