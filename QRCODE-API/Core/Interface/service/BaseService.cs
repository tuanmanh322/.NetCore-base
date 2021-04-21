using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.Core.Interface.service
{
    public interface BaseService<TDTO, TEntity>
    {
        Task<List<TDTO>> GetAll();

        Task<TEntity> FindById(int Id);

        Task<TEntity> Add(TDTO tDTO);

        Task<TEntity> Update(TDTO tDTO);

        Task<TEntity> DeleteById(int Id);
    }
}
