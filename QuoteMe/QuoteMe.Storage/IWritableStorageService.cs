using System;
using QuoteMe.Models;

namespace QuoteMe.Storage
{
    public interface IWritableStorageService : IReadableStorageService
    {
        void StoreQuote(Quote quote);
        void UpdateArrangmentFee(Guid quoteId, decimal arrangmentFee);
        void UpdateCompletionFee(Guid quoteId, decimal completionFee);
        void DeleteQuote(Guid quoteId);
    }
}
