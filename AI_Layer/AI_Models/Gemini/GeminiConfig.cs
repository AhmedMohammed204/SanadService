using AI_Layer.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace AI_Layer.AI_Models.Gemini
{
    public partial class Gemini : IGenerativeAI
    {

        private readonly HttpClient _httpClient;
        private string _Key;
        private string _url;
        public string Prompt { get; set; } = "";
        public IList<string>? Images { get; set; } = null;
        public Gemini(string Key)
        {
            _Key = Key;
            _httpClient = new HttpClient();
            _url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_Key}";

        }

        public double Temperature { get; set; } = 0.0;
        public int MaxTokens { get; set; } = 8192;

        void IGenerativeAI.SetConfig(double temperature, int maxTokens)
        {
            this.Temperature = temperature;
            this.MaxTokens = maxTokens;
        }
    }
}
