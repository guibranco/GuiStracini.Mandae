// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 12-26-2022
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="ReverseRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Transport
{
    /// <summary>
    /// Class ReverseRequest. This class cannot be inherited.
    /// Implements the <see cref="GuiStracini.Mandae.Transport.Request" />
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.Request" />
    public sealed class ReverseRequest : Request
    {
        //        {
        //    "remetente": {
        //        "nome": "Anna Dainesse",
        //        "inscricaoEstadual": null,
        //        "email": "pedido@editorainovacao.com.br",
        //        "telefone": "1132031502",
        //        "endereco": {
        //            "codigoPostal": "01530020",
        //            "logradouro": "Rua Albina Barbosa",
        //            "numero": "210",
        //            "complemento": null,
        //            "bairro": "Aclimacao",
        //            "cidade": "Sao Paulo",
        //            "uf": "SP",
        //            "pais": "Brasil",
        //            "referencia": "Apart 151a Andar15"
        //        }
        //    },
        //    "deliveryType": null,
        //    "comSeguro": true,
        //    "valorDeclarado": 150,
        //    "comEmbalagem": false,
        //    "destino": {
        //        "id": 1235751,
        //        "nome": null,
        //        "logradouro": "Rua Itanhaém",
        //        "bairro": "Vila Prudente",
        //        "cep": "03137020",
        //        "cidade": "São Paulo",
        //        "numero": "527",
        //        "complemento": null,
        //        "uf": "SP",
        //        "ativo": true,
        //        "remetente": "Editora Inovação LTDA",
        //        "etiqueta": null,
        //        "latitude": -23.5812076,
        //        "longitude": -46.5739919,
        //        "coletaHabilitada": true,
        //        "logisticaReversaHabilitada": true,
        //        "codigoPostal": "03137020",
        //        "pais": "Brasil"
        //    },
        //    "tipoEntrega": "SEDEX",
        //    "destinatario": {
        //        "nome": null,
        //        "email": "sac@vitrinedoartesanato.com.br",
        //        "endereco": {
        //            "id": 1235751,
        //            "nome": null,
        //            "logradouro": "Rua Itanhaém",
        //            "bairro": "Vila Prudente",
        //            "cep": "03137020",
        //            "cidade": "São Paulo",
        //            "numero": "527",
        //            "complemento": null,
        //            "uf": "SP",
        //            "ativo": true,
        //            "remetente": "Editora Inovação LTDA",
        //            "etiqueta": null,
        //            "latitude": -23.5812076,
        //            "longitude": -46.5739919,
        //            "coletaHabilitada": true,
        //            "logisticaReversaHabilitada": true,
        //            "codigoPostal": "03137020",
        //            "pais": "Brasil"
        //        }
        //    },
        //    "original": {
        //        "id": 1965828,
        //        "urlFoto": null,
        //        "referencia": "2116559",
        //        "qrCodes": ["VTR0001184271"],
        //        "observacao": null,
        //        "idOrdemServico": 173208,
        //        "numeroOrdemServico": "OS173809/2018",
        //        "situacao": 6,
        //        "codigoSituacao": "Entregue",
        //        "nomeSituacao": "Entregue",
        //        "servicoEnvio": 9,
        //        "codigoServicoEnvio": "MandaeEconomico",
        //        "nomeExibicaoServicoEnvio": "Econômico",
        //        "comprimento": 45,
        //        "altura": 4,
        //        "largura": 39,
        //        "diametro": null,
        //        "peso": 940,
        //        "codigoInterno": null,
        //        "codigoRastreamento": "VTR0001184271",
        //        "codigoRastreioTransportadora": "1965828",
        //        "valor": 9.35,
        //        "custoInterno": 4.75,
        //        "destinatario": {
        //            "id": 1779636,
        //            "nome": "Anna Dainesse",
        //            "cpf": "10307954870",
        //            "cnpj": null,
        //            "email": "pedido@editorainovacao.com.br",
        //            "telefone": "11  32031502",
        //            "inscricaoEstadual": null,
        //            "endereco": {
        //                "id": 1853986,
        //                "logradouro": "Rua Albina Barbosa",
        //                "bairro": "Aclimacao",
        //                "complemento": null,
        //                "cidade": "Sao Paulo",
        //                "uf": "SP",
        //                "cep": "01530020",
        //                "numero": "210",
        //                "pais": "BR",
        //                "referencia": "Apart 151a Andar15",
        //                "codigoPostal": "01530020"
        //            }
        //        },
        //        "urlEtiqueta": null,
        //        "ar": false,
        //        "maoPropria": false,
        //        "valorDeclarado": null,
        //        "embalagem": null,
        //        "codigoEmbalagem": null,
        //        "etiquetaEnvio": 22,
        //        "codigoEtiquetaEnvio": "Loggi",
        //        "urlRastreamento": "https://app.mandae.com.br/rastreamento/VTR0001184271",
        //        "dataHoraPreparandoRemessas": 1532466207660,
        //        "dataHoraConferida": 1532475430423,
        //        "dataPrevistaPostagem": 1532487600000,
        //        "dataHoraEnviada": 1532554894297,
        //        "dataHoraEntrega": 1532614680000,
        //        "dataHoraExtraviada": null,
        //        "dataHoraPrimeiraTentativaEntrega": null,
        //        "dataHoraPrevisaoEntrega": 1533006000000,
        //        "transportadora": "Loggi",
        //        "prazoMinimo": 4,
        //        "prazoMaximo": 4,
        //        "prazoCliente": 4,
        //        "prazoTransportadora": 1,
        //        "quantidadeImpressoesPeloCliente": 0,
        //        "bloqueio": null,
        //        "chaveAcessoNFe": "35180705944298000101550010006519551282352570",
        //        "jaFoiImpressa": false,
        //        "mandaeEscolhe": true,
        //        "platafoma": "api",
        //        "tipoDocumentoOrigem": "NFe"
        //    }
        //}
        //        {
        //    "remetente": {
        //        "endereco": {
        //            "codigoPostal": "03177010",
        //            "logradouro": "Rua Doutor João Batista de Lacerda",
        //            "numero": "192",
        //            "bairro": "Quarta Parada",
        //            "cidade": "São Paulo",
        //            "uf": "SP",
        //            "pais": "Brasil"
        //        },
        //        "nome": "Teste",
        //        "email": "teste@teste.com",
        //        "telefone": "1126061521",
        //        "documento": "38834781805"
        //    },
        //    "deliveryType": null,
        //    "comSeguro": true,
        //    "valorDeclarado": 152,
        //    "comEmbalagem": false,
        //    "destino": {
        //        "id": 1235751,
        //        "nome": null,
        //        "logradouro": "Rua Itanhaém",
        //        "bairro": "Vila Prudente",
        //        "cep": "03137020",
        //        "cidade": "São Paulo",
        //        "numero": "527",
        //        "complemento": null,
        //        "uf": "SP",
        //        "ativo": true,
        //        "remetente": "Editora Inovação LTDA",
        //        "etiqueta": null,
        //        "latitude": -23.5812076,
        //        "longitude": -46.5739919,
        //        "coletaHabilitada": true,
        //        "logisticaReversaHabilitada": true,
        //        "codigoPostal": "03137020",
        //        "pais": "Brasil"
        //    },
        //    "tipoEntrega": "SEDEX",
        //    "destinatario": {
        //        "nome": null,
        //        "email": "sac@vitrinedoartesanato.com.br",
        //        "endereco": {
        //            "id": 1235751,
        //            "nome": null,
        //            "logradouro": "Rua Itanhaém",
        //            "bairro": "Vila Prudente",
        //            "cep": "03137020",
        //            "cidade": "São Paulo",
        //            "numero": "527",
        //            "complemento": null,
        //            "uf": "SP",
        //            "ativo": true,
        //            "remetente": "Editora Inovação LTDA",
        //            "etiqueta": null,
        //            "latitude": -23.5812076,
        //            "longitude": -46.5739919,
        //            "coletaHabilitada": true,
        //            "logisticaReversaHabilitada": true,
        //            "codigoPostal": "03137020",
        //            "pais": "Brasil"
        //        }
        //    },
        //    "original": null
        //}


        //original = Order.cs
        //destinatario = RecipientV1.cs
    }
}