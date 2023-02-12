using System;
namespace stocks_api.Models
{
    public class Stocks
    {
  
        public long Id { get; set; }

        public string Stock { get; set; }

        public string Industry { get; set; }

        public string Sector { get; set; }

        public string CurrencyCode { get; set; }
        
    }
	
}

