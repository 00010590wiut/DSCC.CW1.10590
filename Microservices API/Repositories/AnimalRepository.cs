using Microservices_API.DBContexts;
using Microservices_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices_API.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly APIDBContexts _appDBContext;
        public AnimalRepository(APIDBContexts context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public bool DeleteAnimal(int ID)
        {
            bool result = false;
            var species = _appDBContext.Animals.Find(ID);
            if (species != null)
            {
                _appDBContext.Entry(species).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<Animal> GetAnimalByID(int ID)
        {
            return await _appDBContext.Animals.FindAsync(ID);
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _appDBContext.Animals.ToListAsync();
        }

        public async Task<Animal> InsertAnimal(Animal objAnimal)
        {
            _appDBContext.Animals.Add(objAnimal);
            await _appDBContext.SaveChangesAsync();
            return objAnimal;
        }

        public async Task<Animal> UpdateAnimal(Animal objAnimal)
        {
            _appDBContext.Entry(objAnimal).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objAnimal;
        }
    }
}
