# Desafio Desenvolvimento

Este projeto é uma aplicação de gerenciamento de processos, desenvolvida utilizando ASP.NET Core 8. A aplicação permite cadastrar, visualizar e confirmar visualização.

## Pré-requisitos

Antes de executar o projeto, certifique-se de que você possui as seguintes ferramentas instaladas:

- [.NET SDK 8.0 ou superior](https://dotnet.microsoft.com/download)
- [Visual Studio 2022 ou superior](https://visualstudio.microsoft.com/) (com suporte para ASP.NET e desenvolvimento web)

## Configuração do Banco de Dados

A aplicação já vem com um banco de dados SQLite pré-configurado e com dados de exemplo. Não é necessário criar um banco de dados manualmente.

1. **Verificar a String de Conexão**:
   - No arquivo `appsettings.json`, verifique a seção `"ConnectionStrings"` para garantir que a string de conexão para o SQLite está configurada corretamente:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Data Source=../Desafio_Desenvolvimento.Infra.Data/Dados/DesafioDB.db"
   }

## Executando a Aplicação

### Clonar o Repositório

Clone este repositório em sua máquina local:

```bash
  git clone https://github.com/carlosmax/desafio-desenvolvimento.git
  cd desafio-desenvolvimento
```

### Restaurar Pacotes NuGet
Abra o projeto no Visual Studio e restaure os pacotes NuGet:

```bash
dotnet restore
```

### Iniciar a Aplicação
Execute a aplicação:

```bash
dotnet run
```

Ou, no Visual Studio, pressione F5 para iniciar a aplicação com o debugger.

### Acessar a Aplicação
Abra seu navegador e navegue até http://localhost:5000 (ou a porta configurada na sua aplicação).
