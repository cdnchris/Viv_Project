using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Viv.Bll;
using Viv.Bll.DataTransferObjects;
using Viv.Bll.Services;

namespace Viv.Web.Controllers
{
    public class CompaniesController : ApiController
    {
        [Inject]
        public ICompanyService CompanyService { get; set; }
        //private readonly ICompanyService _companyService;
        //public CompaniesController()
        //{
        //    _companyService = new CompanyService();
        //}

        [HttpGet]
        [Route("Companies")]
        public async Task<IEnumerable<CompanyHeader>> GetCompanues()
        {
            return await CompanyService.GetCompaniesAsync();
        }

        [HttpGet]
        [Route("Companies/{companyId}")]
        public async Task<CompanyDTO> GetCompany(int companyId)
        {
            return await CompanyService.GetCompany(companyId);
        }

        [HttpGet]
        [Route("Companies/{companyId}/Employees/{employeeNumber}")]
        public async Task<EmployeeDTO> GetEmployee(int companyId, string employeeNumber)
        {
            return await CompanyService.GetEmployee(companyId, employeeNumber);
        }
    }
}
