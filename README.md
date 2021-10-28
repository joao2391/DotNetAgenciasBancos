# DotNetAgenciasBancos [![Nuget](https://img.shields.io/nuget/v/DotNetAgenciasBancos)](https://www.nuget.org/packages/DotNetAgenciasBancos/) ![Nuget](https://img.shields.io/nuget/dt/DotNetAgenciasBancos)

DotNet.Agencias.Bancos is a .Net library that helps you to get brazilian's bank agencies

## Notes
Version 1.0.0:

- BETA

## Installation

Use the package manager to install.

```bash
Install-Package DotNetAgenciasBancos  -Version 1.0.0
```

## Usage

```C#
services.<ChooseYours><IHttpClientWrapper, HttpClientWrapper>();
services.<ChooseYours><IAgenciasBancos, AgenciasBancos>();

```

### Features
```C#
var agenciasByCep = await GetAgenciasByCepAsync("03114-000", 10);
// agenciasByCep.Value[0].InstituicaoFinanceira -> BANCO SANTANDER (BRASIL) S.A.
// agenciasByCep.Value[0].Segmento -> Banco Múltiplo
// agenciasByCep.Value[0].NomeAgencia -> 001-1802 SELECT MOOCA-SP
// agenciasByCep.Value[0].Endereco -> AV PAES DE BARROS
// agenciasByCep.Value[0].Numero -> 2621
// agenciasByCep.Value[0].Complemento -> ""
// agenciasByCep.Value[0].Bairro -> MOOCA
// agenciasByCep.Value[0].Cep -> 03114-000
// agenciasByCep.Value[0].Municipio -> SAO PAULO
// agenciasByCep.Value[0].Uf -> SP
// agenciasByCep.Value[0].Telefone -> 23929400

var agenciasByMunicipio = await GetAgenciasByMunicipioAsync("SAO PAULO", 10);
// agenciasByMunicipio.Value[0].InstituicaoFinanceira -> BANCO SANTANDER (BRASIL) S.A.
// agenciasByMunicipio.Value[0].Segmento -> Banco Múltiplo
// agenciasByMunicipio.Value[0].NomeAgencia -> 001-1802 SELECT MOOCA-SP
// agenciasByMunicipio.Value[0].Endereco -> AV PAES DE BARROS
// agenciasByMunicipio.Value[0].Numero -> 2621
// agenciasByMunicipio.Value[0].Complemento -> ""
// agenciasByMunicipio.Value[0].Bairro -> MOOCA
// agenciasByMunicipio.Value[0].Cep -> 03114-000
// agenciasByMunicipio.Value[0].Municipio -> SAO PAULO
// agenciasByMunicipio.Value[0].Uf -> SP
// agenciasByMunicipio.Value[0].Telefone -> 23929400

var agenciasByMunicipioEBanco = await GetAgenciasByMunicipioEBancoAsync("SAO PAULO", "SANTANDER", 10);
// agenciasByMunicipioEBanco.Value[0].InstituicaoFinanceira -> BANCO SANTANDER (BRASIL) S.A.
// agenciasByMunicipioEBanco.Value[0].Segmento -> Banco Múltiplo
// agenciasByMunicipioEBanco.Value[0].NomeAgencia -> 001-1802 SELECT MOOCA-SP
// agenciasByMunicipioEBanco.Value[0].Endereco -> AV PAES DE BARROS
// agenciasByMunicipioEBanco.Value[0].Numero -> 2621
// agenciasByMunicipioEBanco.Value[0].Complemento -> ""
// agenciasByMunicipioEBanco.Value[0].Bairro -> MOOCA
// agenciasByMunicipioEBanco.Value[0].Cep -> 03114-000
// agenciasByMunicipioEBanco.Value[0].Municipio -> SAO PAULO
// agenciasByMunicipioEBanco.Value[0].Uf -> SP
// agenciasByMunicipioEBanco.Value[0].Telefone -> 23929400

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)