using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Service.Types.Enumerations;
using Service.EntityModels;

namespace Service.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        public async Task<IList<Vehicle>> GetList()
        {
            return new List<Vehicle>
            {
                new Vehicle
                {
                    Year = 1999,
                    Make = VehicleMakes.BMW,
                    Model="M3",
                    ChassisNotation="E36",
                    EngineNotation="S52B32",
                    Transmission= TransmissionTypes.ConventionalManual,
                    ForwardGears=5,
                    ExteriorColor="Estoril Blue",
                    InteriorColor="Light Gray"
                },
                new Vehicle
                {
                    Year = 1990,
                    Make = VehicleMakes.BMW,
                    Model="M3",
                    ChassisNotation="E30",
                    EngineNotation="S14B24",
                    Transmission= TransmissionTypes.ConventionalManual,
                    ForwardGears=5,
                    ExteriorColor="Hannarot Red",
                    InteriorColor="Black"
                }
            };
        }
    }
}
