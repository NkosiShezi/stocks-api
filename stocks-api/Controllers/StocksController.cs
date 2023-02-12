using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stocks_api.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stocks_api.Controllers
{
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {


        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public StocksController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Stocks> GetStocks()
        {

            List<Stocks> stocks = new List<Stocks>();
            using (StreamReader reader = new StreamReader($"{_webHostEnvironment.ContentRootPath}/json/Stocks.json"))
            {
                stocks = JsonConvert.DeserializeObject<List<Stocks>>(reader.ReadToEnd());
            }

            return stocks;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<StockValues> GetStocks(int id)
        {
            List<StockValues> stockValues = new List<StockValues>();
            using (StreamReader reader = new StreamReader($"{_webHostEnvironment.ContentRootPath}/json/StockValues.json"))
            {
                stockValues = JsonConvert.DeserializeObject<List<StockValues>>(reader.ReadToEnd());
            }
            //var stock = stockValues.Where(stock => stock.Stock_Id == id);

            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

