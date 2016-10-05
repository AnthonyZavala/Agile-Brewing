using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels
{
    public class Recipe
    {
        public Recipe(
            Guid id,
            string name,
            DateTimeOffset createdAt,
            string styleId,
            decimal originalGravity,
            decimal finalGravity,
            decimal ibu,
            decimal srm,
            string notes
            )
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            StyleId = styleId;
            OriginalGravity = originalGravity;
            FinalGravity = finalGravity;
            Ibu = ibu;
            Srm = srm;
            Abv = ConversionEquations.SpecificGravityAbv(originalGravity, finalGravity);
            Notes = notes;
        }

        public Guid Id { get; }
        public string Name { get; }
        public DateTimeOffset CreatedAt { get; }
        public string StyleId { get; }
        public decimal OriginalGravity { get; }
        public decimal FinalGravity { get; }
        public decimal Ibu { get; }
        public decimal Srm { get; }
        public decimal Abv { get; }
        public string Notes { get; }

        public static Recipe CreateNewRecipe(
            string name,
            string styleId,
            decimal originalGravity,
            decimal finalGravity,
            decimal ibu,
            decimal srm,
            string notes = null
            )
        {
            return new Recipe(
                id: Guid.NewGuid(),
                name: name,
                createdAt: DateTimeOffset.UtcNow,
                styleId: styleId,
                originalGravity: originalGravity,
                finalGravity: finalGravity,
                ibu: ibu,
                srm: srm,
                notes: notes
                );
        }
    }
}
