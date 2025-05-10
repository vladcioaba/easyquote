using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockQuotationApi.Models
{
    public class StockQuote
    {
        [JsonIgnore]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "Stock symbol must be between 2 and 4 characters")]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Stock symbol must contain only uppercase letters")]
        public string Symbol { get; set; } = string.Empty;
        
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [JsonIgnore]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}