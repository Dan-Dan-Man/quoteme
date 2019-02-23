namespace QuoteMe.MVC.Services.Extensions
{
    public static class FormattingExtensions
    {
        /// <summary>
        /// Formats a given decimal into currency
        /// </summary>
        /// <param name="currency">Value to be formatted</param>
        /// <returns>The decimal converted to currency format</returns>
        public static string AsCurrency(this decimal currency)
        {
            return currency.ToString("C");
        }
    }
}