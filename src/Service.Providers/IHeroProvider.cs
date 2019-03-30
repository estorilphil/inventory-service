using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Service.EntityModels;

namespace Service.Providers
{
    public interface IHeroProvider
    {
        Task<IList<Hero>> GetList();
        Task<Hero> GetOne(int id);
        Task<Hero> Update(Hero hero);
    }
}
