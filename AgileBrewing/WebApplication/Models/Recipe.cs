using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain = Core.DomainModels;

namespace WebApplication.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        [Required]
        public string StyleId { get; set; }
        [Range(0, 2)]
        public decimal OriginalGravity { get; set; }
        [Range(0, 2)]
        public decimal FinalGravity { get; set; }
        [Range(0, 200)]
        public decimal Ibu { get; set; }
        [Range(0, 40)]
        public decimal Srm { get; set; }
        public decimal Abv { get; set; }
        public string Notes { get; set; }

        public static Recipe FromDomain(Domain.Recipe domainModel)
        {
            return new Recipe
            {
                Id = domainModel.Id,
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

        public static Domain.Recipe ToDomain(Recipe apiModel)
        {
            return new Domain.Recipe
            (
                id: apiModel.Id,
                name: apiModel.Name,
                createdAt: apiModel.CreatedAt,
                styleId: apiModel.StyleId,
                originalGravity: apiModel.OriginalGravity,
                finalGravity: apiModel.FinalGravity,
                ibu: apiModel.Ibu,
                srm: apiModel.Srm,
                notes: apiModel.Notes
            );
        }
    }
}