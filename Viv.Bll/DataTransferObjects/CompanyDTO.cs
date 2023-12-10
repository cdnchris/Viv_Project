using System.Collections.Generic;

namespace Viv.Bll.DataTransferObjects
{
    public class CompanyDTO : CompanyHeader
    {
        public IEnumerable<EmployeeHeader> Employees { get; set; }
    }
}
