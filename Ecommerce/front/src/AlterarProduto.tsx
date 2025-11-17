import { useEffect, useState } from "react";
import Produto from "./Produto";
import { error } from "console";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

function AlterarProduto(){
    const {id} = useParams();
    const [nome, setNome] = useState("");
    const [quantidade, setQuantidade] = useState(0);
    const [preco, setPreco] = useState(0);
    const navigate = useNavigate();

    useEffect(() => {
        buscarProduto();
    }, [])

    async function buscarProduto() {
        try {
            const resposta = await axios.get<Produto>(`http://localhost:5166/api/produto/buscar/${id}`);
            setNome(resposta.data.nome);
            setQuantidade(resposta.data.quantidade);
            setPreco(resposta.data.preco);
        } catch (error) {
            console.log(error);
        }
    }

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
            const resposta = await axios.patch(`http://localhost:5166/api/produto/atualizar/${id}`, produto);
            console.log(resposta.data);
        }catch(error){
            console.log("Erro ao atualizar produto: " + error);
        }
    }

    return(
        <div>
            <h1>Alterar Produto</h1>
            <form onSubmit={enviarProduto}>
                <div>
                    <label>Nome:</label>
                    {/* No onChange você pode criar uma função separada pra cada um */}
                    <input onChange={(e : any) => setNome(e.target.value)} type="text" value={nome} /> 
                </div>
                <div>
                    <label>Quantidade:</label>
                    <input onChange={(e : any) => setQuantidade(e.target.value)} type="text" value={quantidade} />
                </div>
                <div>
                    <label>Preço:</label>
                    <input onChange={(e : any) => setPreco(e.target.value)} type="text" value={preco} />
                </div>
                <div>
                    <button type="submit">Alterar Produto</button>   
                </div>
            </form>
        </div>
    )
}

export default AlterarProduto;