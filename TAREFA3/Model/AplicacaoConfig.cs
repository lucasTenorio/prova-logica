using Newtonsoft.Json;

namespace TAREFA3.Model
{
    [JsonObject("configuracaoCaminho")]
    internal class AplicacaoConfig
    {
        [JsonProperty("caminho")]
        public string Caminho { get; set; }
        
        [JsonProperty("destino")]
        public string Destino { get; set; }
        
        [JsonProperty("urlCep")]
        public string UrlCep { get; set; }
    }
}