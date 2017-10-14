using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;

using Service.Types.Enumerations;
using CM = Service.ContractModels;
using EM = Service.EntityModels;
using Service.Providers;

namespace Service.Api.Controllers
{
    [Route("api/inventory/list")]
    public class InventoryController : Controller
    {

        private readonly IMapper _mapper;
        private IInventoryProvider _inventoryProvider;

        public InventoryController(
            IMapper mapper,
            IInventoryProvider inventoryProvider
            )
        {
            _mapper = mapper;
            _inventoryProvider = inventoryProvider;
        }

        [HttpGet]
        public async Task<IList<CM.Vehicle>> GetList()
        {
            return await InventoryGetListAndMap();
        }

        #region private methods
        private async Task<IList<CM.Vehicle>> InventoryGetListAndMap()
        {
            IList<EM.Vehicle> entityList = await _inventoryProvider.GetList();
            IList<CM.Vehicle> contractList = _mapper.Map<IList<CM.Vehicle>>(entityList);

            return contractList;
        }
        #endregion
    }
}
