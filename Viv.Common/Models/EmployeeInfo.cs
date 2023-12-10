using System;
using System.Collections.Generic;

namespace Viv.Common.Models
{
    public class EmployeeInfo
    {
        public string EmployeeNumber { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeDepartment { get; set; }
        public DateTime? HireDate { get; set; }
        public string ManagerEmployeeNumber { get; set; }
        public int Company_Id { get; set; }

        public IEnumerable<ManagerInfo> Managers { get; set; }
    }
}
