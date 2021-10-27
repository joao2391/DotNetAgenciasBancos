using Newtonsoft.Json;

namespace DotNet.Agencias.Bancos
{
    /// <summary>
    /// Classe Agências
    /// </summary>
    public class Agencias
    {
        /// <summary>
        /// Array de valores retornados do tipo Agencia
        /// </summary>
        [JsonProperty("value")]
        public Agencia[] Value { get; set; }
    }
}
