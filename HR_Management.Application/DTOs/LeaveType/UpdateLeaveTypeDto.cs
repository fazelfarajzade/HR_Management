using HR_Management.Application.DTOs.Common;

namespace HR_Management.Application.DTOs.LeaveType
{
    public class UpdateLeaveTypeDto : BaseDto
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
