using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_mpp.repository
{
    internal interface IRepository<T, TID>
    {
        void Add(T item);
        void Update(T item, TID id);
        void Delete(TID item);
        T findOne(TID id);
        IEnumerable<T> findAll();
        ICollection<T> getAll();


    }
}