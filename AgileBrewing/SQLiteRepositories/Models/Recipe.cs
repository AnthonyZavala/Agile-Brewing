using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Core.DomainModels;

namespace SQLiteRepositories.Models
{
    class Recipe
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual string StyleId { get; set; }
        public virtual decimal OriginalGravity { get; set; }
        public virtual decimal FinalGravity { get; set; }
        public virtual decimal Ibu { get; set; }
        public virtual decimal Srm { get; set; }
        public virtual decimal Abv { get; set; }
        public virtual string Notes { get; set; }

        internal static Recipe FromDomain(Domain.Recipe domainModel)
        {
            return new Recipe
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                CreatedAt = domainModel.CreatedAt.UtcDateTime,
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
                id: repositoryModel.Id,
                name: repositoryModel.Name,
                createdAt: new DateTimeOffset(repositoryModel.CreatedAt, new TimeSpan()),
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
