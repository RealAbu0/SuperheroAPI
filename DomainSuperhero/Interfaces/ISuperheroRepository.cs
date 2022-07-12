using DomainSuperhero.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainSuperhero.Interfaces
{
    public interface ISuperheroRepository
    {
        Task<IEnumerable<SuperheroModel>> GetAllSuperherores();
        Task<SuperheroModel> GetOneSuperhero(int id);
        Task<SuperheroModel> InsertSuperhero(SuperheroModel model);
        Task<SuperheroModel> UpdateSuperhero(SuperheroModel model);
        Task<SuperheroModel> DeleteSuperhero(int id);
    }
}
