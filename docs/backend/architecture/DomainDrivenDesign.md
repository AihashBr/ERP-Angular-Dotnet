# Estrutura do Backend - ERP

Este documento descreve a estrutura de pastas, os projetos criados em cada uma delas, a finalidade de cada projeto e as referências entre eles para o backend do ERP.

---

## Estrutura de Pastas

src/  
├── Api/  
├── Application/  
├── Domain/  
└── Infrastructure/  

---

### Detalhes dos Projetos

- **Api**  
  Tipo do projeto: **ASP.NET Core Web API**.  
  Responsável por expor os endpoints HTTP, lidar com autenticação, configurar serviços, middlewares e integração com o frontend.

- **Application**  
  Tipo do projeto: **Class Library (.NET)**.  
  Contém a lógica da aplicação, casos de uso, serviços, interfaces e DTOs.  
  Atua como camada intermediária entre o domínio e a infraestrutura.

- **Domain**  
  Tipo do projeto: **Class Library (.NET)**.  
  Contém as entidades de negócio, objetos de valor, enums e regras de negócio puras.  
  Esta camada não depende de nenhuma outra.

- **Infrastructure**  
  Tipo do projeto: **Class Library (.NET)**.  
  Contém a implementação concreta de acesso a dados (ex.: Entity Framework Core), serviços externos, repositórios e outros detalhes técnicos.

---

## Referências entre Projetos

Para manter a separação de responsabilidades e dependências, as referências entre projetos são configuradas da seguinte forma:

| Projeto que referencia | Projetos referenciados                      | Finalidade                                                                                  |
|-------------------------|---------------------------------------------|---------------------------------------------------------------------------------------------|
| **Application**         | Domain                                      | Utilizar entidades, modelos e regras de negócio definidas na camada Domain                   |
| **Infrastructure**      | Application, Domain                         | Implementar os contratos definidos em Application e acessar entidades do Domain              |
| **Api**                 | Application, Infrastructure, Domain         | Expor a aplicação, usar a lógica da Application e a implementação da Infrastructure          |

---

## Por que essa organização?

- Facilita a manutenção e a escalabilidade do sistema.  
- Permite testes isolados em cada camada.  
- Segue o padrão **Clean Architecture**, amplamente utilizado em projetos profissionais.  
- Separa claramente as regras de negócio da infraestrutura técnica.  

---

Para mais detalhes, consulte a documentação dedicada de cada camada na pasta `docs/`.
