using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductComparison
{
    public interface ITariffCalculationStrategy
    {
        string TariffName { get; }
        TariffCalculationModel CalculateAnualTariff(double consumptionInkWhPerYear);
    }
}
