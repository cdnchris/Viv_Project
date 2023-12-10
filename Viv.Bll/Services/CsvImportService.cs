using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Viv.Bll.Models;
using Viv.Dal;
using Viv.Dal.Entities;

namespace Viv.Bll.Services
{
    public class CsvImportService : DataImportService
    {
        public CsvImportService(ICompanyRepository companyRepo, IEmployeeRepository employeeRepo)
            : base(companyRepo, employeeRepo) { }

        public override async Task ImportDataAsync(byte[] fileData)
        {
            IEnumerable<DataImportInfo> importData;

            using(var ms = new MemoryStream(fileData))
            using(var reader =  new StreamReader(ms, true)) 
            using(var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                ms.Seek(0, SeekOrigin.Begin);
                importData = csvReader.GetRecords<DataImportInfo>().ToList();
            }

            var employees = importData
                .Select(x => new Employee
                {
                    Company_Id = x.CompanyId,
                    EmployeeDepartment = x.EmployeeDepartment,
                    EmployeeEmail = x.EmployeeEmail,
                    EmployeeFirstName = x.EmployeeFirstName,
                    EmployeeLastName = x.EmployeeLastName,
                    EmployeeNumber = x.EmployeeNumber,
                    HireDate = x.HireDate?.ToString(), //Conversion issue with Sqlite
                    ManagerEmployeeNumber = x.ManagerEmployeeNumber
                }).ToList();

            var companies = importData
                .GroupBy(x => x.CompanyId)
                .Select(g => g.First())
                .Select(x => new Company
                {
                    CompanyCode = x.CompanyCode,
                    CompanyDescription = x.CompanyDescription,
                    Id = x.CompanyId
                }).ToList();

            await ClearData();

            //PLEASE NOTE: Under normal circumstances I would place the import data in a temporary table or some other store before
            //placing directly in a production table, in the case the data needed to be cleaned/double-checked/etc.
            //Only for the purposes of this activity am I inserting directly into the table.
            await InsertCompanyData(companies);
            await InsertEmployeeData(employees);
        }
    }
}
