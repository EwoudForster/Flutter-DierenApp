using Dieren.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieren.DAL.Dtos
{
    public class UserDto
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Dier>? Dieren { get; set; }
    }

}
