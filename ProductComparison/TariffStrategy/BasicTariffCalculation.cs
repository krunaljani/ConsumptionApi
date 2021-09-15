using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductComparison
{
    public class BasicTariffCalculation : ITariffCalculationStrategy
    {
        public string TariffName { get => "Basic electricity tariff"; }

        private const double baseCostPerMonthInEuro = 5;

        private const double consumptionCostPerkWhInCents = 22;

        public TariffCalculationModel CalculateAnualTariff(double consumptionInkWhPerYear)
        {
            try
            {
                double baseCostPerYear = baseCostPerMonthInEuro * 12;
                double consumptionCostPerYear = (consumptionInkWhPerYear * (consumptionCostPerkWhInCents / 100));

                return new TariffCalculationModel()
                {
                    TariffName = TariffName,
                    AnnualCost =  Math.Round(baseCostPerYear + consumptionCostPerYear, 2)
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

