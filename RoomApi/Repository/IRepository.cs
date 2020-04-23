using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoomApi.Models;


namespace RoomApi.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(T item);
        void Update(Condtion condt);
        IEnumerable<T> FindAll();
    }
}
