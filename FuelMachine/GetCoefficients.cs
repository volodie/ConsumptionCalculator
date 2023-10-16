using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelMachine.Models;

namespace FuelMachine
{
    static class GetCoefficients
    {
        public static int GetFuelCoefficient(string fuel)
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var coefficient = db.Fuels.FirstOrDefault(p => p.FuelType.ToUpper() == fuel.ToUpper());
                if (coefficient != null)
                    return coefficient.Coefficient;
                return 0;
            }
        }
        public static int GetAirCoefficient(string air)
        {
            bool result = air.ToBoolean();
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var coefficient = db.AirConditioners.FirstOrDefault(p => p.IsAirConditionerPresent == result);
                if (coefficient != null)
                    return coefficient.Coefficient;
                return 0;
            }
        }
        public static int GetTownCoefficient(string towns)
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var coefficient = db.Towns.FirstOrDefault(p => p.TownName.ToUpper() == towns.ToUpper());
                if (coefficient != null)
                    return coefficient.Coefficient;
                return 0;
            }
        }
        public static decimal GetModelConsumption(string modelcar)
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var modId = db.CarModels.FirstOrDefault(p => p.ModelName.ToUpper() == modelcar.ToUpper()).Id;

                var coefficient = db.ModelConsumptions.FirstOrDefault(p => p.ModelId == modId);
                if (coefficient != null)
                    return coefficient.VechicleConsumption;
                return 0;
            }
        }
    }
}
