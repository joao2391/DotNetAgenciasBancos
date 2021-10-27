using Moq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DotNet.Agencias.Bancos.Test
{
    public class AgenciasBancosTests
    {
        private AgenciasBancos _agenciasBancos;
        private readonly string fakeContent = string.Empty;

        public AgenciasBancosTests()
        {
            fakeContent = File.ReadAllText(@".\FakeData.json");
        }

        [Fact]
        public async Task Should_Return_Agencias_From_GetAgenciasByMunicipioAsync_When_All_Params_is_Full()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _agenciasBancos = new AgenciasBancos(mockHttp.Object);

            var result = await _agenciasBancos.GetAgenciasByMunicipioAsync(Constants.MUNICIPIO_AGENCIA_SP, Constants.CEM);

            Assert.NotNull(result);
            Assert.IsType<Agencias>(result);            

        }

        [Fact]
        public async Task Should_Return_Agencias_From_GetAgenciasByMunicipioEBancoAsync_When_All_Params_is_Full()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _agenciasBancos = new AgenciasBancos(mockHttp.Object);

            var result = await _agenciasBancos.GetAgenciasByMunicipioEBancoAsync(Constants.MUNICIPIO_AGENCIA_SP, Constants.NOME_BANCO, Constants.CEM);

            Assert.NotNull(result);
            Assert.IsType<Agencias>(result);

        }

        [Fact]
        public async Task Should_Return_Agencias_From_GetAgenciasByCepAsync_When_All_Params_is_Full()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _agenciasBancos = new AgenciasBancos(mockHttp.Object);

            var result = await _agenciasBancos.GetAgenciasByCepAsync(Constants.CEP, Constants.CEM);

            Assert.NotNull(result);
            Assert.IsType<Agencias>(result);

        }

        [Fact]
        public async Task Should_Return_ArgumentNullException_From_GetAgenciasByMunicipioAsync_When_Municipio_Is_Empty()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _agenciasBancos = new AgenciasBancos(mockHttp.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _agenciasBancos.GetAgenciasByMunicipioAsync("", Constants.CEM));

        }

        [Fact]
        public async Task Should_Return_ArgumentNullException_From_GetAgenciasByMunicipioEBancoAsync_When_Municipio_Is_Empty()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _agenciasBancos = new AgenciasBancos(mockHttp.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _agenciasBancos.GetAgenciasByMunicipioEBancoAsync("", Constants.NOME_BANCO, Constants.CEM));

        }

        [Fact]
        public async Task Should_Return_ArgumentNullException_From_GetAgenciasByMunicipioEBancoAsync_When_NomeBanco_Is_Empty()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _agenciasBancos = new AgenciasBancos(mockHttp.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _agenciasBancos.GetAgenciasByMunicipioEBancoAsync(Constants.MUNICIPIO_AGENCIA_SP, "", Constants.CEM));

        }

        [Fact]
        public async Task Should_Return_ArgumentNullException_From_GetAgenciasByCepAsync_When_NomeBanco_Is_Empty()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContent)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _agenciasBancos = new AgenciasBancos(mockHttp.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _agenciasBancos.GetAgenciasByCepAsync("", Constants.CEM));

        }
    }
}
