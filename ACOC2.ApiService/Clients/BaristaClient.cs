using ACOC2.Shared.Contracts.Barista;

namespace ACOC2.CoffeeApi.Clients
{
    public class BaristaClient
    {
        private readonly HttpClient httpClient;

        public BaristaClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<CoffeeMenuResponse> GetCoffeeMenu() =>  httpClient.GetFromJsonAsync<CoffeeMenuResponse>("/products/menu");
        
    }
}
