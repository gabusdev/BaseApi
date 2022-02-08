using System;
using System.Threading.Tasks;

namespace DataEF.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository<Your_Entity> Entities { get; set; }

        Task<int> CommitAsync();
    }
}