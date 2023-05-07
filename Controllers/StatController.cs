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
    public class StatController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IBybitClient _bybitClient;
        private readonly IBybitStat _stat;
       

        public StatController(ILogger<StatController> logger, IFTTClient client)
        {

            _bybitClient = client.BybitClient;
            _logger = logger;
            _stat = new BybitStat(logger,client);
        }


        [HttpGet(Name = "GetRSI14")]
        public async Task<ActionResult<IEnumerable<double>>> GetRSI14Async(string pair, KlineInterval interval)
        {
            double rsi14;
            
            rsi14 = await _stat.getCurrentRSI14Async(pair, interval);
            

            return Ok(rsi14);

        }



    }
}
