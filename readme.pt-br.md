# Mandaê SDK

SDK da API da Mandaê (não oficial) para projetos .NET.

For a english version, please [follow me](/README.md)

[![Build status](https://ci.appveyor.com/api/projects/status/2et11cwujyfnsruj?svg=true)](https://ci.appveyor.com/project/guibranco/guistracini-mandae)
[![GuiStracini.Mandae NuGet Version](https://img.shields.io/nuget/v/GuiStracini.Mandae.svg?style=flat)](https://www.nuget.org/packages/GuiStracini.Mandae/)
[![GuiStracini.Mandae NuGet Downloads](https://img.shields.io/nuget/dt/GuiStracini.Mandae.svg?style=flat)](https://www.nuget.org/packages/GuiStracini.Mandae/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/GuiStracini.Mandae/total.svg?style=flat)](https://github.com/guibranco/GuiStracini.Mandae)
![Last release](https://img.shields.io/github/release-date/guibranco/guistracini.mandae.svg?style=flat)

<img src="https://raw.githubusercontent.com/guibranco/GuiStracini.Mandae/master/Mandae.png" alt="GuiStracini.Mandae" width="150" height="150" />

Este é cliente **não oficial** da **API da Mandaê** *V2*. (https://dev.mandae.com.br/api/index.html)

---

## Release notes

Release v1.4.1 e superior inclui uma versão experimental (privada) do endpoint V1 para busca/pesquisa de pedidos (o mesmo disponível no painel da Mandaê).

**API V1 não é oficialmente pública, não existem garantias que essas funcionalidades irão continuar funcionando.**

**Release v3.0.0 e superior alteram a forma de autenticação do endpoint V1. Agora use o par e-mail/senha do painel administrativo da Mandaê para se autenticar nos endpoints V1.**

**Release v5.0.0 e superior - Métodos DEPRECIADOS: Large Request, Cancel Request, Cancel Item Request**

**Release v6.0.0 e superior - Métodos DEPRECIADOS: Get Latest Order**

----------

## Instalação

Pacote NuGet: [https://www.nuget.org/packages/GuiStracini.Mandae](https://www.nuget.org/packages/GuiStracini.Mandae)

```ps

Install-Package GuiStracini.Mandae

```

---

## Funcionalidades

Este cliente suporta as seguintes operações/funcionalidades da API:
 1. Obter cotações para uma entrega (necessário informar CEP de destino e dimensões da embalagem).
 2. Agendar uma coleta (registra uma coleta no centro de distribuição com um ou mais pacotes. Cada pacote pode conter um ou mais produto/sku).
 3. Obtém acompanhamento da entrega (Obtém todas etapas disponíveis de um pacote - o código de rastreio pode ser informado no momento da criação pelo cliente ou gerado pela Mandaê e notificado via webhook).
 4. Esquema dos webhooks (Models para webhook, prontos para implementar).
 5. **Experimental** Pesquisa pedidos (API V1 - API privada - pode não funcionar).
 6. **Experimental** Pesquisa ocorrênicas (API V1 - API privada - pode não funcionar). **[TODO]**
 7. **Experimental** Pesquisa devoluções (API V1 - API privada - pode não funcionar). **[TODO]**
 8. **Experimental** Solicitar logística reversa (API V1 - API privada - pode não funcionar). **[TODO]**

---

## Utilização

Vide o arquivo em [inglês](/README.MD) para exemplos de utilização.
