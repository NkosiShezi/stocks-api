using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stocks_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stocks_api.Controllers
{
    [Route("api/[controller]")]
    public class StockValuesController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public StockValuesController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<StockValues> GetStockValues(int id)
        {

            List<StockValues> stockValues = new List<StockValues>();
            using (StreamReader reader = new StreamReader($"{_webHostEnvironment.ContentRootPath}/json/StockValues.json"))
            {
                stockValues = JsonConvert.DeserializeObject<List<StockValues>>(reader.ReadToEnd());
            }
            var stock = stockValues.Where(stock => stock.StockId == id);

            return stock;
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

