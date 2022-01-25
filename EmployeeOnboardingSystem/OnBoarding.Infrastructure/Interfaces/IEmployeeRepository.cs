using Onboarding.Domain.Entities;
using OnBoarding.Infrastructure.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetEmpByIdAsync(string id);
        Task<Employee> GetEmployeeByEmail(string email);
        Task SaveAsync();
        Task<IEnumerable<Employee>> SearchEmployeeAsync(string searchTerm);
        Task<IEnumerable<Employee>> GetNewEmployeesAsync();
        string UpdateEmployeeAvatar(Employee employee);
    }
}
