using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Core.DomainModels;

namespace SQLiteRepositories.Models
{
    class Style
    {
        public virtual string Id { get; set; }
        public virtual string Type { get; set; }
        public virtual decimal MinimumOriginalGravity { get; set; }
        public virtual decimal MaximumOriginalGravity { get; set; }
        public virtual decimal MinimumFinalGravity { get; set; }
        public virtual decimal MaximumFinalGravity { get; set; }
        public virtual decimal MinimumIbu { get; set; }
        public virtual decimal MaximumIbu { get; set; }
        public virtual decimal MinimumSrm { get; set; }
        public virtual decimal MaximumSrm { get; set; }
        public virtual decimal MinimumAbv { get; set; }
        public virtual decimal MaximumAbv { get; set; }

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
