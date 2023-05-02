namespace IFTT_Trading.Models
{
    public class LimitOrder : Order
    {
       

        public decimal Leverage { get; set; }
        public decimal Price{ get; set; }
        public decimal TakeProfit { get; set; }
        public decimal StopLoss { get; set; }

        public LimitOrder(string orderSide, string pair, decimal quantity, decimal leverage, decimal price, decimal takeProfit, decimal stopLoss) : base(orderSide, pair, quantity)
        {
            Leverage = leverage;
            Price = price;
            TakeProfit = takeProfit;
            StopLoss = stopLoss;

        }

        public LimitOrder(string id, string orderSide, string pair, decimal quantity, decimal leverage, decimal price, decimal takeProfit, decimal stopLoss) : base(orderSide, pair, quantity)
        {
            Id = id;
            Leverage = leverage;
            Price = price;
            TakeProfit = takeProfit;
            StopLoss = stopLoss;


        }

        public LimitOrder()
        {
 
        }

    }
}
