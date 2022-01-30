using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.Entities;
using OnBoarding.Infrastructure.AppDbContext;
using OnBoarding.Infrastructure.Interfaces;
using OnBoarding.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly OnBoardingDbContext _context;
        public EmployeeRepository(OnBoardingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> SearchEmployeeAsync(string searchTerm)
        {
            var employee = await _context.Employees.Where(x => x.WorkEmail == searchTerm
                                                     || x.Designation == searchTerm
                                                     || x.Department == searchTerm
                                                     || x.EmploymentStatus == searchTerm)
                                                    .Include(x => x.User)
                                                    .ToListAsync();

            return employee;
        }


        public string UpdateEmployeeAvatar(Employee employee)
        {
            _context.Employees.Update(employee);
            return "success";
        }


        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            var employee = await _context.Employees
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.WorkEmail == email);
            return employee;
        }

        public async Task<Employee> GetEmpByIdAsync(string id)
        {
            var employee = await _context.Employees
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.EmployeeId == id);
            return employee;
        }

        public new async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employee = await _context.Employees
                .Include(x => x.User).ToListAsync();
            return employee;
        }

        public new async Task<IEnumerable<Employee>> GetNewEmployeesAsync()
        {
            var employee = await _context.Employees
                .Include(x => x.User)
                .Where(x => x.EmployeeStartDate >= DateTime.Now.AddDays(-31))
                .ToListAsync();
            return employee;
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
