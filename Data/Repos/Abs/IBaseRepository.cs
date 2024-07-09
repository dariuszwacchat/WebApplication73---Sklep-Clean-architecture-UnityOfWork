using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repos.Abs
{
    public interface IBaseRepository <T>
    {
        Task <List<T>> GetAll ();
        Task <T> Get (string id);
        Task Create (T model);
        Task Delete (string id);
        Task Update (T model);
    }
}
