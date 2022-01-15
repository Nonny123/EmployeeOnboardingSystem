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
        Task<Response<string>> DeleteEmployeeAsync(long employeeId);
        Task<Response<IEnumerable<Employee>>> GetAllEmployeesAsync();
        Task<Response<Employee>> GetEmployeeByIdAsync(long employeeId);
        Task<Response<IEnumerable<Employee>>> SearchEmployeeAsync(string searchTerm);
        Task<Response<string>> UpdateEmployeeAsync(long employeeId, UpdateEmployeeDto employeeDto);
        Task<Response<string>> UpdateEmployeeAvatarAsync(long employeeId, string avatar);
    }
}
