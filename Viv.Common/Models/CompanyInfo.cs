using System.Collections.Generic;

namespace Viv.Common.Models
{
    public class CompanyInfo
    {
        public int Id { get; set; }
        public string CompanyCode {  get; set; }
        public string CompanyDescription { get; set; }
        public int EmployeeCount { get; set; }

        public IEnumerable<EmployeeInfo> Employees { get; set; }
    }
}
