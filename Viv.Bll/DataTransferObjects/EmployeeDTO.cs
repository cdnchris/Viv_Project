using System;
using System.Collections.Generic;

namespace Viv.Bll.DataTransferObjects
{
    public class EmployeeDTO : EmployeeHeader
    {
        public string Email { get; set; }
        public string Department { get; set; }
        public DateTime? HireDate { get; set; }

        public IEnumerable<EmployeeHeader> Managers { get; set; }
    }
}
