using Microsoft.AspNetCore.Mvc;
using Quota.Aggregator.Dtos;
using Quota.Aggregator.Services;

namespace Quota.Aggregator.Controllers
{
    [Route("api/quotes")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IUserQuoteService _userQuoteService;

        public QuotesController(IUserQuoteService userQuoteService)
        {
            _userQuoteService = userQuoteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            QuoteDto quote = await _userQuoteService.GetQuoteAsync(id);
            Console.Write(id);

            return Ok(quote);
        }
    }
}
