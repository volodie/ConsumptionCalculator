namespace FuelMachine
{
    internal class CalculateСonsumption
    {
        public decimal Calculate(int townKoeff, int airKoeff, int fuel2Koeff, decimal cons, int millage)
        {
            var c1 = cons * townKoeff / 100;
            var c2 = cons * airKoeff / 100;
            var c3 = cons * fuel2Koeff / 100;
            var consumptionFuel = cons + c1 + c2 + c3;

            return consumptionFuel;
        }
    }
}
