using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beerhall.Models.Domain
{
    public interface IBrewerRepository
    {
        Brewer GetBy(int BrewerId);
        IEnumerable<Brewer> GetAll();
        void Add(Brewer brewer);
        void Delete(Brewer brewer);
        void SaveChanges();
    }
}
