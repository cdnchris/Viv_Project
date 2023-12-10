using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viv.Dal.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyCode {  get; set; }
        [Required]
        public string CompanyDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
