using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Style
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
    }
}