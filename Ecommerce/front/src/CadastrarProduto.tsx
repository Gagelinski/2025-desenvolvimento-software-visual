import { useState } from "react";
import Produto from "./Produto";
import { error } from "console";
import axios from "axios";

function CadastrarProduto(){

    const [nome, setNome] = useState("");
    const [quantidade, setQuantidade] = useState(0);
    const [preco, setPreco] = useState(0);

    function enviarProduto(e : any){
        e.preventDefault()
        enviarProdutoAPI()
    }

    async function enviarProdutoAPI() {
        try{
            const produto : Produto = {
                nome, 
                preco, 
                quantidade,
            };
            const resposta = await axios.post("http://localhost:5166/api/produto/cadastrar", produto);
            console.log(resposta.data);
        }catch(error){
            console.log("Erro ao cadastrar produto: " + error);
        }
    }

    return(
        <div>
            <h1>Cadastrar Produto</h1>
            <form onSubmit={enviarProduto}>
                <div>
                    <label>Nome:</label>
                    {/* No onChange você pode criar uma função separada pra cada um */}
                    <input onChange={(e : any) => setNome(e.target.value)} type="text" /> 
                </div>
                <div>
                    <label>Quantidade:</label>
                    <input onChange={(e : any) => setQuantidade(e.target.value)} type="text" />
                </div>
                <div>
                    <label>Preço:</label>
                    <input onChange={(e : any) => setPreco(e.target.value)} type="text" />
                </div>
                <div>
                    <button type="submit">Cadastrar</button>   
                </div>
            </form>
        </div>
    )
}

export default CadastrarProduto;