using API.Models;
Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Lista de produtos
List<Produto> produtos = new List<Produto>
{
    new Produto { Nome = "Notebook Gamer", Quantidade = 5, Preco = 4500.00 },
    new Produto { Nome = "Smartphone X", Quantidade = 12, Preco = 2200.00 },
    new Produto { Nome = "Fone de Ouvido Bluetooth", Quantidade = 30, Preco = 250.00 },
    new Produto { Nome = "Teclado Mecânico", Quantidade = 10, Preco = 480.00 },
    new Produto { Nome = "Monitor 27'' 4K", Quantidade = 8, Preco = 1850.00 },
    new Produto { Nome = "Mouse Gamer", Quantidade = 15, Preco = 320.00 },
    new Produto { Nome = "Cadeira Ergonômica", Quantidade = 4, Preco = 1100.00 },
    new Produto { Nome = "Webcam Full HD", Quantidade = 20, Preco = 300.00 },
    new Produto { Nome = "Impressora Multifuncional", Quantidade = 6, Preco = 750.00 },
    new Produto { Nome = "HD Externo 1TB", Quantidade = 18, Preco = 420.00 }
};

//Funcionalidade - Requisições
// - URL/Caminho/Endereço
// - Um método HTTP:
// Métodos HTTP são formas de comunicação entre cliente e servidor.
// Cada método define uma ação a ser realizada em um recurso:
//
// GET     -> Solicita dados de um recurso.
// POST    -> Envia dados para criar um novo recurso.
// PUT     -> Atualiza um recurso existente.
// DELETE  -> Remove um recurso.
// PATCH   -> Atualiza parcialmente um recurso existente.

app.MapGet("/", () => "API de produtos");

// GET: /api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    return produtos;
});

// POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", (Produto produto) =>
{
    produtos.Add(produto);

});




app.Run();
