using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viv.Dal.Entities
{
    public class Employee
    {
        public string EmployeeNumber { get; set; }
        [Required]
        public string EmployeeFirstName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        [Required]
        public string EmployeeDepartment { get; set; }
        public string HireDate { get; set; } //Stored as string in Sqlite, couldn't resolve a conversion error
        public string ManagerEmployeeNumber { get; set; }
        public int Company_Id { get; set; }


        [ForeignKey("Company_Id")]
        public virtual Company Company { get; set; }
        [ForeignKey("ManagerEmployeeNumber, Company_Id")]
        public virtual Employee ManagerEmployee { get; set; }
    }
}
