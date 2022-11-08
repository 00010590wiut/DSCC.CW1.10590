using Microservices_API.Models;

namespace Microservices_API.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal> GetAnimalByID(int ID);
        Task<Animal> InsertAnimal(Animal objAnimal);
        Task<Animal> UpdateAnimal(Animal objAnimal);
        bool DeleteAnimal(int ID);
    }
}
