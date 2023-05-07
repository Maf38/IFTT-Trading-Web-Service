using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models;
using IFTT_Trading.Bybit;
using IFTT_Trading.Models;
using Microsoft.AspNetCore.Mvc;

namespace IFTT_Trading.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IBybitClient _bybitClient;

        public OrderController(ILogger<OrderController> logger, IFTTClient client)
        {

            _bybitClient = client.BybitClient;
            _logger = logger;
        }


        [HttpGet(Name = "GetKline")]
        public async Task<ActionResult<IEnumerable<BybitKline>>> GetBybitKlineAsync()
        {



            var kline = await _bybitClient.UsdPerpetualApi.ExchangeData.GetKlinesAsync("BTCUSDT", KlineInterval.OneHour, DateTime.UtcNow.AddDays(-3));

            return Ok(kline);

        }


        [HttpGet(Name = "GetOrderBookBTC")]
        public async Task<ActionResult<IEnumerable<BybitOrderBookEntry>>> GetBybitOrderBookEntryAsync()
        {
            // Getting the order book of a symbol
            var orderBookData = await _bybitClient.UsdPerpetualApi.ExchangeData.GetOrderBookAsync("BTCUSDT");




            return Ok(orderBookData);

        }

        [HttpPost(Name = "PlaceOrder")]
        public async Task<ActionResult<Data>> PlaceOrder(LimitOrder order)
        {
            Data response = new Data();

            try
            {
                var data = await _bybitClient.UsdPerpetualApi.Trading.PlaceOrderAsync(
               symbol: order.Pair,
               //side: order.ParseBybitOrderSide(order.OrderSide),
               side: order.ParseBybitOrderSide(order.OrderSide),
               type: OrderType.Limit,
               quantity: order.Quantity,
               timeInForce: TimeInForce.GoodTillCanceled,
               reduceOnly: false,
               closeOnTrigger: false,
               stopLossPrice: order.StopLoss,
               takeProfitPrice: order.TakeProfit,
               price: order.Price,
               receiveWindow: 50000,
               // Position mode = mode de couverture(unidirectionnel ou hedge mode) =< pour l'instant il faut que le coin soit positionné en unidirectionnel au niveau des options bybit
               positionMode: PositionMode.OneWay

            );

                _logger.LogInformation("Place Order result Data: {0}", data.ToString());


                if (data && data.Success)
                {
                    LimitOrder returnorder = new LimitOrder(
                        id: data.Data.Id,
                        pair: data.Data.Symbol,
                        orderSide: order.OrderSide,
                        quantity: data.Data.Quantity,
                        stopLoss: data.Data.StopLoss ?? order.StopLoss,
                        takeProfit: data.Data.TakeProfit ?? order.TakeProfit,
                        price: order.Price,
                        leverage: order.Leverage

                    );

                    response.Message = "Ordre limite OK";
                    response.LimitOrder = returnorder;
                    return Ok(response);
                }
                else
                {
                    if (!data.Success && data.Error != null)
                    {
                        response.Error = data.Error.ToString();
                        _logger.LogError("PlaceOrder Order KO {0}", response.Error);
                    }

                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("PlaceOrder Order Error {0}", e.Message.ToString());
                return BadRequest();
            }


        }


    }
}
