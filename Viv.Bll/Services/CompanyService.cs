using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viv.Bll.DataTransferObjects;
using Viv.Dal;

namespace Viv.Bll.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly IEmployeeRepository _employeeRepo;
        public CompanyService(ICompanyRepository companyRepo, IEmployeeRepository employeeRepo) 
        {
            _companyRepo = companyRepo;
            _employeeRepo = employeeRepo;
        }

        public async Task<IEnumerable<CompanyHeader>> GetCompaniesAsync()
        {
            var result = (await _companyRepo.GetAllAsync())
                .Select(x => new CompanyHeader
                {
                    Code = x.CompanyCode,
                    Description = x.CompanyDescription,
                    Id = x.Id,
                    EmployeeCount = x.Employees.Count()
                });

            return result;
        }

        public async Task<CompanyDTO> GetCompany(int id)
        {
            var record = await _companyRepo.GetByIdAsync(id);
            if(record is null)
            {
                return null;
            }

            var result = new CompanyDTO
            {
                Id = record.Id,
                Code = record.CompanyCode,
                Description = record.CompanyDescription,
                EmployeeCount = record.Employees.Count(),
                Employees = record.Employees
                    .Select(x => new EmployeeHeader
                    {
                        EmployeeNumber = x.EmployeeNumber,
                        FullName = $"{x.EmployeeFirstName} {x.EmployeeLastName}"
                    })
            };
            return result;
        }

        public async Task<EmployeeDTO> GetEmployee(int companyId, string employeeNumber)
        {
            var record = await _employeeRepo.GetByIdAsync(companyId, employeeNumber);
            if(record is null)
            {
                return null;
            }

            var emp = new EmployeeDTO
            {
                Department = record.EmployeeDepartment,
                Email = record.EmployeeEmail,
                EmployeeNumber = record.EmployeeNumber,
                FullName = $"{record.EmployeeFirstName} {record.EmployeeLastName}",
                HireDate = record.HireDate == null ? (DateTime?)null : DateTime.Parse(record.HireDate),
                Managers = GetManagers(record.ManagerEmployee)
            };

            return emp;
        }

        private IEnumerable<EmployeeHeader> GetManagers(Dal.Entities.Employee employee)
        {
            List<EmployeeHeader> results = new List<EmployeeHeader>();

            if(employee.ManagerEmployee != null)
            {
                var mgr = employee.ManagerEmployee;
                results.AddRange(GetManagers(mgr));
            }

            return results;
        }
    }
}
