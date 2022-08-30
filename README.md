# TradeCategory
Teste Técnico TradeCategory

Inserindo uma nova categoria e uma nova propriedade IsPoliticalExposed ao projeto:

Para adicionar mais categorias e suas regras basta acessar a posta Repository e dentro acessar a classe CategoriaRepository na função PopularCategoria basta adicionar linhas junto a suas regras a lista de CategoriasModel, dependendo da regra basta verificar no GetCategoria se as regras criadas se enquadram para a nova Categoria.
Para você inserir o IsPoliticallyExposed que tem sua propriedade um boliano basta acrescentar um public bool IsPoliticallyExposed na Interfaces ITrande.cs e Model TradeModel.cs, para você conseguir alimentar e trabalhar o IsPoliticallyExposed basta acessar a pasta Servicos e dentro da classe TradeServico na função TratarString inserir mais um campo para captura o novo elemento.
Feito todas as alterações não se esqueça de realizar a implementação dos testes.
