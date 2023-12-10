using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Viv.Bll;
using Viv.Common.Api;

namespace Viv.Web.Controllers
{
    [RoutePrefix("Companies")]
    public class CompaniesController : ApiController
    {
        [Inject]
        public ICompanyService CompanyService { get; set; }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CompanyHeader>> GetCompanies()
        {
            return await CompanyService.GetCompaniesAsync();
        }

        [HttpGet]
        [Route("{companyId:int}")]
        public async Task<Company> GetCompany(int companyId)
        {
            return await CompanyService.GetCompany(companyId);
        }

        [HttpGet]
        [Route("{companyId:int}/Employees/{employeeNumber}")]
        public async Task<Employee> GetEmployee(int companyId, string employeeNumber)
        {
            return await CompanyService.GetEmployee(companyId, employeeNumber);
        }
    }
}
