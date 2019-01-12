using RealEstate.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Repository
{
    public abstract class RepositoryBase
    {
        public RepositoryBase(IRealEstateContext realEstateContext)
        {
            RealEstateContext = realEstateContext;
        }

        public IRealEstateContext RealEstateContext { get; }
    }
}
