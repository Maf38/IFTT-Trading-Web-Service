using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects;
using CryptoExchange.Net.Authentication;

namespace IFTT_Trading.Bybit
{
    public class IFTTClient : IIFTTClient
    {

        public BybitClient BybitClient { get; } = new BybitClient(new BybitClientOptions()
        {
            ApiCredentials = new ApiCredentials("RwbCgH9zNDCj4IPQOk", "AnugVUTxffshEDuDlH62JupzPMaugyP5PDJZ"),
            LogLevel = LogLevel.Trace

        });


    }


}
