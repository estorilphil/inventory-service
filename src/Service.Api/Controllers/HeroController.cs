using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

using Service.Types.Enumerations;
using CM = Service.ContractModels;
using EM = Service.EntityModels;
using Service.Providers;

namespace Service.Api.Controllers
{
    [Route("api/hero")]
    public class HeroController : Controller
    {

        private readonly IMapper _mapper;
        private IHeroProvider _heroProvider;

        public HeroController(
            IMapper mapper,
            IHeroProvider heroProvider
            )
        {
            _mapper = mapper;
            _heroProvider = heroProvider;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IList<CM.Hero>> GetList()
        {
            return await HeroGetListAndMap();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CM.Hero> GetOne([FromBody] int id)
        {
            EM.Hero entity = await _heroProvider.GetOne(id);
            CM.Hero contract = _mapper.Map<CM.Hero>(entity);
            return contract;
        }
        
        [HttpPut]
        [Route("update")]
        public async Task<CM.Hero> Update([FromBody] CM.Hero hero)
        {
            EM.Hero entity = _mapper.Map<EM.Hero>(hero);
            entity = await _heroProvider.Update(entity);
            CM.Hero contract = _mapper.Map<CM.Hero>(entity);
            return contract;
        }

        #region private methods
        private async Task<IList<CM.Hero>> HeroGetListAndMap()
        {
            IList<EM.Hero> entityList = await _heroProvider.GetList();
            IList<CM.Hero> contractList = _mapper.Map<IList<CM.Hero>>(entityList);

            return contractList;
        }
        #endregion
    }
}
