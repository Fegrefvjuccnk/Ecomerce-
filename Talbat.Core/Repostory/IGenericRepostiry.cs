using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites;
using Talbat.Core.Specfication;

namespace Talbat.Core.IGenericRepostory
{
    public interface IGenericRepostiry<T>where T: BaseEntity
    {

        Task<IReadOnlyList<T>> GetAllAsync();


        Task <T>GetById(int id);


        Task<IReadOnlyList<T>> GetAllspecAsync(Ispecfication<T> spec);

        Task<T> GetByspecId(Ispecfication<T> spec);

        Task<int> GetCountAsync(Ispecfication<T> spec);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
