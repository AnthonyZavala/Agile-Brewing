using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using WebApplication.Models;
using Microsoft.OData;
using Core.ApplicationServices;
using Core;

namespace WebApplication.Controllers
{
    [EnableQuery]
    public class RecipesController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private readonly RecipeService _recipeService;

        public RecipesController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: odata/Recipes
        public async Task<IHttpActionResult> GetRecipes(ODataQueryOptions<Recipe> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // Inefficient, entire set is being loaded into memory before querying.
            var recipes = (await _recipeService.Get()).Select(Recipe.FromDomain).AsQueryable();

            return Ok(recipes);
        }

        // GET: odata/Recipes(5)
        public async Task<IHttpActionResult> GetRecipe([FromODataUri] Guid key, ODataQueryOptions<Recipe> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            try
            {
                var recipe = await _recipeService.Get(key);
                return Ok(Recipe.FromDomain(recipe));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// POST: odata/Recipes
        public async Task<IHttpActionResult> Post(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newRecipe = await _recipeService.Create(
                name: recipe.Name,
                styleId: recipe.StyleId,
                originalGravity: recipe.OriginalGravity,
                finalGravity: recipe.FinalGravity,
                ibu: recipe.Ibu,
                srm: recipe.Srm,
                notes: recipe.Notes);

            return Created(Recipe.FromDomain(newRecipe));
        }

        // PUT: odata/Recipes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Delta<Recipe> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipe = Recipe.FromDomain(await _recipeService.Get(key));

            delta.Put(recipe);

            await _recipeService.Update(Recipe.ToDomain(recipe));

            return Updated(recipe);
        }

        // PATCH: odata/Recipes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<Recipe> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipe = Recipe.FromDomain(await _recipeService.Get(key));

            delta.Patch(recipe);

            await _recipeService.Update(Recipe.ToDomain(recipe));

            return Updated(recipe);
        }

        // DELETE: odata/Recipes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
        {
            await _recipeService.Delete(key);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
