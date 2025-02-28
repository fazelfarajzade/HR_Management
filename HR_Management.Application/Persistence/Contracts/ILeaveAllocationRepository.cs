using HR_Management.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync();
        Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id);
    }
}
