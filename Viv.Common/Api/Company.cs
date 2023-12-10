using System.Collections.Generic;

namespace Viv.Common.Api
{
    public class Company : CompanyHeader
    {
        public IEnumerable<EmployeeHeader> Employees { get; set; }
    }
}
