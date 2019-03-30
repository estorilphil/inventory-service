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
    public class HeroProvider : IHeroProvider
    {
        private IInventoryRepository _repo;

        private static IList<Hero> _heroList = null;

        public HeroProvider(
            )
        {
        }

        public async Task<IList<Hero>> GetList()
        {
            IList<Hero> heroList;
            if (_heroList == null)
            {
                _heroList = new List<Hero>
                {
                    new Hero{ id=11, name="Mr. Nice" },
                    new Hero{ id= 12, name= "Narco" },
                    new Hero{ id= 13, name= "Bombasto" },
                    new Hero{ id= 14, name= "Celeritas" },
                    new Hero{ id= 15, name= "Magneta" },
                    new Hero{ id= 16, name= "RubberMan" },
                    new Hero{ id= 17, name= "Dynama" },
                    new Hero{ id= 18, name= "Dr IQ" },
                    new Hero{ id= 19, name= "Magma" },
                    new Hero{ id= 20, name= "Tornado" }
                };
            }

            heroList = _heroList;            

            return heroList;
        }

        public async Task<Hero> GetOne(int id)
        {
            IList<Hero> list = await GetList();
            Hero hero = list.FirstOrDefault(x => x.id == id);
            return hero;
        }

        public async Task<Hero> Update(Hero hero)
        {
            Hero selectedHero = null;
            if (hero != null)
            {
                selectedHero = await GetOne(hero.id);
                selectedHero.name = hero.name;
            }

            return selectedHero;
        }
    }
}
