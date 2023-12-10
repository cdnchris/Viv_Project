using System;
using System.Collections.Generic;
using Viv.Common.Models;
using Viv.Dal.Entities;

namespace Viv.Dal.Helpers
{
    public static class EntityHelper
    {
        public static EmployeeInfo ToEmployeeInfo(this Employee entity, IEnumerable<ManagerInfo> managers)
        {
            var employee = entity.ToEmployeeInfo();
            employee.Managers = managers;

            return employee;
        }
        public static EmployeeInfo ToEmployeeInfo(this Employee entity)
        {
            return new EmployeeInfo
            {
                Company_Id = entity.Company_Id,
                EmployeeDepartment = entity.EmployeeDepartment,
                EmployeeEmail = entity.EmployeeEmail,
                EmployeeFirstName = entity.EmployeeFirstName,
                EmployeeLastName = entity.EmployeeLastName,
                EmployeeNumber = entity.EmployeeNumber,
                HireDate = entity.HireDate == null ? (DateTime?)null : DateTime.Parse(entity.HireDate),
                ManagerEmployeeNumber = entity.ManagerEmployeeNumber
            };
        }
    }
}
