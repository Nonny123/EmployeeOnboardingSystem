using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Onboarding.Domain.DTOs;
using Onboarding.Domain.Entities;
using OnBoarding.Application.Helpers;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UserManager<User> _userManager;
        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _userManager = userManager;
        }

        public async Task<Response<IEnumerable<EmployeeResponseDto>>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var response = _mapper.Map<IEnumerable<EmployeeResponseDto>>(employees);
            return Response<IEnumerable<EmployeeResponseDto>>.Success("success", response);
        }

        public async Task<Response<EmployeeResponseDto>> GetEmployeeByIdAsync(string employeeId)
        {
            var employee = await _employeeRepository.GetEmpByIdAsync(employeeId);
            if (employee == null)
                return Response<EmployeeResponseDto>.Fail("Employee not found");

            var response = _mapper.Map<EmployeeResponseDto>(employee);
            return Response<EmployeeResponseDto>.Success("Success", response);
        }

        public async Task<Response<string>> AddEmployeeAsync(EmployeeDto employee)
        {
            var user = await _userManager.FindByEmailAsync(employee.UserEmail);
            if (user == null)
                return Response<string>.Fail($"User {employee.UserEmail} not found");

            var emp = await _employeeRepository.GetEmployeeByEmail(employee.WorkEmail);
            if (emp != null)
                return Response<string>.Fail($"Email {employee.WorkEmail} already taken/added");

            emp = _mapper.Map<Employee>(employee);
            emp.LastModified = DateTime.UtcNow;
            emp.User = user;

            await _employeeRepository.AddAsync(emp);

            return Response<string>.Success("success", $"Employee with {emp.WorkEmail}\n {emp.Department}\n {emp.EmploymentStatus}... added");
        }

        public async Task<Response<IEnumerable<EmployeeResponseDto>>> SearchEmployeeAsync(string searchTerm)
        {
            if (searchTerm == null)
                return Response<IEnumerable<EmployeeResponseDto>>.Fail("seach cannot be empty");

            var employees = await _employeeRepository.SearchEmployeeAsync(searchTerm);
            var response = _mapper.Map<IEnumerable<EmployeeResponseDto>>(employees);
            return Response<IEnumerable<EmployeeResponseDto>>.Success("success", response);
        }

        public async Task<Response<string>> DeleteEmployeeAsync(string employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
                return Response<string>.Fail("Employee not found");

            await _employeeRepository.DeleteAsync(employee);


            return Response<string>.Success("success", "", 204);
        }

        public async Task<Response<Employee>> UpdateEmployeeAvatarAsync(string employeeId, string avatar)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
                return Response<Employee>.Fail("Employee not found");

            employee.Avatar = avatar;
            await _employeeRepository.UpdateAsync(employee, employee.EmployeeId);

            var response = _mapper.Map<Employee>(employee);
            return Response<Employee>.Success("success", response);
        }

        public async Task<Response<Employee>> UpdateEmployeeAsync(string employeeId, UpdateEmployeeDto employeeDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
                return Response<Employee>.Fail("Employee not found");

            employee = _mapper.Map<Employee>(employeeDto);

            await _employeeRepository.UpdateAsync(employee, employee.EmployeeId);

            var response = _mapper.Map<Employee>(employee);
            return Response<Employee>.Success("success", response);
        }
    }
}
