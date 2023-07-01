# FindPets - Aplicação Blazor WebAssembly Core Hosted

## Projeto da Fase 1 - FIAP - Tech Challenge

## Visão Geral

O projeto FindPets é uma aplicação desenvolvida com a tecnologia Blazor WebAssembly Core Hosted na versão 7 do .NET. Essa arquitetura combina os recursos do Blazor WebAssembly com uma separação em projetos para facilitar o gerenciamento do código.

O Blazor WebAssembly permite a criação de aplicativos web interativos usando C# e .NET executados no cliente, enquanto o Core Hosted divide o projeto em três partes principais: Cliente, Servidor e Compartilhado.

O Cliente é responsável por renderizar a interface do usuário (UI) no navegador. Ele é um aplicativo Blazor WebAssembly autônomo que é executado no cliente, permitindo uma experiência rica e interativa diretamente no navegador.

O Servidor é uma API RESTful construída com o framework Minimal API, que fornece serviços e recursos para o cliente. Ele lida com a lógica de negócios, a interação com o banco de dados e a comunicação com outros serviços.

O Compartilhado contém entidades, modelos de dados, interfaces e outros componentes que são compartilhados entre o cliente e o servidor. Essa separação permite que o código seja reutilizado e mantido de forma mais eficiente.

## Arquitetura

A arquitetura do projeto FindPets segue o padrão de arquitetura em camadas, com a separação entre o Cliente e o Servidor. O Cliente é responsável pela apresentação dos dados e interação com o usuário, enquanto o Servidor cuida da lógica de negócios e persistência de dados.

### Camadas

1. **Cliente (FindPets.Client):** Nesta camada, encontramos as páginas do Blazor, componentes, serviços e recursos relacionados à interface do usuário. É onde ocorre a renderização da aplicação no navegador e a interação com o usuário.

2. **Servidor (FindPets.Server):** Essa camada contém a API RESTful construída com o Minimal API. Aqui estão os controladores, serviços, repositórios e a lógica de negócios. Ela se comunica com o banco de dados e fornece os dados necessários para o cliente.

3. **Compartilhado (FindPets.Shared):** Essa camada contém as entidades, modelos de dados, interfaces e outros componentes que são compartilhados entre o cliente e o servidor. É onde definimos as estruturas de dados que são usadas em ambos os lados da aplicação.

## Execução Local

Para executar a aplicação FindPets localmente, siga as etapas abaixo:

1. Clone o repositório para o seu ambiente de desenvolvimento.
2. Abra a solução `FindPets.sln` no Visual Studio ou em uma IDE compatível.
3. Certifique-se de ter as dependências necessárias instaladas, como o SDK do .NET 7.
4. Ajuste as conexões necessárias no arquivo `appsettings.json` dentro do projeto `FindPets.Server`.
5. Execute o projeto `FindPets.Server` para iniciar a API RESTful no servidor.

    O swagger da api pode ser visualizado ao inserir `/swagger` na url iniciada ao executar o projeto, exemplo https://localhost:7289/swagger/. Segue imagem:

    ![rg](.github/swagger.png?style=flat)

6. Acesse o projeto `FindPets.Client` no navegador para utilizar a aplicação.

    Ao iniciar o projeto é possível visualizar a aplicação em execução, url de acesso https://localhost:7289/. Segue imagem:

    ![rg](.github/client.png?style=flat)
 

## Implantação na Azure

Para implantar a aplicação FindPets na plataforma Azure, siga as etapas abaixo:

1. Crie uma conta na Azure e acesse o portal Azure.
2. Crie um novo recurso do App Service para hospedar a aplicação.
3. Crie um novo recurso do SQL Azure para garantir o acesso ao banco de dados na aplicação.
4. Crie um novo recurso do Blob Storage para armazenar as imagens dos pets na aplicação.
5. Faça o deploy dos projeto `FindPets` para o App Service através da publicação do Visual Studio.
6. Configure as conexões com o SQL Azure e o Blob Storage para acesso ao banco de dados e armazenamento de imagens dos pets.
7. Realize as configurações necessárias no portal Azure para garantir o funcionamento adequado da aplicação.

Com a implantação concluída, a aplicação FindPets estará disponível online na Azure, permitindo o acesso e utilização por parte dos usuários.

Exemplo da estrutura:

![rg](.github/resourceGroup.png?style=flat)
![appsettings](.github/appSettings.png?style=flat)

## Conclusão

O projeto FindPets, com sua arquitetura Blazor WebAssembly Core Hosted, possibilita o desenvolvimento de aplicações web modernas e interativas utilizando C# e .NET tanto no lado do cliente quanto no lado do servidor. A divisão em projetos facilita a organização do código e permite a reutilização de componentes e estruturas de dados compartilhadas.

Através da implantação na plataforma Azure, é possível aproveitar os serviços gerenciados, como o App Service, SQL Azure e Blob Storage, para hospedagem, banco de dados e armazenamento de arquivos.

Para mais informações sobre a arquitetura e funcionamento específicos do projeto, consulte a documentação presente no repositório.

Agradecemos por utilizar a aplicação FindPets e esperamos que ela seja útil na localização de animais perdidos.

> Implementado por: Daniela Miranda de Almeida, Jhean Ricardo Ramos, Lucas dos anjos Varela, Marcelo de Moraes Andrade e Wellington Chida de Oliveira.