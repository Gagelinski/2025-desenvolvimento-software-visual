import React from 'react';
import ListarProdutos from './ListarProdutos';
import CadastrarProduto from './CadastrarProduto';
import {BrowserRouter, Route, Routes, Link} from "react-router-dom";


function App() {
  return (
    <div id="componente_app">
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to="/">Listar Produtos</Link>
            </li>
            <li>
              <Link to="/produto/cadastrar">Cadastrar Produto</Link>
            </li>
          </ul>
        </nav>
         <Routes>
            <Route path="/" element={< ListarProdutos/>} />
            <Route path="produto/cadastrar" element={<CadastrarProduto/>} />
          </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
