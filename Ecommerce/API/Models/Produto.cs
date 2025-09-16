using System;

namespace API.Models;

public class Produto
{
    //Construtor público
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
        Nome = string.Empty;
    }

    //Atributos|Propriedades|Características
    public string Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }
};




