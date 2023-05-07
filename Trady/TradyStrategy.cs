using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trady.Analysis;
using Trady.Analysis.Extension;
using Trady.Analysis.Backtest;
using Trady.Analysis.Indicator;
using IFTT_Trading.Trady;
using Bybit.Net.Objects.Models;
using IFTT_Trading.Tools;

namespace MafCryptoBot.Modele.Trady
{
    public class TradyStrategy
    {

        private IEnumerable<BybitKline> klines;
        public IEnumerable<BybitKline> Klines { get => klines; }

        //l'équivalent de la Kline pour la librairie trady
        private IEnumerable<TradyCandleStick> tradyLines;
        public IEnumerable<TradyCandleStick> TradyLines { get => tradyLines; }


        private Result result;
        public Result Result { get => result; set => result = value; }

        public TradyStrategy(IEnumerable<BybitKline> klines, int lmaPeriod, int hmaPeriod, int rsiPeriod)
        {
            this.klines = klines.ToList();
            tradyLines = ConversionCandlestick.ToListTradyOHLC(klines);
            BuildStrategy(lmaPeriod, hmaPeriod, rsiPeriod);
        }

        private void BuildStrategy(int lmaPeriod, int hmaPeriod, int rsiPeriod)
        {
            // Build buy rule & sell rule based on various patterns
            var buyRule =
                 //Rule.Create(c => c.IsEmaBullishCross(lmaPeriod, hmaPeriod))
                 Rule.Create(c => c.IsSmaBullishCross(lmaPeriod, hmaPeriod))
                .And(c => !c.IsRsiOverbought(rsiPeriod));
            //.And(c => !c.IsFullStoOverbought(rsiPeriod,lmaPeriod,hmaPeriod))
            ;

            var sellRule =
                  //Rule.Create(c => c.IsEmaBearishCross(lmaPeriod, hmaPeriod))
                  Rule.Create(c => c.IsSmaBearishCross(lmaPeriod, hmaPeriod))
                 .And(c => !c.IsRsiOversold(rsiPeriod));
            //.And(c => !c.IsFullStoOversold(rsiPeriod, lmaPeriod, hmaPeriod))
            ;


            // Create portfolio instance by using PortfolioBuilder
            Runner runner = new Builder()
                .Add(tradyLines)
                .Buy(buyRule)
                .Sell(sellRule)
                .BuyWithAllAvailableCash()
                .FlatExchangeFeeRate(0.001m)
                .Premium(1)
                .Build();


            this.result = runner.Run(1000);



        }

        //Permet de connaitre le pourcentage de perte ou de gain si on avait acheté au debut de la serie et revendu à la fin
        public decimal BuyAndHodlProfitLoss()
        {

            decimal result = 0;
            if (this.tradyLines != null && this.tradyLines.Count() > 2)
            {

                //j'utilise la moyenne mobile à 1 periode pour determiner la moyenne du premier et du dernier point
                var sma = new SimpleMovingAverage(TradyLines, 1);

                var firstMoyenne = sma[0];

                var lastMoyenne = sma[tradyLines.Count() - 1];

                result = ((decimal)lastMoyenne.Tick - (decimal)firstMoyenne.Tick) / (decimal)firstMoyenne.Tick;

            }

            return result;
        }
    }
}