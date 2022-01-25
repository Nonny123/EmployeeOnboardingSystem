using Onboarding.Domain.DTOs;
using Onboarding.Domain.Entities;
using OnBoarding.Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Interfaces
{
    public interface IEmployeeService
    {
        Task<Response<string>> AddEmployeeAsync(EmployeeDto employee);
        Task<Response<string>> DeleteEmployeeAsync(string employeeId);
        Task<Response<IEnumerable<EmployeeResponseDto>>> GetAllEmployeesAsync();
        Task<Response<EmployeeResponseDto>> GetEmployeeByIdAsync(string employeeId);
        Task<Response<IEnumerable<EmployeeResponseDto>>> SearchEmployeeAsync(string searchTerm);
        Task<Response<Employee>> UpdateEmployeeAsync(string employeeId, UpdateEmployeeDto employeeDto);
        Task<Response<Employee>> UpdateEmployeeAvatarAsync(string employeeId, string avatar);
    }
}
