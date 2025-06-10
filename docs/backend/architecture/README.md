# Estrutura do Backend - ERP

Este documento descreve a estrutura de pastas, os projetos criados em cada uma delas, o propósito de cada projeto e as referências entre eles para o backend do ERP.

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
  Projeto do tipo **ASP.NET Core Web API**.  
  Responsável por expor os endpoints HTTP, lidar com autenticação, configuração dos serviços, middlewares e integração com frontend.

- **Application**  
  Projeto do tipo **Class Library (.NET)**.  
  Contém a lógica de aplicação, casos de uso, serviços, interfaces e DTOs.  
  Atua como uma camada intermediária entre o domínio e a infraestrutura.

- **Domain**  
  Projeto do tipo **Class Library (.NET)**.  
  Contém as entidades do negócio, objetos de valor, enums e regras de negócio puras.  
  Essa camada não depende de nenhuma outra.

- **Infrastructure**  
  Projeto do tipo **Class Library (.NET)**.  
  Contém a implementação concreta dos acessos a dados (ex: Entity Framework Core), serviços externos, repositórios, e demais detalhes técnicos.

---

## Referências entre Projetos

Para manter a separação de responsabilidades e dependências, as referências entre projetos são configuradas da seguinte forma:

| Projeto Referenciador | Projetos Referenciados                           | Finalidade                                                                                  |
|----------------------|------------------------------------------------|--------------------------------------------------------------------------------------------|
| **Application**      | Domain                                         | Para usar entidades, modelos e regras de negócio definidas na camada Domain                 |
| **Infrastructure**   | Application, Domain                            | Para implementar os contratos definidos na Application e acessar entidades do Domain       |
| **Api**              | Application, Infrastructure, Domain            | Para expor a aplicação, usar a lógica da Application e a implementação da Infrastructure    |

---

## Por que essa organização?

- Facilita a manutenção e escalabilidade do sistema.
- Permite testes isolados em cada camada.
- Segue o padrão de **Clean Architecture**, utilizado em projetos profissionais.
- Separa claramente regras de negócio da infraestrutura técnica.

---

Se quiser, consulte a documentação detalhada de cada camada nos arquivos dedicados dentro da pasta `docs/`.

---

