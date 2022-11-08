using Microservices_API.DBContexts;
using Microservices_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices_API.Repositories
{
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly APIDBContexts _appDBContext;
        public SpeciesRepository(APIDBContexts context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public bool DeleteAnimalSpecies(int ID)
        {
            bool result = false;
            var species = _appDBContext.AnimalSpecies.Find(ID);
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

        public async Task<IEnumerable<AnimalSpecies>> GetAnimalSpecies()
        {
            return await _appDBContext.AnimalSpecies.ToListAsync();
        }

        public async Task<AnimalSpecies> GetAnimalSpeciesByID(int ID)
        {
            return await _appDBContext.AnimalSpecies.FindAsync(ID);
        }

        public async Task<AnimalSpecies> InsertAnimalSpecies(AnimalSpecies objSpecies)
        {
            _appDBContext.AnimalSpecies.Add(objSpecies);
            await _appDBContext.SaveChangesAsync();
            return objSpecies;
        }

        public async Task<AnimalSpecies> UpdateAnimalSpecies(AnimalSpecies objSpecies)
        {
            _appDBContext.Entry(objSpecies).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objSpecies;
        }
    }
}
