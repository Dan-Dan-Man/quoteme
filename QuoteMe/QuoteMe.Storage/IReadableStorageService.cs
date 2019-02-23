using System;
using System.Linq;
using QuoteMe.Models;

namespace QuoteMe.Storage
{
    public interface IReadableStorageService
    {
        IQueryable<Quote> GetQuotes(int page, int take);
        Quote GetQuote(Guid quoteId);
    }
}
