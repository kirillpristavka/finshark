using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Newtonsoft.Json;

namespace api.Services
{
    public class FMPService : IFMPService
    {
        private HttpClient _httpClient;
        private IConfiguration _config;
        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try {
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/stable/profile?symbol={symbol}&apikey={_config["FMPKey"]}");

                if(result.IsSuccessStatusCode) {
                    var content = await result.Content.ReadAsStringAsync();

                    if(content == null) {
                        Console.WriteLine("No content");
                    }

                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks[0];
                    
                    if(stock != null) {
                        Console.WriteLine("Stock exists");

                        return stock.ToStockFromFMP();
                    }

                    return null;
                }

                return null;
            } catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}