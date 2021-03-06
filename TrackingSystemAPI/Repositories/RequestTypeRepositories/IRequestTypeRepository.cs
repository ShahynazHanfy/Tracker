using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestTypeRepositories
{
   public interface IRequestTypeRepository : IDisposable
    {
        IEnumerable<Problems> GetAll();
        Problems GetById(int id);
        Problems Find(int id);
        void Add(Problems requestType);
        void Update(Problems requestType);
        void Delete(int id);
        void Save();
    }
}
