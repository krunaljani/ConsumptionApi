using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductComparison
{
    public class PackagedTariffCalculation : ITariffCalculationStrategy
    {
        public string TariffName { get => "Packaged tariff"; }

        private const double baseCostPerYearInEuro = 800;

        private const double consumptionCostPerkWhInCents = 30;

        public TariffCalculationModel CalculateAnualTariff(double consumptionInkWhPerYear)
        {
            try
            {
                double consumptionToCalculateCost = consumptionInkWhPerYear >= 4000 ? (consumptionInkWhPerYear - 4000) : 0;
                double consumptionCostPerYear = consumptionToCalculateCost * (consumptionCostPerkWhInCents / 100);
                return new TariffCalculationModel()
                {
                    TariffName = TariffName,
                    AnnualCost = Math.Round((baseCostPerYearInEuro + consumptionCostPerYear),2)
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
