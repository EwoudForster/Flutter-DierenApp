using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dieren.DAL.Models
{
    public class Dier
    {
        [Key]
        [Column("DierenId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        [JsonIgnore]
        public ICollection<User>? Users { get; set; }

    }
}
