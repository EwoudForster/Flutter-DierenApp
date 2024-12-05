using Dieren.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieren.DAL.Dtos
{
    public class DierDto
    {
        [Key]
        [Column("DierId")]
        public int DierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
