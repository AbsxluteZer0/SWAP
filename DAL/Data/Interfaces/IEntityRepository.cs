using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Interfaces
{
    public interface IEntityRepository<T> : IEnumerable<T>, IDisposable where T : class
    {
        public void Add(T item);
        public void Update(T item);
        public void Delete(T item);
        public IEnumerable<T> GetAll();
    }
}