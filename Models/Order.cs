using Bybit.Net.Enums;

namespace IFTT_Trading.Models
{

  

    public class Order
    {

        public string? Id { get; set; }
        public string StringOrderSide { get; set; }
        public string Pair { get; set; }
        public decimal Quantity { get; set; }


        public Order(string orderSide,string pair,decimal quantity)
        {
            StringOrderSide = orderSide;
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
                    orderSide = OrderSide.Buy;
                    break;
                case "Sell":
                orderSide = OrderSide.Sell;
                break;
                default:
                    orderSide = OrderSide.Buy;
                break;
            }

            return orderSide;
        }
    }
}
