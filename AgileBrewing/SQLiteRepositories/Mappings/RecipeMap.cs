using FluentNHibernate.Mapping;
using SQLiteRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteRepositories.Mappings
{
    class RecipeMap : ClassMap<Recipe>
    {
        public RecipeMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name);
            Map(x => x.CreatedAt);
            Map(x => x.StyleId);
            Map(x => x.OriginalGravity);
            Map(x => x.FinalGravity);
            Map(x => x.Ibu);
            Map(x => x.Srm);
            Map(x => x.Abv);
            Map(x => x.Notes);
        }
    }
}
