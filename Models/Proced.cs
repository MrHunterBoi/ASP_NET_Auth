using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_API.Models
{
    [Table("Proced")]
    public class Proced
    {
        [Key]
        public int IDproc { get; set; }

        public int? Patient_ID { get; set; }
        public int? Equipment_ID { get; set; }
        public int? Staff_ID { get; set; }
        public int? Medicine_ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
