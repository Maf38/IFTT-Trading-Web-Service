using Bybit.Net.Objects.Models;
using IFTT_Trading.Tools;
using Trady.Analysis.Indicator;

namespace IFTT_Trading.Trady
{
    //classe permettant d'avoir des statistiques en temps rééel sur un Indicateur
    public class TradyStat
    {
        private IEnumerable<BybitKline> klines;

        public IEnumerable<BybitKline> Klines { get => klines; }

        //l'équivalent de la Kline pour la librairie trady
        private IEnumerable<TradyCandleStick> tradyLines;
        public IEnumerable<TradyCandleStick> TradyLines { get => tradyLines; }
        public TradyStat(IEnumerable<BybitKline> klines) 
        {
            this.klines = klines.ToList();
            tradyLines = ConversionCandlestick.ToListTradyOHLC(klines);
        }

        //la valeur du RSI14 pour la dernière bougie
        public double getLastRSI14()
        {
            double result = -1;
        
            int lastCandleIndex = TradyLines.ToList().Count - 1;

            //il faut 14 bougies pour calculer un RSI14
            if (lastCandleIndex > 13)
            {
                var rsi = new RelativeStrengthIndex(TradyLines, 14)[lastCandleIndex];
                if (rsi != null && rsi.Tick != null)
                {
                    result = (double) rsi.Tick;

                };
            }
            

            return result;
        }

    }
}
