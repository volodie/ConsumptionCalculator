using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelMachine.Models;

namespace FuelMachine
{
    internal class GetCoefficients
    {
        public int GetFuelCoefficient(string fuel)
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var coefficient = db.Fuels.FirstOrDefault(p => p.FuelType == fuel);
                if (coefficient != null)
                    return coefficient.Coefficient;
                return 0;
            }
        }
        public int GetAirCoefficient(string air)
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
        public int GetTownCoefficient(string towns)
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var coefficient = db.Towns.FirstOrDefault(p => p.TownName == towns);
                if (coefficient != null)
                    return coefficient.Coefficient;
                return 0;
            }
        }
        public decimal GetModelConsumption(string modelcar)
        {
            using (FuelMachineContext db = new FuelMachineContext())
            {
                var modId = db.CarModels.FirstOrDefault(p => p.ModelName == modelcar).Id;

                var coefficient = db.ModelConsumptions.FirstOrDefault(p => p.ModelId == modId);
                if (coefficient != null)
                    return coefficient.VechicleConsumption;
                return 0;
            }
        }
    }
}
