using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.ModelDTOs
{
    public class MonthlyIncomeDTO
    {
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string month { get; set; }
        [Required]
       
        public int income { get; set; }
    }
}
