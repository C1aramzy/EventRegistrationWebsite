using System.Net.Http;
using System.Net.Http.Json;

namespace EventRegistrationWebsite.Services
{
    public class OneMapService
    {
        private readonly HttpClient _http;

        public OneMapService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<OneMapResult>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<OneMapResult>();

            var url =
                $"https://www.onemap.gov.sg/api/common/elastic/search?searchVal={Uri.EscapeDataString(query)}&returnGeom=N&getAddrDetails=Y&pageNum=1";

            var response = await _http.GetFromJsonAsync<OneMapSearchResponse>(url);

            return response?.results ?? new List<OneMapResult>();
        }

        public class OneMapSearchResponse
        {
            public List<OneMapResult>? results { get; set; }
        }

        public class OneMapResult
        {
            public string? BUILDING { get; set; }
            public string? ROAD_NAME { get; set; }
            public string? ADDRESS { get; set; }
            public string? POSTAL { get; set; }
        }
    }
}

