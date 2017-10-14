using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Service.EntityModels;

namespace Service.Repositories
{
    public interface IInventoryRepository
    {
        Task<IList<Vehicle>> GetList();
    }
}
