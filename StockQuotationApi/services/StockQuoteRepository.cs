using StockQuotationApi.Models;

namespace StockQuotationApi.Services
{
    public class StockQuoteRepository
    {
        private readonly List<StockQuote> _quotes = new();

        public IEnumerable<StockQuote> GetAll()
        {
            return _quotes;
        }

        public StockQuote? GetById(string id)
        {
            return _quotes.FirstOrDefault(q => q.Id == id);
        }

        public IEnumerable<StockQuote> GetBySymbol(string symbol)
        {
            return _quotes.Where(q => q.Symbol.Equals(symbol, StringComparison.OrdinalIgnoreCase));
        }

        public StockQuote Add(StockQuote quote)
        {
            _quotes.Add(quote);
            return quote;
        }

        public bool UpdateBySymbol(StockQuote quote)
        {
            var existingQuote = GetBySymbol(quote.Symbol).FirstOrDefault();
            if (existingQuote == null)
                return false;

            existingQuote.Price = quote.Price;
            existingQuote.Quantity = quote.Quantity;
            existingQuote.Timestamp = quote.Timestamp;

            return true;
        }
        public bool Delete(string id)
        {
            var quote = _quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null)
                return false;

            _quotes.Remove(quote);
            return true;
        }
    }
}