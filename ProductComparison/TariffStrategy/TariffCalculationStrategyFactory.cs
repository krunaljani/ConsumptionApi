using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductComparison
{
    public class TariffCalculationStrategyFactory
    {
        public ITariffCalculationStrategy GetTariffCalculationStrategy(TariffTypes tariffType)
        {
            switch (tariffType)
            {
                case TariffTypes.Basic:
                    return new BasicTariffCalculation();
                case TariffTypes.Packaged:
                    return new PackagedTariffCalculation();
                default:
                    return null;
            }
        }
    }
}
