using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductComparison;

namespace Consumption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionController : ControllerBase
    {

       public  ConsumptionController()
        {

        }

        [HttpGet("{consumptionValue}")] 
        public IEnumerable<TariffCalculationModel> Get(double consumptionValue)
        {
            
            SortedList<double, TariffCalculationModel> tariffCalculationModels = new SortedList<double, TariffCalculationModel>();

            ITariffCalculationStrategy tariffCalculationStrategy;
            TariffCalculationStrategyFactory tariffCalculationStrategyFactory = new TariffCalculationStrategyFactory();

            tariffCalculationStrategy = tariffCalculationStrategyFactory.GetTariffCalculationStrategy(TariffTypes.Basic);
            var anualTariff = tariffCalculationStrategy.CalculateAnualTariff(consumptionValue);
            tariffCalculationModels.Add(anualTariff.AnnualCost, anualTariff);

            tariffCalculationStrategy = tariffCalculationStrategyFactory.GetTariffCalculationStrategy(TariffTypes.Packaged);
            anualTariff = tariffCalculationStrategy.CalculateAnualTariff(consumptionValue);
            tariffCalculationModels.Add(anualTariff.AnnualCost, anualTariff);

           return tariffCalculationModels.Values;        
        }
    }
}