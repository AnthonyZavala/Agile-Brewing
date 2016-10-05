using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTests.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string StyleId { get; set; }
        public decimal OriginalGravity { get; set; }
        public decimal FinalGravity { get; set; }
        public decimal Ibu { get; set; }
        public decimal Srm { get; set; }
        public decimal Abv { get; set; }
        public string Notes { get; set; }
    }
}