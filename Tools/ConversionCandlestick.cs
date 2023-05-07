using Bybit.Net.Objects.Models;
using IFTT_Trading.Trady;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFTT_Trading.Tools
{
    //Classe servant à convertir les modèles de bougie (du modèle OHLC  binance vers le modèle OHLC trady par exemple)
    public static class ConversionCandlestick
    {
        public static IEnumerable<TradyCandleStick> ToListTradyOHLC(IEnumerable<BybitKline> klines)
        {
            List<TradyCandleStick> listeTrady = new List<TradyCandleStick>();


            foreach (BybitKline kline in klines)
            {
                listeTrady.Add(ToTradyOHLC(kline));
            };

            return listeTrady;
        }




        public static TradyCandleStick ToTradyOHLC(BybitKline kline)
        {
            TradyCandleStick candle = new TradyCandleStick()
            {
                Open = kline.OpenPrice,
                High = kline.HighPrice,
                Low = kline.LowPrice,
                Close = kline.ClosePrice,
                Volume = kline.Volume,
                DateTime = kline.OpenTime
            };

            return candle;
        }
    }
}
