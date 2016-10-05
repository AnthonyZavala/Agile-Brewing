using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Core.DomainModels;

namespace MongoDBRepositories.Models
{
    class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string StyleId { get; set; }
        public decimal OriginalGravity { get; set; }
        public decimal FinalGravity { get; set; }
        public decimal Ibu { get; set; }
        public decimal Srm { get; set; }
        public decimal Abv { get; set; }
        public string Notes { get; set; }

        internal static Recipe FromDomain(Domain.Recipe domainModel)
        {
            return new Recipe
            {
                Id = domainModel.Id.ToString(),
                Name = domainModel.Name,
                CreatedAt = domainModel.CreatedAt,
                StyleId = domainModel.StyleId,
                OriginalGravity = domainModel.OriginalGravity,
                FinalGravity = domainModel.FinalGravity,
                Ibu = domainModel.Ibu,
                Srm = domainModel.Srm,
                Abv = domainModel.Abv,
                Notes = domainModel.Notes
            };
        }

        internal static Domain.Recipe ToDomain(Recipe repositoryModel)
        {
            return new Domain.Recipe
            (
                id: Guid.Parse(repositoryModel.Id),
                name: repositoryModel.Name,
                createdAt: repositoryModel.CreatedAt,
                styleId: repositoryModel.StyleId,
                originalGravity: repositoryModel.OriginalGravity,
                finalGravity: repositoryModel.FinalGravity,
                ibu: repositoryModel.Ibu,
                srm: repositoryModel.Srm,
                notes: repositoryModel.Notes
            );
        }
    }
}
