import { useEffect } from "react";

//Componente
//1- O componente deve ser uma função
//2- Deve retornar apenas um elemento pai HTML
//3- Exportar o componente
//4- O nome da função precisa estar em PascalCasing

function ListarProdutos(){
    //useEffect é metodo que permite executar algum código, no momento do carregamento do componente
    //Exercicio prox aula = pegar os dados que chegaram da requisição e mostar no HTML
    //- Estado/variável

    useEffect(() =>{
        //Biblioteca AXIOS para requisições
        buscarProdutosAPI();


    }, []);

    async function buscarProdutosAPI(){
        try{
            const resposta = await fetch("http://localhost:5166/api/produto/listar");

            if(!resposta.ok){
                throw new Error("Problemas na requisição: " + resposta.statusText);
            }

            const dados = await resposta.json();

            console.table(dados);
        }
        catch(error){
            console.log("Problemas na requisição: " + error);
        }
    }

    return (
        <div id="listar_produtos">
        <h1>Listar Produtos</h1>
        <ul>
            <li></li>
            <li></li>
            <li></li>
        </ul>
        </div>
    );
}


export default ListarProdutos; //É oq usa para tornar ele "publico", poder usar em outros locais do código