using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

//Classe que representa o banco de dados da aplicação
//1- Criar a herença da classe DbContext
//2- Informar quais classes vão representar as tabelas no banco
//3- Configurar string de conexão para SQLite
public class AppDataContext : DbContext
{
    //Classe representa o banco, atributos representam as tabelas
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }

}
