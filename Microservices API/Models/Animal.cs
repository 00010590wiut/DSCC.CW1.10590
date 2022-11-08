using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices_API.Models
{
    [Table("Animals")]
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; }
    }
}
