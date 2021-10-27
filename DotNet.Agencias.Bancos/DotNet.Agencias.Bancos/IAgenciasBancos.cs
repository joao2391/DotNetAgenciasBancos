using System.Threading.Tasks;

namespace DotNet.Agencias.Bancos
{
    /// <summary>
    /// Interface para a classe AgenciasBancos
    /// </summary>
    public interface IAgenciasBancos
    {
        // <summary>
        /// Busca as agências localizadas de acordo com
        /// o município informado.
        /// </summary>
        /// <param name="municipio">Município.</param>
        /// <param name="quantidadeRetorno">Quantidade de itens.</param>
        /// <returns cref="Agencias">Objeto do tipo Agencias</returns>
        Task<Agencias> GetAgenciasByMunicipioAsync(string municipio, int quantidadeRetorno);

        /// <summary>
        /// Busca as agências localizadas de acordo com
        /// o Municipio e Banco informados.
        /// </summary>
        /// <param name="municipio">Município da Agência</param>
        /// <param name="nomeBanco">Nome do Banco.</param>
        /// <param name="quantidadeRetorno">Quantidade de itens.</param>
        /// <returns cref="Agencias">Objeto do tipo Agencias</returns>
        Task<Agencias> GetAgenciasByMunicipioEBancoAsync(string municipio, string nomeBanco, int quantidadeRetorno);

        /// <summary>
        /// Busca as agências localizadas de acordo com
        /// o CEP informado.
        /// </summary>
        /// <param name="cep">CEP.</param>
        /// <param name="quantidadeRetorno">Quantidade de itens.</param>
        /// <returns cref="Agencias">Objeto do tipo Agencias</returns>
        Task<Agencias> GetAgenciasByCepAsync(string cep, int quantidadeRetorno);
    }
}
