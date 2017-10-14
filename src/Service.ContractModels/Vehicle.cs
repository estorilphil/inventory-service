using System;

using Service.Types.Enumerations;

namespace Service.ContractModels
{
    public class Vehicle
    {
        public int Year { get; set; }
        public VehicleMakes Make { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public TransmissionTypes Transmission { get; set; }
        public int ForwardGears { get; set; }
        public string ChassisNotation { get; set; }
        public string EngineNotation { get; set; }
        public string Description { get; set; }
    }
}
