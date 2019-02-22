using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using QuoteMe.Models;

namespace QuoteMe.Storage
{
    public class InMemoryStorageService : IWritableStorageService
    {
        private readonly List<Quote> _quotes;

        public InMemoryStorageService()
        {
            _quotes = new List<Quote>();
        }

        public IQueryable<Quote> GetQuotes(int page, int take)
        {
            return _quotes.OrderByDescending(x => x.Timestamp).Skip(page).Take(take).AsQueryable();
        }

        public Quote GetQuote(Guid quoteId)
        {
            var quote = _quotes.SingleOrDefault(x => x.QuoteId == quoteId);

            if (quote == null)
                throw new ObjectNotFoundException($"Could not find quote with Id: {quoteId}");

            return quote;
        }

        public void StoreQuote(Quote quote)
        {
            _quotes.Add(quote);
        }

        public void UpdateArrangmentFee(Guid quoteId, decimal arrangmentFee)
        {
            var quote = GetQuote(quoteId);
            quote.ArrangementFee = arrangmentFee;
        }

        public void UpdateCompletionFee(Guid quoteId, decimal completionFee)
        {
            var quote = GetQuote(quoteId);
            quote.CompletionFee = completionFee;
        }

        public void DeleteQuote(Guid quoteId)
        {
            var quote = GetQuote(quoteId);
            _quotes.Remove(quote);
        }
    }
}
