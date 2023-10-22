using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_API.Models
{
    [Table("Medicine")]
    public class Medicine
    {
        [Key]
        public int IDmed { get; set; }
        [MinLength(1)]
        public string Name { get; set; }
        public string Producer { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Expiration_Date { get; set; }
    }
}
