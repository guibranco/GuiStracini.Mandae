# Mandaê SDK

Cliente (não oficial) da API da Mandaê para projetos .NET.

For a english version, please [follow me](/README.md)

[![GitHub license](https://img.shields.io/github/license/guibranco/GuiStracini.Mandae)](https://github.com/guibranco/GuiStracini.Mandae)
[![Time tracker](https://wakatime.com/badge/github/guibranco/GuiStracini.Mandae.svg)](https://wakatime.com/badge/github/guibranco/CGuiStracini.Mandae)
[![GitHub issues by-label](https://img.shields.io/github/issues/guibranco/guistracini.mandae/help%20wanted.svg)](https://github.com/guibranco/guistracini.mandae/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)

![Mandae logo](https://raw.githubusercontent.com/guibranco/GuiStracini.Mandae/main/logo.png)

Este é um cliente **não oficial** da [API da Mandaê V2](https://dev.mandae.com.br/api/index.html)

---

## CI/CD

| Build status | Last commit | Tests | Coverage | Code Smells | LoC |
|--------------|-------------|-------|----------|-------------|-----|
| [![Build status](https://ci.appveyor.com/api/projects/status/2et11cwujyfnsruj/branch/main?svg=true)](https://ci.appveyor.com/project/guibranco/guistracini-mandae/branch/main) | [![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/GuiStracini.Mandae/main)](https://github.com/guibranco/GuiStracini.Mandae) | [![AppVeyor tests (branch)](https://img.shields.io/appveyor/tests/guibranco/GuiStracini-Mandae/main?compact_message)](https://ci.appveyor.com/project/guibranco/guistracini-mandae) | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=coverage&branch=main)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae) | [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=code_smells&branch=main)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae) | [![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=ncloc&branch=main)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae) |

## Code Quality (main branch)

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/727443824fe244be840dc6ba2e444c9e)](https://www.codacy.com/gh/guibranco/GuiStracini.Mandae/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guibranco/GuiStracini.Mandae&amp;utm_campaign=Badge_Grade)
[![Codacy Badge](https://app.codacy.com/project/badge/Coverage/727443824fe244be840dc6ba2e444c9e)](https://www.codacy.com/gh/guibranco/GuiStracini.Mandae/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guibranco/GuiStracini.Mandae&amp;utm_campaign=Badge_Grade)

[![codecov](https://codecov.io/gh/guibranco/GuiStracini.Mandae/branch/main/graph/badge.svg)](https://codecov.io/gh/guibranco/GuiStracini.Mandae)
[![CodeFactor](https://www.codefactor.io/repository/github/guibranco/GuiStracini.Mandae/badge)](https://www.codefactor.io/repository/github/guibranco/GuiStracini.Mandae)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)

[![Maintainability](https://api.codeclimate.com/v1/badges/5e1cd09aba4cc90d08d5/maintainability)](https://codeclimate.com/github/guibranco/GuiStracini.Mandae/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/5e1cd09aba4cc90d08d5/test_coverage)](https://codeclimate.com/github/guibranco/GuiStracini.Mandae/test_coverage)

[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=sqale_index)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)

[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=bugs)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=guibranco_GuiStracini.Mandae&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=guibranco_GuiStracini.Mandae)

[![DeepSource](https://app.deepsource.com/gh/guibranco/GuiStracini.Mandae.svg/?label=active+issues&show_trend=true&token=IeLgGedanFVCj0wxFnPqF3V4)](https://app.deepsource.com/gh/guibranco/GuiStracini.Mandae/?ref=repository-badge)

---

## Funcionalidades

Este cliente suporta as seguintes operações/funcionalidades da API:

 1. Obter cotações para uma entrega (necessário informar CEP de destino e dimensões da embalagem).
 2. Agendar uma coleta (registra uma coleta no centro de distribuição com um ou mais pacotes. Cada pacote pode conter um ou mais produto/sku).
 3. Obtém acompanhamento da entrega (Obtém todas etapas disponíveis de um pacote - o código de rastreio pode ser informado no momento da criação pelo cliente ou gerado pela Mandaê e notificado via webhook).
 4. Esquema dos webhooks (Models para webhook, prontos para implementar).
 5. **Experimental** Pesquisa pedidos (API V1 - API privada - pode não funcionar).
 6. **Experimental** Pesquisa ocorrências (API V1 - API privada - pode não funcionar) [Issue #1](https://github.com/guibranco/GuiStracini.Mandae/issues/1) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted)
 7. **Experimental** Pesquisa devoluções (API V1 - API privada - pode não funcionar). [Issue #2](https://github.com/guibranco/GuiStracini.Mandae/issues/2) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted)
 8. **Experimental** Solicitar logística reversa (API V1 - API privada - pode não funcionar). [Issue #3](https://github.com/guibranco/GuiStracini.Mandae/issues/3) ![GitHub labels](https://img.shields.io/github/labels/guibranco/BancosBrasileiros/help%20wanted)

---

## Installation

### Github Releases

[![GitHub last release](https://img.shields.io/github/release-date/guibranco/GuiStracini.Mandae.svg?style=flat)](https://github.com/guibranco/GuiStracini.Mandae) [![Github All Releases](https://img.shields.io/github/downloads/guibranco/GuiStracini.Mandae/total.svg?style=flat)](https://github.com/guibranco/GuiStracini.Mandae)

Baixe o arquivo zip mais recente na página [Release](https://github.com/GuiBranco/GuiStracini.Mandae/releases).

### Nuget package manager

| Package | Version | Downloads |
|------------------|:-------:|:-------:|
| **GuiStracini.Mandae** | [![GuiStracini.Mandae NuGet Version](https://img.shields.io/nuget/v/GuiStracini.Mandae.svg?style=flat)](https://www.nuget.org/packages/GuiStracini.Mandae/) | [![GuiStracini.Mandae NuGet Downloads](https://img.shields.io/nuget/dt/GuiStracini.Mandae.svg?style=flat)](https://www.nuget.org/packages/GuiStracini.Mandae/) |

---

## Utilização

Vide o arquivo em [inglês](readme.md#usage) para exemplos de utilização.

---

## Release notes

- Release v6.0.0 e superior - Métodos DEPRECIADOS: Get Latest Order
- Release v5.0.0 e superior - Métodos DEPRECIADOS: Large Request, Cancel Request, Cancel Item Request
- Release v3.0.0 e superior alteram a forma de autenticação do endpoint V1. Agora use o par e-mail/senha do painel administrativo da Mandaê para se autenticar nos endpoints V1.
- Release v1.4.1 e superior inclui uma versão experimental (privada) do endpoint V1 para busca/pesquisa de pedidos (o mesmo disponível no painel da Mandaê).

> **Warning**
>
> API V1 não é oficialmente pública, não existem garantias que essas funcionalidades irão continuar funcionando.

---
