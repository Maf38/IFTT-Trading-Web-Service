using Bybit.Net.Clients;

namespace IFTT_Trading.Bybit
{
    public interface IIFTTClient
    {
        BybitClient BybitClient { get; }
    }
}