using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Service.EntityModels;

namespace Service.Providers
{
    public interface IInventoryProvider
    {
        Task<IList<Vehicle>> GetList();
    }
}
