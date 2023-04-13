using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chatgptcall
{
    public class ChatGPTResponseStructure
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("object")]
        public string _object { get; set; }

        [JsonPropertyName("created")]
        public int created { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("choices")]
        public List<ChatGPTChoice> Choices { get; set; }

        [JsonPropertyName("usage")]
        public ChatGPTUsuage Usuages { get; set; }

    }

    public class ChatGPTChoice
    {
        [JsonPropertyName("text")]
        public string text { get; set; }



    }

    public class ChatGPTUsuage
    {
        [JsonPropertyName("prompt_tokens")]
        public double prompttokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public double Completiontokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public double totaltokens { get; set; }
    }
}
