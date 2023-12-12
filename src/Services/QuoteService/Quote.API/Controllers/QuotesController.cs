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

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        //get all quotes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = _quoteService.GetAll();
            return Ok(datas);
        }

        //get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _quoteService.GetByIdAsync(id);
            return Ok();
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuoteDto quote)
        {
            await _quoteService.CreateAsync(quote);
            return Ok();
        }

        //put
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] QuoteDto quote)
        {
            bool result =  _quoteService.Update(quote);
            return Ok(result);
        }

        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _quoteService.Delete(id);
            return Ok();
        }


    }
}
