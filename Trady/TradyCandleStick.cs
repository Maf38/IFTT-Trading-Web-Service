using System;
using System.Collections.Generic;
using System.Text;
using Trady.Core.Infrastructure;

namespace IFTT_Trading.Trady
{
    public class TradyCandleStick : IOhlcv
    {
        private decimal open;
        private decimal high;
        private decimal low;
        private decimal close;
        private decimal volume;

        private DateTimeOffset dateTime;

        public decimal Open { get => open; set => open = value; }
        public decimal High { get => high; set => high = value; }
        public decimal Low { get => low; set => low = value; }
        public decimal Close { get => close; set => close = value; }
        public decimal Volume { get => volume; set => volume = value; }
        public DateTimeOffset DateTime { get => dateTime; set => dateTime = value; }

        public TradyCandleStick()
        {

        }

    }
}
