using System.ComponentModel.DataAnnotations;

namespace Microservices_API.Models
{

    public class AnimalSpecies
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
