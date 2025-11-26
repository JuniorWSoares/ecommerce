# 🛒 Projeto E-commerce Backend - AV2

Este repositório contém a implementação de uma API RESTful para um sistema de E-commerce, desenvolvida em **C# .NET 9.0**.

O projeto foi construído seguindo rigorosamente os princípios de **DDD (Domain-Driven Design)**, **SOLID** e **Orientação a Objetos**, atendendo a todos os critérios de avaliação da disciplina.

---

## 👥 Integrantes do Grupo

* **José Junior** (Matrícula: 06012771)
* **Watilha** (Matrícula: 06012734)
* **Caio Barragat** (Matrícula: 06012117)
* **Laura de Lima** (Matrícula: 06010735)

---

## 🚀 Como Rodar o Projeto

### Pré-requisitos
* .NET SDK (Versão 8.0 ou 9.0) instalado.

### Passo a Passo
1.  Abra o terminal na pasta raiz do projeto.
2.  Limpe builds antigos e restaure dependências:
    ```bash
    dotnet clean
    dotnet restore
    ```
3.  Execute a API apontando para o projeto principal (`MinhaAPI`):
    ```bash
    dotnet run --project MinhaAPI
    ```
4.  Aguarde a mensagem `Now listening on: http://localhost:XXXX`.
5.  Acesse a documentação interativa (Swagger) no navegador:
    * **Link:** `http://localhost:XXXX/swagger` (Substitua XXXX pela porta exibida no terminal, ex: 5021).

---

## 🏆 Atendimento aos Critérios de Avaliação

Abaixo detalhamos como o projeto cumpre cada requisito do documento "AV2 Critérios de Avaliação":

### 1. Modelagem de Classes e Domínio
* **Atendido:** Implementamos as classes `Produto`, `Carrinho`, `CarrinhoItem` (Composição), `Pedido` e `Usuario`.
* **Evidência:** A classe `Carrinho` possui uma lista privada de itens e métodos para manipular essa lista, garantindo a relação de composição exigida.

### 2. Herança e Polimorfismo
* **Atendido:** Utilizamos herança na classe base `Pagamento` e suas filhas `PagamentoPix` e `PagamentoCartao`.
* **Evidência:** No `PedidoService`, utilizamos um **Factory Method** para instanciar a estratégia correta e chamamos o método abstrato `.Processar()` de forma polimórfica, eliminando condicionais complexas.

### 3. Encapsulamento e Coesão
* **Atendido:** Todas as propriedades das entidades possuem `private set`.
* **Evidência:** O estado dos objetos só é alterado por métodos de negócio (ex: `produto.BaixarEstoque()`, `pedido.Cancelar()`), impedindo "vazamento" de lógica.

### 4. Tratamento de Exceções
* **Atendido:** Utilizamos `try/catch` nos Controllers e lançamos exceções específicas no Domínio.
* **Evidência:** Validações como `ArgumentException` (se preço <= 0) e `InvalidOperationException` (se estoque insuficiente) garantem a integridade.

### 5. Arquitetura e Padrões (DTO, Service, Repository)
* **Atendido:** O projeto está separado em camadas (`API`, `Application`, `Domain`, `Infrastructure`).
* **Evidência:** Uso de **DTOs** (`RegistroUsuarioDTO`, `CheckoutDTO`) para isolar a API do Domínio. A lógica pesada está nos **Services** (`PedidoService`), deixando os Controllers apenas como roteadores.

---

## 📊 Diagrama de Classes UML

O diagrama de classes completo está disponível no arquivo `diagrama.mmd` (ou `.pdf` / `.png`) incluído na raiz deste repositório.

---

## 🧪 Testando a API (Fluxo Sugerido)

Para validar o funcionamento completo, sugerimos o seguinte fluxo no Swagger ou Postman (Collection disponível no arquivo `Ecommerce_AV2.postman_collection.json`):

1.  **POST /api/Usuario/registrar:** Crie um usuário e copie o `id`.
2.  **POST /api/Categoria:** Crie uma categoria e copie o `id`.
3.  **POST /api/Produto:** Cadastre um produto (Estoque: 10) usando o ID da categoria.
4.  **POST /api/Carrinho/adicionar:** Adicione o produto ao carrinho do usuário.
5.  **GET /api/Carrinho/{usuarioId}:** Verifique o total calculado.
6.  **POST /api/Pedido/finalizar:** Finalize a compra escolhendo "pix" ou "cartao".
7.  **GET /api/Produto:** Verifique se o estoque foi baixado automaticamente (deve estar em 9).
