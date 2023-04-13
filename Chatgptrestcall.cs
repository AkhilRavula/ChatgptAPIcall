using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chatgptcall
{
    public class Chatgptrestcall
    {
        private readonly string _apikey;
        private readonly HttpClient _httpClient;

        public Chatgptrestcall(string apikey)
        {
            _apikey = apikey;
            _httpClient = new HttpClient();
        }

        public async Task<ChatGPTResponseStructure> GetResponse(string inputtext)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.openai.com/v1/completions"),
                Headers =
                {
                    { "Authorization", $"Bearer {_apikey}" },
                    
                },
               // new StringContent(requestString, Encoding.UTF8, "application/json");
            Content = new StringContent
                (JsonConvert.SerializeObject(new
                {
                    model = "text-davinci-003",
                    prompt = inputtext,
                    max_tokens = 50,
                    temperature = 0.3
                }))
                {
                    Headers =
                    {
                        ContentType= new
                        System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                    }
                }
            };

            var Response = await _httpClient.SendAsync(request);
            Response.EnsureSuccessStatusCode();
            var responsebody =  await Response.Content.ReadAsStringAsync();
            var chtpresponse = JsonConvert.DeserializeObject<ChatGPTResponseStructure>(responsebody);
            return chtpresponse;
        }

    }
}
