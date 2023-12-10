using System;

namespace Viv.Bll.Models
{
    public class DataImportInfo
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyDescription { get; set;}
        public string EmployeeNumber { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeDepartment { get; set; }
        public DateTime? HireDate { get; set; }
        public string ManagerEmployeeNumber { get; set; }
    }
}
