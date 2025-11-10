using System.Security.Cryptography.Xml;
using API.Models;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
// Console.Clear();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddCors(
    options => options.AddPolicy("Acesso Total",
    configs => configs
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
);

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
// GET     -> Recuperar/Enviar dados da sua API/aplicação.
// POST    -> Enviar/Cadastar dados para criar um novo recurso.
// PUT     -> Atualiza um recurso existente.
// DELETE  -> Remove um recurso.
// PATCH   -> Atualiza parcialmente um recurso existente.

app.MapGet("/", () => "API de produtos");

// GET: /api/produto/listar

// Criar uma validaçao da lista de produtos par saber se existe algo dentro, 
// se existir retorne a lista, se não retorne "NULO"
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.ToList());
    }
    return Results.NotFound("Lista Vazia");
});

// Tentei desse jeito, mas não funciona. Pq quando instanciei a lista ela ja deixou de ser nula
// app.MapGet("/api/produto/listar", =>
// {
//     if (produtos != null)
//     {
//         return produtos;
//     }
//     else
//     {
//         return null;
//     }
// });

//GET: /api/produto/buscar/nome_do_produto
app.MapGet("/api/produto/buscar/{nome_do_produto}", ([FromRoute] string nome_do_produto, [FromServices] AppDataContext ctx) =>
{
    //Com a expressão lambda
    Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Nome == nome_do_produto); //o x representa o objeto que está sendo pesquisado
    if (resultado is null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    return Results.Ok(resultado);

});
 //Se feito sem a expressão lambda, fica assim:
    // foreach (Produto produtoPesquisado in produtos)
    // {
    //     if (produtoPesquisado.Nome == nome_do_produto)
    //     {
    //         return Results.Ok(produtoPesquisado);
    //     }
    // }

// POST: /api/produto/cadastrar
//Não permitir o cadastro de um produto com o mesmo nome
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto, [FromServices] AppDataContext ctx) =>
{
    Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome); //o x representa o objeto que está sendo pesquisado
    if (resultado is not null)
    {
        return Results.Conflict("Produto já cadastrado");
    }
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

//como o Chat fez:
// app.MapPost("/api/produto/cadastrar", (Produto produto) =>
// {
//     var existe = produtos.Any(p => p.Nome.Equals(produto.Nome, StringComparison.OrdinalIgnoreCase));
//     if (existe)
//     {
//         return Results.BadRequest($"O produto '{produto.Nome}' já está cadastrado.");
//     }

//     produtos.Add(produto);

//     return Results.Created($"/api/produto/{produto.Id}", produto);
// });

//DELET: /api/produto/deletar/id
//Eu tinha feito pro nome mas substitui pra ID pra ter exemplos "diferentes"

app.MapDelete("/api/produto/deletar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    //Com a expressão lambda
    Produto? resultado = ctx.Produtos.Find(id);
    if (resultado is null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    ctx.Produtos.Remove(resultado);
    ctx.SaveChanges();
    return Results.Ok("Deletado");

});

//PUT: /api/produto/atualizar/id
app.MapPatch("/api/produto/atualizar/{id}", ([FromRoute] string id,[FromBody] Produto produtoAtualizado, [FromServices] AppDataContext ctx) =>
{
    //Com a expressão lambda
    Produto? resultado = ctx.Produtos.Find(id);
    if (resultado is null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    resultado.Nome = produtoAtualizado.Nome;
    resultado.Quantidade = produtoAtualizado.Quantidade;
    resultado.Preco = produtoAtualizado.Preco;
    ctx.Produtos.Update(resultado);
    ctx.SaveChanges();
    return Results.Ok("Atualizado");

});



app.UseCors("Acesso Total");
app.Run();
