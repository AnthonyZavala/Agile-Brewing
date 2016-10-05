using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModels.Repositories
{
    public interface IStyleRepository
    {
        void Create(Style style);
        Style Get(string name);
    }
}
