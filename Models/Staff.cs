using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_API.Models
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        public int IDstaff { get; set; }
        [MinLength(1)]
        public string Name { get; set; }
        [MinLength(1)]
        public string Last_Name { get; set; }
        [MinLength(1)]
        public string Middle_Name { get; set; }
        public int Age { get; set; }
        [MinLength(1)]
        public string Position { get; set; }
    }
}
