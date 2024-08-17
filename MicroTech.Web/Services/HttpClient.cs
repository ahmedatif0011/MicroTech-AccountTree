using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MicroTech.Web.Services
{
    public interface IHttpClientAPI
    {
        public Task<string> Call(RestfulAPICallingDTO request);
    }
    public class HttpClientAPI : IHttpClientAPI
    {
        private readonly HttpClient _httpClient;
        public HttpClientAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> Call(RestfulAPICallingDTO request)
        {
            if (string.IsNullOrEmpty(request.BaseUrl))
                request.BaseUrl = Settings.DefualtData.URLBase;

            string apiUrl = BuildUrl(request.BaseUrl, request.APIPath, request.queryParams);

            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(apiUrl),
                Method = request.Method,

            };
            if (request.Method != HttpMethod.Get && !string.IsNullOrEmpty(request.Body))
                httpRequestMessage.Content = new StringContent(request.Body, Encoding.UTF8, "application/json");
            if (request.isAuth)
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", request.token);

            if (request.Headers != null && request.Headers.Any())
            {
                foreach (var item in request.Headers)
                {
                    // Ensure you're not trying to add the Authorization header again here
                    if (!item.key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        httpRequestMessage.Headers.Add(item.key, item.value);
                    }
                }
            }

            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await _httpClient.SendAsync(httpRequestMessage);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            // Read and return the response content
            return await res.Content.ReadAsStringAsync();

        }
        private string BuildUrl(string baseAddress, string path, params (string key, string value)[] queryParams)
        {
            // Initialize the UriBuilder with the base address
            UriBuilder builder = new UriBuilder(baseAddress)
            {
                Path = path
            };

            // Initialize a NameValueCollection for the query string parameters
            var query = HttpUtility.ParseQueryString(builder.Query);

            // Add each query string parameter to the collection
            if (queryParams != null)
            {
                foreach (var param in queryParams)
                {
                    query[param.key] = param.value;
                }
            }

            // Assign the constructed query string to the UriBuilder
            builder.Query = query.ToString();

            // Return the resulting URL as a string
            return builder.ToString();
        }
    }
    public class RestfulAPICallingDTO
    {
        public HttpMethod Method { get; set; }
        public string BaseUrl { get; set; }
        public string APIPath { get; set; }
        public (string key, string value)[] queryParams { get; set; }
        public (string key, string value)[] Headers { get; set; }
        public string Body { get; set; }
        public bool isAuth { get; set; }
        public string token { get; set; }

    }
    public enum RestfulAPIMethods
    {
        GET,
        POST,
        PUT,
        DELETE,
    }
}
