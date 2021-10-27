using Newtonsoft.Json;

namespace DotNet.Agencias.Bancos
{
    /// <summary>
    /// Classe Agencia
    /// </summary>
    public class Agencia
    {
        /// <summary>
        /// Nome da Instituição Financeira
        /// </summary>
        [JsonProperty("NomeIf")]
        public string InstituicaoFinanceira { get; set; }
        /// <summary>
        /// Segmento da Instituição Financeira
        /// </summary>
        public string Segmento { get; set; }
        /// <summary>
        /// Nome da Agência
        /// </summary>
        public string NomeAgencia { get; set; }
        /// <summary>
        /// Endereço da Agência
        /// </summary>
        public string Endereco { get; set; }
        /// <summary>
        /// Número da Agência
        /// </summary>
        public string Numero { get; set; }
        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; set; }
        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro { get; set; }
        /// <summary>
        /// CEP
        /// </summary>
        public string Cep { get; set; }
        /// <summary>
        /// Município
        /// </summary>
        public string Municipio { get; set; }
        /// <summary>
        /// UF do Estado
        /// </summary>        
        public string Uf { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }
    }
}
