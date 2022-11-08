using Microservices_API.Models;

namespace Microservices_API.Repositories
{
    public interface ISpeciesRepository
    {
        Task<IEnumerable<AnimalSpecies>> GetAnimalSpecies();
        Task<AnimalSpecies> GetAnimalSpeciesByID(int ID);
        Task<AnimalSpecies> InsertAnimalSpecies(AnimalSpecies objSpecies);
        Task<AnimalSpecies> UpdateAnimalSpecies(AnimalSpecies objSpecies);
        bool DeleteAnimalSpecies(int ID);
    }
}
