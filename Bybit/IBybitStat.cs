using Bybit.Net.Enums;

namespace IFTT_Trading.Bybit
{
    public interface IBybitStat
    {
        Task<double> getCurrentRSI14Async(string pair, KlineInterval interval);
    }
}