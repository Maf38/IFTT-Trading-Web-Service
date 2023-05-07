using Bybit.Net.Enums;

namespace IFTT_Trading.Models
{

  

    public class Order
    {

        public string? Id { get; set; }
        public string OrderSide { get; set; }
        public string Pair { get; set; }
        public decimal Quantity { get; set; }


        public Order(string orderSide,string pair,decimal quantity)
        {
            OrderSide = orderSide;
            Pair = pair;
            Quantity = quantity;

        }

        public Order()
        {
            
        }


        public OrderSide ParseBybitOrderSide(string orderstring)
        {
            OrderSide orderSide;
            switch (orderstring)
            {
                case "Buy":
                    orderSide = global::Bybit.Net.Enums.OrderSide.Buy;
                    break;
                case "Sell":
                orderSide = global::Bybit.Net.Enums.OrderSide.Sell;
                break;
                default:
                    orderSide = global::Bybit.Net.Enums.OrderSide.Buy;
                break;
            }

            return orderSide;
        }
    }
}
