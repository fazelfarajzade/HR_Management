using HR_Management.Application.DTOs.Common;

namespace HR_Management.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApproveDto : BaseDto
    {
        public bool? Approved { get; set; }
    }
}
