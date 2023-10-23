using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_API.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int Uid { get; set; }
        [Required]
        public string UserName { get; set; }
        [MinLength(4)]
        public string Password { get; set; }

        public string getPassword(int uid)
        {
            return Password;
        }
    }
}
