using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

using Service.Types.Enumerations;
using EM = Service.EntityModels;
using CM = Service.ContractModels;
using Service.Api;

namespace Service.Tests
{
    [TestClass]
    public class MappingTests
    {
        private IMapper _mapper = null;

        [TestMethod]
        public void ContractToEntityMappingTests()
        {
            Initialize();

            VehicleMappingTests();
        }

        private void Initialize()
        {
            if (_mapper == null)
            {
                MapperConfiguration mapConfig = MapperDefinition.GetMapperDefinition();
                _mapper = mapConfig.CreateMapper();
            }
        }

        #region private methods
        private CM.Vehicle CreateContractVehicle()
        {
            CM.Vehicle e30m3 = new CM.Vehicle
            {
                Year = 1990,
                Make = VehicleMakes.BMW,
                Model = "M3",
                ChassisNotation = "E30",
                EngineNotation = "S14B24",
                Transmission = TransmissionTypes.ConventionalManual,
                ForwardGears = 5,
                ExteriorColor = "Hannarot Red",
                InteriorColor = "Black"
            };

            return e30m3;
        }

        private List<CM.Vehicle> CreateContractVehicleList()
        {
            List<CM.Vehicle> cars = new List<CM.Vehicle>();
            cars.Add(CreateContractVehicle());

            return cars;
        }

        private void AssertsVehicleMapping(CM.Vehicle contract, EM.Vehicle entity)
        {
            Assert.IsTrue(entity != null);
            Assert.IsTrue(entity.Year == contract.Year);
            Assert.IsTrue(entity.Make == contract.Make);
            Assert.IsTrue(entity.Model == contract.Model);
            Assert.IsTrue(entity.ChassisNotation == contract.ChassisNotation);
            Assert.IsTrue(entity.EngineNotation == contract.EngineNotation);
            Assert.IsTrue(entity.Transmission == contract.Transmission);
            Assert.IsTrue(entity.ForwardGears == contract.ForwardGears);
            Assert.IsTrue(entity.ExteriorColor == contract.ExteriorColor);
            Assert.IsTrue(entity.InteriorColor == contract.InteriorColor);
        }

        private void VehicleMappingTests()
        {
            CM.Vehicle contract = CreateContractVehicle();
            List<CM.Vehicle> contractList = CreateContractVehicleList();

            EM.Vehicle entity = _mapper.Map<EM.Vehicle>(contract);
            List<EM.Vehicle> entityList = _mapper.Map<List<EM.Vehicle>>(contractList);

            AssertsVehicleMapping(contract, entity);

            Assert.IsTrue(entityList.Count > 0);
            for (int i = 0; i < entityList.Count; i++)
            {
                AssertsVehicleMapping(contractList[i], entityList[i]);
            }
        }
        #endregion
    }
}
