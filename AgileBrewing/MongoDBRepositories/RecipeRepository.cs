using Core.DomainModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using MongoDB.Bson;
using MongoDB.Driver;
using Domain = Core.DomainModels;
using MongoDBRepositories.Models;

namespace MongoDBRepositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IMongoCollection<Recipe> _collection;

        public RecipeRepository()
        {
            _collection = Config.GetDatabase().GetCollection<Recipe>("recipes");
        }

        public async Task<IQueryable<Domain.Recipe>> Get()
        {
            return _collection.AsQueryable().Select(Recipe.ToDomain).AsQueryable();
        }

        public async Task<Domain.Recipe> Get(Guid id)
        {
            var repositoryObject = await (await _collection.FindAsync(GetById(id.ToString()))).SingleOrDefaultAsync();

            if (repositoryObject == null)
            {
                throw new NotFoundException(id.ToString());
            }

            return Recipe.ToDomain(repositoryObject);
        }

        public async Task Create(Domain.Recipe recipe)
        {
            await _collection.InsertOneAsync(Recipe.FromDomain(recipe));
        }

        public async Task Update(Domain.Recipe recipe)
        {
            var repositoryObject = Recipe.FromDomain(recipe);
            await _collection.ReplaceOneAsync(GetById(repositoryObject.Id), repositoryObject);
        }

        public async Task Delete(Guid id)
        {
            await _collection.DeleteOneAsync(GetById(id.ToString()));
        }

        private static FilterDefinition<Recipe> GetById(string id)
        {
            return Builders<Recipe>.Filter.Eq(x => x.Id, id);
        }
    }
}
