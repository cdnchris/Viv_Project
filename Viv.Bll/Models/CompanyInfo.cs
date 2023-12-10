using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viv.Bll.Models
{
    public class CompanyInfo
    {
        public int Id { get; set; }
        public string CompanyCode {  get; set; }
        public string CompanyDescription { get; set; }
    }
}
