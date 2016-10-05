using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels.Repositories
{
    public interface IRecipeRepository
    {
        Task<IQueryable<Recipe>> Get();
        Task<Recipe> Get(Guid id);
        Task Create(Recipe recipe);
        Task Update(Recipe recipe);
        Task Delete(Guid id);
    }
}
