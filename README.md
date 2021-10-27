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
You will get an object with an object's array with Nome, CEP, Endereço and Situação
```C#
var agencias = GetAgenciasAsync();
// agencias.Value[0].InstituicaoFinanceira -> BANCO SANTANDER (BRASIL) S.A.
// agencias.Value[0].Segmento -> Banco Múltiplo
// agencias.Value[0].NomeAgencia -> 001-1802 SELECT MOOCA-SP
// agencias.Value[0].Endereco -> AV PAES DE BARROS
// agencias.Value[0].Numero -> 2621
// agencias.Value[0].Complemento -> ""
// agencias.Value[0].Bairro -> MOOCA
// agencias.Value[0].Cep -> 03114-000
// agencias.Value[0].Municipio -> SAO PAULO
// agencias.Value[0].Uf -> SP
// agencias.Value[0].Telefone -> 23929400
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)