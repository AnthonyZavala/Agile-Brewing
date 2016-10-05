using Core.DomainModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Core.DomainModels;
using Core;
using NHibernate;
using SQLiteRepositories.Models;
using NHibernate.Linq;

namespace SQLiteRepositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public RecipeRepository()
        {
            _sessionFactory = Config.GetSessionFactory();
        }

        public async Task<IQueryable<Domain.Recipe>> Get()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var recipe = await Task.Run(() => session.Query<Recipe>().Select(Recipe.ToDomain).ToList().AsQueryable());
                    tx.Commit();

                    return recipe;
                }
            }
        }


        public async Task<Domain.Recipe> Get(Guid id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var recipe = await Task.Run(() => session.Get<Recipe>(id));
                    tx.Commit();

                    if (recipe == null)
                    {
                        throw new NotFoundException(id.ToString());
                    }

                    return Recipe.ToDomain(recipe);
                }
            }
        }

        public async Task Create(Domain.Recipe recipe)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    await Task.Run(() => session.SaveOrUpdate(Recipe.FromDomain(recipe)));
                    tx.Commit();
                }
            }
        }

        public async Task Update(Domain.Recipe recipe)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    await Task.Run(() => session.SaveOrUpdate(Recipe.FromDomain(recipe)));
                    tx.Commit();
                }
            }
        }

        public async Task Delete(Guid id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    await Task.Run(() => session.Delete((new Recipe { Id = id })));
                    tx.Commit();
                }
            }
        }
    }
}
