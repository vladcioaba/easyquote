using Microsoft.AspNetCore.Mvc;
using StockQuotationApi.Models;
using StockQuotationApi.Services;

namespace StockQuotationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockQuotesController : ControllerBase
    {
        private readonly StockQuoteRepository _repository;
        private readonly ILogger<StockQuotesController> _logger;

        public StockQuotesController(StockQuoteRepository repository, ILogger<StockQuotesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("{symbol}")]
        public ActionResult<IEnumerable<StockQuote>> GetBySymbol(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
                return BadRequest("Symbol is required");

            if (symbol.Length < 2 || symbol.Length > 4)
                return BadRequest("Stock symbol must be between 2 and 4 characters");
            
            var quotes = _repository.GetBySymbol(symbol);
            var quote = quotes.FirstOrDefault();
            if (quote == null)
                return NotFound();
            
            return Ok(quote);
        }

        [HttpPost]
        public ActionResult<StockQuote> Create(StockQuote quote)
        {
            if (string.IsNullOrEmpty(quote.Symbol))
                return BadRequest("Symbol is required");

            quote.Timestamp = DateTime.UtcNow;
            quote.Id = Guid.NewGuid().ToString();
            
            var created = _repository.Add(quote);

            if (quote == null)
                return NotFound();
            
            return Ok(quote);
        }

        [HttpPut]
        public IActionResult Update(StockQuote quote)
        {
            if (string.IsNullOrEmpty(quote.Symbol))
                return BadRequest("Symbol is required");

            quote.Timestamp = DateTime.UtcNow;
        
            if (!_repository.UpdateBySymbol(quote))
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{symbol}")]
        public IActionResult Delete(string symbol)
        {
            var quote = _repository.GetBySymbol(symbol).FirstOrDefault();
            if (quote == null)
                return NotFound();
                
            if (!_repository.Delete(quote.Id))
                return NotFound();

            return NoContent();
        }
    }
}