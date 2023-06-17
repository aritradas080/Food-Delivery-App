using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.ModelDTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public string Tokens { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ExpTime { get; set; }

        public int UId { get; set; }
        public string Role { get; set; }
    }
}

