using Core.DomainModels;
using Core.DomainModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ApplicationServices
{
    public class RecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository, IStyleRepository styleRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<IQueryable<Recipe>> Get()
        {
            return await _recipeRepository.Get();
        }

        public async Task<Recipe> Get(Guid id)
        {
            return await _recipeRepository.Get(id);
        }

        public async Task<Recipe> Create(string name,
            string styleId,
            decimal originalGravity,
            decimal finalGravity,
            decimal ibu,
            decimal srm,
            string notes)
        {
            var newRecipe = Recipe.CreateNewRecipe(
                name: name,
                styleId: styleId,
                originalGravity: originalGravity,
                finalGravity: finalGravity,
                ibu: ibu,
                srm: srm,
                notes: notes);
            await _recipeRepository.Create(newRecipe);
            return newRecipe;
        }

        public async Task Update(Recipe recipe)
        {
            await _recipeRepository.Update(recipe);
        }

        public async Task Delete(Guid id)
        {
            await _recipeRepository.Delete(id);
        }
    }
}
