using Bybit.Net.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFTT_Trading.Bybit
{
    //Cette classe permet de faire une correspondance entre l'enum KLineInterval et sa valeur en minute et le nom qu'elle doit prendre dans une combobox par exemple
    public class BinanceIntervalCorrelation
    {
        //Enum de binance
        private KlineInterval key;
        public KlineInterval Key { get => key; }

        //Temps en minute
        private int value;
        public int Value { get => value; }

        //Affichage combobox
        private string display;
        public string Display { get => display; }


        public static List<BinanceIntervalCorrelation> Liste { get => GetAllCorrelation(); }

        public BinanceIntervalCorrelation(KlineInterval key)
        {
            this.key = key;
            switch (key)
            {

                case KlineInterval.OneMinute:
                    value = 1;
                    display = "1 min";
                    break;
                case KlineInterval.ThreeMinutes:
                    value = 3;
                    display = "3 min";
                    break;
                case KlineInterval.FiveMinutes:
                    value = 5;
                    display = "5 min";
                    break;
                case KlineInterval.FifteenMinutes:
                    value = 15;
                    display = "15 min";
                    break;
                case KlineInterval.ThirtyMinutes:
                    value = 30;
                    display = "30 min";
                    break;
                case KlineInterval.OneHour:
                    value = 60;
                    display = "1 h";
                    break;
                case KlineInterval.TwoHours:
                    value = 120;
                    display = "2 h";
                    break;
                case KlineInterval.FourHours:
                    value = 240;
                    display = "4 h";
                    break;
                case KlineInterval.SixHours:
                    value = 360;
                    display = "6 h";
                    break;
                case KlineInterval.TwelveHours:
                    value = 720;
                    display = "12 h";
                    break;
                case KlineInterval.OneDay:
                    value = 1440;
                    display = "1 j";
                    break;
                case KlineInterval.OneWeek:
                    value = 10080;
                    display = "1 sem";
                    break;
                case KlineInterval.OneMonth:
                    value = 43800;
                    display = "1 mois";
                    break;


                default:
                    value = 0;
                    display = "ND";
                    break;
            }



        }


        private static List<BinanceIntervalCorrelation> GetAllCorrelation()
        {

            List<BinanceIntervalCorrelation> result = new List<BinanceIntervalCorrelation>();

            foreach (KlineInterval interval in Enum.GetValues(typeof(KlineInterval)))
            {
                BinanceIntervalCorrelation inter = new BinanceIntervalCorrelation(interval);
                result.Add(inter);
            }

            return result;
        }
    }
}
