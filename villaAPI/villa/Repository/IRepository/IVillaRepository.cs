namespace villa.Repository.IRepository;
using villa.Models;
using System.Collections.Generic;
using System.Linq.Expressions;


public interface IVillaRepository
{
     
    // Task<IEnumerable<Villa>> GetAllVillasAsync();
    Task<IEnumerable<villa>> GetAllVillasAsync(Expression<Func<villa>> filter = null);


    // Task<Villa> GetVillaByIdAsync(int id);
    Task<villa> GetVillaByIdAsync(int id, Expression<Func<villa>> filter = null);

    // Task createVillaAsync(Villa villa);
    Task createVillaAsync(villa villa, Expression<Func<villa>> filter = null);
    // Task UpdateVillaAsync(Villa villa);
    Task UpdateVillaAsync(villa villa, Expression<Func<villa>> filter = null);
    // Task DeleteVillaAsync(int id);
    Task UpdateVillaAsync(villa villa, Expression<Func<villa>> filter = null);
    //save changes
    Task SaveAsync();
}
