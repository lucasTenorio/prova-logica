using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace TAREFA1.Model
{
    [JsonObject("configuracaoCaminho")]
    public class AplicacaoConfig
    {
        [JsonProperty("caminho")]
        public string Caminho { get; set; }
        [JsonProperty("destino")]
        public string Destino { get; set; }
    }
}
