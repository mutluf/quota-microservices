using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Quote.API.Dtos;
using Quote.API.Services;

namespace Quote.API.Controllers
{
    [Route("api/quotes")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        private readonly IPublishEndpoint _publishEndpoint;
        public QuotesController(IQuoteService quoteService, IPublishEndpoint publishEndpoint)
        {
            _quoteService = quoteService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = _quoteService.GetAll();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _quoteService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuoteDto quote)
        {
             int id = await _quoteService.CreateAsync(quote);

            //var userName = User?.Identity?.Name;
            //int quoteId = quote.Id;
            
            QuoteCreatedEvent quoteEvent = new QuoteCreatedEvent()
            {
                QuoteId = id,
                Username = User?.Identity?.Name!
            };

            _publishEndpoint.Publish(quoteEvent);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] QuoteDto quote)
        {
            bool result =  _quoteService.Update(quote);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _quoteService.Delete(id);
            return Ok();
        }


    }
}
