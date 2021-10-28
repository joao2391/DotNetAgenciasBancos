using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DotNet.Agencias.Bancos
{
    /// <summary>
    /// Classe com função que busca informaçãoes das agências dos Bancos.
    /// </summary>
    public class AgenciasBancos : IAgenciasBancos
    {
        private readonly IHttpClientWrapper _httpClient;

        /// <summary>
        /// Construtor para instanciar a classe HttpClientWrapper via injeção de dependência.
        /// </summary>
        /// <param name="httpClientWrapper">Objeto HttpClientWrapper</param>
        public AgenciasBancos(IHttpClientWrapper httpClientWrapper)
        {
            _httpClient = httpClientWrapper;
        }

        /// <summary>
        /// Busca as agências localizadas de acordo com
        /// o CEP informado.
        /// </summary>
        /// <param name="cep">CEP.</param>
        /// <param name="quantidadeRetorno">Quantidade de itens.</param>
        /// <returns cref="Agencias">Objeto do tipo Agencias</returns>
        /// <exception cref="HttpRequestException">HttpRequestException</exception>
        /// <exception cref="JsonSerializationException">JsonSerializationException</exception>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public async Task<Agencias> GetAgenciasByCepAsync(string cep, int quantidadeRetorno = 1)
        {
            if (string.IsNullOrEmpty(cep))
            {
                throw new ArgumentNullException(cep, "cep não pode ser vazio");

            }

            try
            {
                var agencias = await BuildAgenciasByCepAsync(cep, quantidadeRetorno).ConfigureAwait(false);

                return agencias;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonSerializationException)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca as agências localizadas de acordo com
        /// o município informado.
        /// </summary>
        /// <param name="municipio">Município.</param>
        /// <param name="quantidadeRetorno">Quantidade de itens.</param>
        /// <returns cref="Agencias">Objeto do tipo Agencias</returns>
        /// <exception cref="HttpRequestException">HttpRequestException</exception>
        /// <exception cref="JsonSerializationException">JsonSerializationException</exception>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public async Task<Agencias> GetAgenciasByMunicipioAsync(string municipio, int quantidadeRetorno = 1)
        {
            if (string.IsNullOrEmpty(municipio))
            {
                throw new ArgumentNullException(municipio, "municipio não pode ser vazio");
                
            }

            try
            {
                var municipioMaiusculo = municipio.ToUpper();

                var agencias = await BuildAgenciasByMunicipioAsync(municipioMaiusculo, quantidadeRetorno).ConfigureAwait(false);

                return agencias;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonSerializationException)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca as agências localizadas de acordo com
        /// o Municipio e Banco informados.
        /// </summary>
        /// <param name="municipio">Município da Agência</param>
        /// <param name="nomeBanco">Nome do Banco.</param>
        /// <param name="quantidadeRetorno">Quantidade de itens.</param>
        /// <returns cref="Agencias">Objeto do tipo Agencias</returns>
        /// <exception cref="HttpRequestException">HttpRequestException</exception>
        /// <exception cref="JsonSerializationException">JsonSerializationException</exception>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public async Task<Agencias> GetAgenciasByMunicipioEBancoAsync(string municipio, string nomeBanco, int quantidadeRetorno = 1)
        {
            if (string.IsNullOrEmpty(municipio))
            {
                throw new ArgumentNullException(municipio, "municipio não pode ser vazio");

            }
            if (string.IsNullOrEmpty(nomeBanco))
            {
                throw new ArgumentNullException(nomeBanco, "nomeBanco não pode ser vazio");

            }

            try
            {
                var municipioMaiusculo = municipio.ToUpper();
                var nomeBancoMaiusculo = nomeBanco.ToUpper();

                var agencias = await BuildAgenciasByMunicipioEBancoAsync(municipioMaiusculo, nomeBancoMaiusculo, quantidadeRetorno).ConfigureAwait(false);

                return agencias;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (JsonSerializationException)
            {
                throw;
            }
        }

        #region Private Methods
        private async Task<Agencias> BuildAgenciasByMunicipioAsync(string municipio, int quantidadeRetorno)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://olinda.bcb.gov.br/olinda/servico/Informes_Agencias/versao/v1/odata/Agencias?$top={quantidadeRetorno}&$skip=0&$filter=Municipio%20eq%20'{municipio}'&$format=json&$select=NomeIf,Segmento,NomeAgencia,Endereco,Numero,Complemento,Bairro,Cep,Municipio,UF,Telefone")
            };

            var response = await _httpClient.GetAsync(requestMessage).ConfigureAwait(false);

            if(response is null)
            {
                return new Agencias();
            }

            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var agencias = JsonConvert.DeserializeObject<Agencias>(contentString);

            return agencias;

        }

        private async Task<Agencias> BuildAgenciasByCepAsync(string cep, int quantidadeRetorno)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://olinda.bcb.gov.br/olinda/servico/Informes_Agencias/versao/v1/odata/Agencias?$top={quantidadeRetorno}&$skip=0&$filter=Cep%20eq%20'{cep}'&$format=json&$select=NomeIf,Segmento,NomeAgencia,Endereco,Numero,Complemento,Bairro,Cep,Municipio,UF,Telefone")
            };

            var response = await _httpClient.GetAsync(requestMessage).ConfigureAwait(false);

            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var agencias = JsonConvert.DeserializeObject<Agencias>(contentString);

            return agencias;

        }

        private async Task<Agencias> BuildAgenciasByMunicipioEBancoAsync(string municipio, string nomeBanco, int quantidadeRetorno)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://olinda.bcb.gov.br/olinda/servico/Informes_Agencias/versao/v1/odata/Agencias?$top={quantidadeRetorno}&$skip=0&$filter=Municipio%20eq%20'{municipio}'%20and%20contains(NomeIf%2C'{nomeBanco}')'&$format=json&$select=NomeIf,Segmento,NomeAgencia,Endereco,Numero,Complemento,Bairro,Cep,Municipio,UF,Telefone")
            };

            var response = await _httpClient.GetAsync(requestMessage).ConfigureAwait(false);

            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var agencias = JsonConvert.DeserializeObject<Agencias>(contentString);

            return agencias;

        }

        #endregion
    }
}
