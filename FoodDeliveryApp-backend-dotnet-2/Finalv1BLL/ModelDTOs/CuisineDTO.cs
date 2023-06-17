using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.ModelDTOs
{
    public class CuisineDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Price_Range { get; set; }
        [Required]
        [StringLength(100)]
        public string Spice_Level { get; set; }
        [Required]
        [StringLength(100)]
        public string Time_To_Prep { get; set; }

        public virtual ICollection<ProductDTO> ProductsDTOs { get; set; }

        public CuisineDTO()
        {
            ProductsDTOs = new List<ProductDTO>();
        }
    }
}
