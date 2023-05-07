using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using IFTT_Trading.Trady;

namespace IFTT_Trading.Bybit
{
    public class BybitStat : IBybitStat
    {
        private readonly IBybitClient _bybitClient;
        private readonly ILogger _logger;

        public BybitStat(ILogger logger, IFTTClient client)
        {

            _bybitClient = client.BybitClient;
            _logger = logger;

        }

        public async Task<double> getCurrentRSI14Async(string pair, KlineInterval interval)
        {
            double result = -1;
            try
            {

                //On calcule la période de temps pour laquelle on doit remonter afin d'obtenir le bon nombre de bougies pour faire trouver le RSI14
                BinanceIntervalCorrelation bic = new BinanceIntervalCorrelation(interval);
                int nbMinutesToRollback = -bic.Value * 16;

                var klinesResponse = await _bybitClient.UsdPerpetualApi.ExchangeData.GetKlinesAsync(pair, interval, DateTime.UtcNow.AddMinutes(nbMinutesToRollback));

                if (klinesResponse && klinesResponse.Success)
                {
                    TradyStat stat = new TradyStat(klinesResponse.Data);
                    result = stat.getLastRSI14();
                }

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError("GetCurrentRSI14 Error {0}", e.Message.ToString());
                return result;
            }


        }

    }
}
