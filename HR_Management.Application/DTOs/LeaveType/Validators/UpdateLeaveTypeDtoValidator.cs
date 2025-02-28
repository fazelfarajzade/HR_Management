using FluentValidation;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<UpdateLeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} is not valid.")
                .MustAsync(async (id, token) =>
                {
                    return !await leaveTypeRepository.Exits(id);

                }).WithMessage("{PropertyName} does not exists.");
        }
    }
}
