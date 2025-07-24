using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AI_Layer.AI_Models.Gemini
{
    public partial class Gemini
    {
        private object _RequestBody()
        {
            var parts = new List<object>
            {
                new { text = Prompt }
            };

            if (Images != null)
            {
                parts.AddRange(Images.Select(img => new
                {
                    inline_data = new
                    {
                        mime_type = "image/jpeg",
                        data = img
                    }
                }));
            }

            var requestBody = new
            {
                contents = new[]
                {
                    new { parts = parts.ToArray() }
                },
                generationConfig = new
                {
                    maxOutputTokens = this.MaxTokens,
                    temperature = this.Temperature,
                    topP = 0,
                    topK = 1
                }
            };

            return requestBody;
        }
        private StringContent _PrepareRequestBody()
        {

            var requestBody = _RequestBody();
            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            return content;
        }
        private async Task<HttpResponseMessage> _SendToGeminiAsync()
        {
            var content = _PrepareRequestBody();
            var response = await _httpClient.PostAsync(_url, content);
            response.EnsureSuccessStatusCode();
            return response;
        }
        private string _FilterResult(ref string? result)
        {
            if(string.IsNullOrEmpty(result))
                return string.Empty;
            result = result.Trim();
            if (result.StartsWith("```"))
                result = result.Substring(3);
            if (result.EndsWith("```"))
                result = result.Substring(0, result.Length - 3);

            return result;
        }
        public async Task<string?> _GetResponse()
        {
            var response = await _SendToGeminiAsync();
            var responseBody = await response.Content.ReadAsStringAsync();
            dynamic? result = JsonConvert.DeserializeObject(responseBody);
            string? FilteredResult = result?.candidates?[0]?.content?.parts?[0]?.text;
            _FilterResult(ref FilteredResult);
            return FilteredResult;
        }
        public async Task<string?> TextGenerate(string PromptText)
        {
            Prompt = PromptText;
            return await _GetResponse();
        }
        public async Task<string?> TextGenerate(string PromptText, IList<string>? images = null)
        {
            Prompt = PromptText;
            Images = images;
            return await _GetResponse();
        }

    }
}
