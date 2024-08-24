
namespace Data
{
    public class OllamaApiSettings
    {
        public string BaseUrl { get; set; } = "localhost:11434";
        public string EmbeddingsModel { get; set; } = "mxbai-embed-large";
        public string LLMModel { get; set; } = "mistral:latest";
    }
}
