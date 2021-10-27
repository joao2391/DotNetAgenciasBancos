using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.Agencias.Bancos
{
    /// <summary>
    /// Interface do HttpClientWrapper
    /// </summary>
    public interface IHttpClientWrapper
    {
        /// <summary>
        /// Método responsável por chamar a url
        /// dos Correios.
        /// </summary>        
        /// <param name="requestMessage">Objeto da Requisição</param>
        /// <returns>Task de HttpResponseMessage</returns>
        Task<HttpResponseMessage> GetAsync(HttpRequestMessage requestMessage);
    }
}
