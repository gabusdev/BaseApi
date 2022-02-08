using BaseApi.DataEF;
using System;
using System.Threading.Tasks;

namespace DataEF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //public IGenericRepository<Your_Entitie> Entities { get; set; }

        private readonly CoreDbContext _context;
        private bool disposed = false;

        public UnitOfWork(CoreDbContext context)
        {
            _context = context;
            //Your_Entitie = Your_Entitie ?? new GenericRepository<Your_Entitie>(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
