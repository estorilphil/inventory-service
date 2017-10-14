using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Service.Types;
using Service.Types.Enumerations;
using Service.EntityModels;
using Service.Repositories;

namespace Service.Providers
{
    public class InventoryProvider : IInventoryProvider
    {
        private IInventoryRepository _repo;

        public InventoryProvider(
            IInventoryRepository repo
            )
        {
            _repo = repo;
        }

        public async Task<IList<Vehicle>> GetList()
        {
            return await _repo.GetList();
        }
    }
}
