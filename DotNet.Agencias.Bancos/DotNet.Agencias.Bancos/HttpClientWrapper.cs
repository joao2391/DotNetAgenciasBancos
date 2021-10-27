using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.Agencias.Bancos
{
    /// <summary>
    /// Classe utilizada para abstrair as chamadas HTTP
    /// </summary>
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public HttpClientWrapper()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// Realiza a chamada GET para a url
        /// do BACEN
        /// </summary>
        /// <param name="requestMessage">Objeto da Requisição</param>
        /// <returns>Task de HttpResponseMessage</returns>
        public virtual async Task<HttpResponseMessage> GetAsync(HttpRequestMessage requestMessage)
        {
            var result = await _client.SendAsync(requestMessage).ConfigureAwait(false);

            return result;

        }
    }
}
