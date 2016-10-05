using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Core.DomainModels;

namespace MongoDBRepositories.Models
{
    class Style
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public decimal MinimumOriginalGravity { get; set; }
        public decimal MaximumOriginalGravity { get; set; }
        public decimal MinimumFinalGravity { get; set; }
        public decimal MaximumFinalGravity { get; set; }
        public decimal MinimumIbu { get; set; }
        public decimal MaximumIbu { get; set; }
        public decimal MinimumSrm { get; set; }
        public decimal MaximumSrm { get; set; }
        public decimal MinimumAbv { get; set; }
        public decimal MaximumAbv { get; set; }

        internal static Style FromDomain(Domain.Style domainModel)
        {
            return new Style
            {
                Id = domainModel.Id,
                Type = domainModel.Type,
                MinimumOriginalGravity = domainModel.MinimumOriginalGravity,
                MaximumOriginalGravity = domainModel.MaximumOriginalGravity,
                MinimumFinalGravity = domainModel.MinimumFinalGravity,
                MaximumFinalGravity = domainModel.MaximumFinalGravity,
                MinimumIbu = domainModel.MinimumIbu,
                MaximumIbu = domainModel.MaximumIbu,
                MinimumSrm = domainModel.MinimumSrm,
                MaximumSrm = domainModel.MaximumSrm,
                MinimumAbv = domainModel.MinimumAbv,
                MaximumAbv = domainModel.MaximumAbv
            };
        }
    }
}
