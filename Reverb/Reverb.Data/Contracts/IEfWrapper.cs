using Reverb.Data.Models.Contracts;
using System.Linq;

namespace Reverb.Data.Contracts
{
    public interface IEfWrapper<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
