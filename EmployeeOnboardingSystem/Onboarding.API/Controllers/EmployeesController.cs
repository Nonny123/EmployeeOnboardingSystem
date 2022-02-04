using Microsoft.AspNetCore.Mvc;
using Onboarding.Domain.DTOs;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto employee)
        {
            var result = await _employeeService.AddEmployeeAsync(employee);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var result = await _employeeService.GetAllEmployeesAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> Employees(string employeeId)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(employeeId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> SearchEmployeeAsync(string searchTerm)
        {
            var result = await _employeeService.SearchEmployeeAsync(searchTerm);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync(string employeeId)
        {
            var result = await _employeeService.DeleteEmployeeAsync(employeeId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAvatarAsync(string employeeId, string avatar)
        {
            var result = await _employeeService.UpdateEmployeeAvatarAsync(employeeId, avatar);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync(string employeeId, UpdateEmployeeDto employeeDto)
        {
            var result = await _employeeService.UpdateEmployeeAsync(employeeId, employeeDto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
