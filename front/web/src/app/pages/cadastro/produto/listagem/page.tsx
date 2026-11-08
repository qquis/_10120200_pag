// app/produtos/page.tsx
'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import ProdutoModal from "./modalproduto";

import {moduleProduto
      , moduleProdutoCategoria
      , TpProduto
      , TpProdutoCategoria
      , TpProdutoDepartamento
      , TpProdutoGrupo
      , TpProdutoSecao
      , TpProdutoSubGrupo
    
    } from '@/api/m0020_produto/moduleproduto'

    let myModuleProduto : moduleProduto
    let myModuleProdutoCategoria : moduleProdutoCategoria

export default function ProductList() {

  /* USER */
  const { user } = useAuth();
  
  /* MODAL STATES */
  const [modalOpen, setModalOpen] = useState(false);
  const [selectedProdutoId, setSelectedProdutoId] = useState<number | null>(null);

    /* MODULES  */

  /* STATES SCREEN */    
    const [ActionStatus, setActionStatus] = useState<number>(0);
  /* STATES FILTERS */
    const [descricaoFilter, setDescricaoFilter] = useState('');
    const [pr_cdprodutoFilter, setpr_cdProdutoFilter] = useState('');
    const [DepartamentoFilterID, setDepartamentoFilterId] = useState(0);
    const [SecaoFilterID, setSecaoFilterId] = useState(0);
    const [filtrar_vendaexterna, setfiltrar_vendaexterna] = useState('');
    const [filtraDataCadastro, setfiltraDataCadastro] = useState(false);
    const [dataCadastroInicial, setdataCadastroInicial] = useState(() => {
      const today = new Date();
      return today.toISOString().split('T')[0]; // Formato YYYY-MM-DD
    });
    const [dataCadastroFinal, setdataCadastroFinal] = useState(() => {
      const today = new Date();
      return today.toISOString().split('T')[0]; // Formato YYYY-MM-DD
    });
    const [filtrarComMovimentacao, setfiltrarComMovimentacao] = useState(false);
    const [filtrarComMovimentacaoTipo, setfiltrarComMovimentacaoTipo] = useState('ENTRADA');
    const [filtrarComMovimentacaoNumeroMes, setfiltrarComMovimentacaoNumeroMes] = useState(1);

  /* STATES LISTS */
    const [ProdutoDepartamento, setProdutoDepartamento] = useState<TpProdutoDepartamento[]>([]);
    const [ProdutosSecao, setProdutosSecao] = useState<TpProdutoSecao[]>([]);
    //const [ProdutosGrupo, setProdutosGrupo] = useState<TpProdutoGrupo[]>([]);
    //const [ProdutosSubGrupo, setProdutosSubGrupo] = useState<TpProdutoSubGrupo[]>([]);
    const [produtosList, setListProduto] = useState<any[]>([]);
    const [filtrar_status_bluesoft, setfiltrar_status_bluesoft] = useState('ATIVO'); 



/* EFFECTS */


  useEffect(() => {
    myModuleProduto = new moduleProduto(user);
    myModuleProdutoCategoria = new moduleProdutoCategoria(user);

    const BindingData = async () => {

    /* MODULES  */


    await myModuleProdutoCategoria.getCategoria()
    setProdutoDepartamento( await myModuleProdutoCategoria.getDepartamento() );
    await FiltrarSecao(0)
    

  };
  
  BindingData();
}, []);



  const changeDepartamento = async (prd_cddepartamento: number) => { 
      setDepartamentoFilterId(prd_cddepartamento)
      await FiltrarSecao(prd_cddepartamento)
  }

  const FiltrarSecao = async (departamentoID: number) => { 
    try {
        setActionStatus(1)
        await myModuleProdutoCategoria.getSecao(departamentoID)
        setProdutosSecao(myModuleProdutoCategoria.Secao)
        setSecaoFilterId(0)
        setActionStatus(0)

    } catch (e) {
        console.log(`Filtrar Secao Error ${e}`)

  }
}


  const consultraProdutos = async () => { 

    let parametro : any = { 
          pr_descricao : descricaoFilter
        , pr_cdproduto : pr_cdprodutoFilter !== '' ? Number(pr_cdprodutoFilter) : 0
        , prd_cddepartamento : DepartamentoFilterID
        , prs_cdsecao : SecaoFilterID
        , filtrar_status_bluesoft : filtrar_status_bluesoft 
        , filtrar_vendaexterna : filtrar_vendaexterna
        , filter_prb_dt_cadastro : filtraDataCadastro ? 1 : 0
        , filtra_prb_dt_cadastro_ini : user.formatDateToStringYYYMMDD(dataCadastroInicial)
        , filtra_prb_dt_cadastro_fim : user.formatDateToStringYYYMMDD(dataCadastroFinal)
        , filtrar_entrada_saida : filtrarComMovimentacao ? 1 : 0
        , filtrar_entrada_saida_tipo : filtrarComMovimentacaoTipo
        , filtrar_entrada_saida_numero_mes : filtrarComMovimentacaoNumeroMes
    }
    setActionStatus(1)
    const response = await myModuleProduto.getList(parametro)
    setListProduto(response)
    setActionStatus(0)

  }

  const abrirModalProduto = (produtoId: number) => {
    setSelectedProdutoId(produtoId);
    setModalOpen(true);
  };

  const fecharModal = () => {
    setModalOpen(false);
    setSelectedProdutoId(null);
  };

  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Produto - Listagem Básica (Base unitária - PRIME)" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" ActionStatus={ActionStatus} title="Pesquisar" onClick={consultraProdutos} ></ButtonPag>
          </div>              
        </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
         
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-4">



            {/* Filtro por Descrição */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Descrição</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por descrição"
                value={descricaoFilter}
                onChange={(e) => setDescricaoFilter(e.target.value)}
              />
            </div>
            
            {/* Filtro por Código */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Código</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código"
                value={pr_cdprodutoFilter}
                onChange={(e) => setpr_cdProdutoFilter(e.target.value)}
              />
            </div>
            

            
            {/* Filtro por Departamento */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Departamento</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={DepartamentoFilterID}
                onChange={async (e) => await changeDepartamento(Number(e.target.value))}
                disabled={ProdutoDepartamento.length === 0}
              >
                
                {ProdutoDepartamento.map((departamento, index) => (
                  <option key={index} value={departamento.prd_cddepartamento}>{departamento.prd_descricao}</option>
                ))}
              </select>
            </div>
            
            {/* Filtro por Seção */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Seção</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={SecaoFilterID}
                onChange={(e) => setSecaoFilterId(Number(e.target.value))}
              >
                <option value="">Todas</option>
                {ProdutosSecao.map((section, index) => (
                  <option key={index} value={section.prs_cdsecao}>{section.prs_descricao}</option>
                ))}
              </select>
            </div>

            {/* Filtro por Status */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Status</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={filtrar_status_bluesoft}
                onChange={(e) => setfiltrar_status_bluesoft(e.target.value)}
              >
                <option value="">Todos</option>
                <option value="ATIVO">Ativo</option>
                <option value="INATIVO">Inativo</option>
              </select>
            </div>

            {/* Filtro por Venda Externa */}
            <div className='flex-row'>
              <label className="block text-sm font-medium text-gray-700 mb-1">Venda Externa</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={filtrar_vendaexterna}
                onChange={(e) => setfiltrar_vendaexterna(e.target.value)}
              >
                <option value="">Todos</option>
                <option value="SIM">Sim</option>
                <option value="NAO">Não</option>
              </select>
            </div>

        {/* Filtro por Data de Cadastro - Seção separada */}
          <div className="flex-row col-span-2">
            <label className="block text-sm font-medium text-gray-700 mb-1">
              <input
                type="checkbox"
                checked={filtraDataCadastro}
                onChange={(e) => setfiltraDataCadastro(e.target.checked)}
                className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
              />
              Filtrar por Data de Cadastro
            </label>
            
             <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div>
                  <input
                    type="date"
                    disabled={!filtraDataCadastro}
                    value={dataCadastroInicial}
                    onChange={(e) => setdataCadastroInicial(e.target.value)}
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                  />
                </div>
                <div>
                  <input
                    type="date"
                    disabled={!filtraDataCadastro}
                    value={dataCadastroFinal}
                    onChange={(e) => setdataCadastroFinal(e.target.value)}
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                  />
                </div>
              </div>
          
          </div>



          <div className="flex-row col-span-2">
              <label className="block text-sm font-medium text-gray-700 mb-1">
                <input
                  type="checkbox"
                  checked={filtrarComMovimentacao}
                  onChange={(e) => setfiltrarComMovimentacao(e.target.checked)}
                  className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                />
                Filtrar por Movimentação de Estoque
              </label>
              
              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div className='flex-row'>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Tipo Movimentação</label>
                  <select
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                    value={filtrarComMovimentacaoTipo}
                    onChange={(e) => setfiltrarComMovimentacaoTipo(e.target.value)}
                    disabled={!filtrarComMovimentacao}
                  >
                    <option value="Todas">Todas</option>
                    <option value="ENTRADA">Entrada</option>
                    <option value="SAIDA">Saída</option>
                  </select>
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">N. de Meses</label>
                  <input
                    type="number"
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                    placeholder="Número de meses retroativo de movimentação"
                    value={filtrarComMovimentacaoNumeroMes}
                    onChange={(e) => setfiltrarComMovimentacaoNumeroMes(Number(e.target.value))}
                    disabled={!filtrarComMovimentacao}
                  />
                </div>
              </div>
            </div>


          
         </div>
        </div>
        
        {/* Grid de Produtos */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Pag</th>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Cod UNit Blue</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Descrição</th>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Est.</th>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Cmp.</th>
                  <th className="px-2 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Cmp.F</th>
                  <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Status</th>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">V.Ext</th>                  
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Figura Fiscal</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Cadastro</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Fornecedor</th>

                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {produtosList.length > 0 ? (
                  produtosList.map((product) => (
                    <tr key={product.pr_cdproduto} className="hover:bg-gray-50">
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{product.pr_cdproduto}</td>
                      <td 
                        className="px-1 py-2 whitespace-nowrap text-sm text-blue-600 text-right cursor-pointer hover:text-blue-800 hover:underline"
                        onClick={() => abrirModalProduto(product.prb_cdprodutobluesoft)}
                        title="Clique para ver detalhes do produto"
                      >
                        {product.prb_cdprodutobluesoft}
                      </td>
                      <td className="px-6 py-2 whitespace-nowrap text-sm text-gray-700 ">{product.pr_descricao}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{product.pr_embalagemestoque}</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">{product.pr_embalagemcompra}</td>
                      <td className="px-2 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{user.formatNumber(product.pr_embalagemcompra_fator,1)}</td>
                      <td className="px-3 py-2 whitespace-nowrap text-sm text-gray-700 text-left">{product.prb_status === 1 ? "Ativo" : "Inativo" }</td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 text-left">{product.prb_vendaexterna === 1 ? "Sim" : "Não" }</td>  
                      <td className="px-6 py-2 whitespace-nowrap text-sm text-gray-700 text-left">{product.fc_figurafiscal_descricao}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-left">{user.formatDateDDMMYYYY(product.prb_dt_cadastro)}</td>
                      <td className="px-6 py-2 whitespace-nowrap text-sm text-gray-700 text-left">{product.fornecedor_nome_razao}</td>
                  </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan={11} className="px-6 py-4 text-center text-sm text-gray-500">
                      Nenhum produto encontrado com os filtros aplicados.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>

        <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
          <div className="flex justify-between items-center">
            <h3 className="text-mg font-medium text-gray-500">Total de Registros</h3>
            <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
              {produtosList.length} produto{produtosList.length !== 1 ? 's' : ''}
            </span>
          </div>
        </div>
      </div>

      {/* Modal do Produto */}
      <ProdutoModal
        isOpen={modalOpen}
        onClose={fecharModal}
        produtoId={selectedProdutoId}
      />
    </div>
  );
}