using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_API.Models
{
    [Table("Equipment")]
    public class Equipment
    {
        [Key]
        public int IDeq { get; set; }
        [MinLength(1)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [MinLength(1)]
        public string Manufacturer { get; set; }
    }
}
