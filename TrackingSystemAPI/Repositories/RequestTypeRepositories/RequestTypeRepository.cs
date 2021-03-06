using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestTypeRepositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Problems requestType)
        {
            _context.requestTypes.Add(requestType);
        }

        public void Delete(int id)
        {
            Problems requestType = Find(id);
            _context.requestTypes.Remove(requestType);
        }
        public Problems Find(int id)
        {
            return _context.requestTypes.Find(id);
        }

        public IEnumerable<Problems> GetAll()
        {
            return _context.requestTypes.ToList();

        }

        public Problems GetById(int id)
        {
           return _context.requestTypes.Where(r => r.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Problems requestType)
        {
            throw new NotImplementedException();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
