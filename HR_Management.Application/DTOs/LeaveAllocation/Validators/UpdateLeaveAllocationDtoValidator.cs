using FluentValidation;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            Include(new ILeaveAllocationDtoValidator(leaveTypeRepository));

            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} is not valid.")
                .MustAsync(async (id, token) =>
                {
                    return !await leaveAllocationRepository.Exits(id);

                }).WithMessage("{PropertyName} does not exists.");
        }
    }
}
