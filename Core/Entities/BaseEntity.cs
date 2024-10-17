
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }

        [Required]
        public  DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt {  get; set; } 
    }

}
