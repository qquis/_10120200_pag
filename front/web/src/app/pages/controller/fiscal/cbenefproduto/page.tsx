// app/produtos/page.tsx
'use client'

const SIS_AC_CD = 4214;

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";


/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

import {    modulefiscal 
        ,   TpCbenefProduto
} from '@/api/m0040_fiscal/modulefiscal';





import {moduleProdutoCategoria
      , TpProdutoDepartamento
      , TpProdutoSecao
    } from '@/api/m0020_produto/moduleproduto'
import { get } from 'http';


    let myModuleFiscal : modulefiscal
    let myModuleProdutoCategoria : moduleProdutoCategoria

export default function CbenefProduto() {







  /* USER */
  const { user } = useAuth();
  

    /* MODULES  */

  /* STATES SCREEN */    
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [ActionAcessoAtualizaZanthus, setActionAcessoAtualizaZanthus] = useState<boolean>(false);    
  /* STATES FILTERS */
    const [descricaoFilter, setDescricaoFilter] = useState('');
    const [descricaoFiscalFilter, setDescricaoFiscalFilter] = useState('');
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
    const [filtrarComMovimentacaoNegativa, setfiltrarComMovimentacaoNegativa] = useState(false);
    const [filtrarComMovimentacaoTipo, setfiltrarComMovimentacaoTipo] = useState('ENTRADA');
    const [filtrarComMovimentacaoNumeroMes, setfiltrarComMovimentacaoNumeroMes] = useState(1);
    const [filtrarcomestoque, setfiltrarcomestoque] = useState(0);
    const [operacaoVisualizar, setOperacaoVisualizar] = useState<string>("2");
    const [DistribuicaoRegimeCliente, setDistribuicaoRegimeCliente] = useState<string>("N");
    const [fornecedor_razao_social, setfornecedor_razao_social] = useState<string>("");

    const [ComCbenefPAGFilter, SetComCbenefPAGFilter] = useState<number>(0)
    const [CbenefPAGFilter, SetCbenefPAGFilter] = useState<string>("")
    const [ComCbenefBlueFilter, SetComCbenefBlueFilter] = useState<number>(0)
    const [SemCbenefBlueFilter, SetSemCbenefBlueFilter] = useState<number>(0)
    const [CbenefBlueFilter, SetCbenefBlueFilter] = useState<string>("")
    const [CSTFilter, setCSTFilter] = useState<number>(0)

  /* STATES LISTS */
    const [ProdutoDepartamento, setProdutoDepartamento] = useState<TpProdutoDepartamento[]>([]);
    const [ProdutosSecao, setProdutosSecao] = useState<TpProdutoSecao[]>([]);
    const [CBenefCstList, setCBenefCstList] = useState<any>([]); 

    const [produtosList, setListProduto] = useState<TpCbenefProduto[]>([]);
    const [CBenefList, setCBenefList] = useState<any>([]); 
    const [fc_cbenef_cdAssociar, setfc_cbenef_cdAssociar] = useState<string>('X');


    const [filtrar_status_bluesoft, setfiltrar_status_bluesoft] = useState('ATIVO'); 
    const [figurafiscalassociada, setfigurafiscalassociada] = useState("T");
    const [filtrarComRegraNfce, setfiltrarComRegraNfce] = useState("T");
    const [figurafiscal, setfigurafiscal] = useState("");
    const [ncm, setNCM] = useState("");
    const [cest, setCest] = useState("");



/* EFFECTS */


  useEffect(() => {
 
     /* MODULES  */
    myModuleFiscal = new modulefiscal(user, SIS_AC_CD);
    myModuleProdutoCategoria = new moduleProdutoCategoria(user);

    const BindingData = async () => {
        //CBENF
        let cbenefList = await myModuleFiscal.getListCbenef({fc_cbenef_bluesoftFilter: 1})
        setCBenefList(cbenefList)

        let myActionAcessoAtualizaZanthus = await user.getPermissaoCheck(4214, 4214001) // Acesso para atualizar estoque no Zanthus
        setActionAcessoAtualizaZanthus(myActionAcessoAtualizaZanthus)


        await myModuleProdutoCategoria.getCategoria()
        setProdutoDepartamento( await myModuleProdutoCategoria.getDepartamento() );
        await FiltrarSecao(0)
        

  };
  
  BindingData();
}, []);



  const CbenefConsultar = async (cbenef_cd: string) => {


    if (cbenef_cd.trim() === '') {
      setCBenefCstList([])
      return
    }

    let parametro : any = {
        fc_cbenef_cd : cbenef_cd
    }

    setCBenefCstList([])


    let listCBNEFCST = await myModuleFiscal.getListCbenefCst(parametro)
    setCBenefCstList(listCBNEFCST)

    setfc_cbenef_cdAssociar(cbenef_cd)


    
  } 

  const SelecionarTodos = async (status: boolean) => {
    
    let listSelecionar : TpCbenefProduto[] = produtosList.map((item) => {
        return { ...item, selecionado: status };
    });
    setListProduto(listSelecionar);

  }

  const ProcessarAssociacao = async () => {

    try { 

      

      setActionStatus(1)
      const selecionados = getProdutoSelecionados()
        .map(item => item.prb_cdprodutobluesoft);



      if (selecionados.length === 0) {
         window.alert("Selecione ao menos um produto para associar ao CBENEF PAG!")
         return 
      }

      if (!window.confirm(`confirma associação dos ${selecionados.length} iten(s)`)) {
         return
      }

      const stringListaProduto = selecionados.join(',');

      let parametro : any = { 
          fc_cbenef_cd : fc_cbenef_cdAssociar
        , lista_produtos : stringListaProduto
      }

      await myModuleFiscal.AtualizarProdutoCbenefPag(parametro)


      setActionStatus(0)
      clearData();

      window.alert(`Associação processada, favor realizar consulta para conferir!`)

    } catch (e) {
        window.alert(`Erro ao processar associação: ${e}`)
    } finally {
        setActionStatus(0)
    }
      
      
  }

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

  const clearData = () => { 
    setListProduto([])
  };

  const ExportarBluesoft = async (vincular: boolean) => {
    try {

        if (vincular) {
          if (CbenefPAGFilter.trim() === '') {
            window.alert("Selecione um CBENEF PAG e pesquise e pesquise os produtos para a exportação")
            return;
          }
        }
        else {
          if (CbenefBlueFilter.trim() === '') {
            window.alert("Selecione um CBENEF BLUE e pesquise e pesquise os produtos para a exportação")
            return;
          }
        }

        let CBENEF_SELECIONADO = vincular ? CbenefPAGFilter : CbenefBlueFilter


        if (getProdutoSelecionados().length === 0) {
          window.alert("Selecione ao menos um produto para exportar para a Bluesoft!")
          return;
        }

        if (!window.confirm("Confirma iniciar o processo de atualização na base bluesoft?")) {
            return;
        }

        setActionStatus(1)

        const selecionados = getProdutoSelecionados()
        .map(item => item.prb_cdprodutobluesoft);
        const stringListaProduto = selecionados.join(',');

        let parametro : any = {
          fc_cbenef_cd : CBENEF_SELECIONADO,
          lista_produtos : stringListaProduto,
          vincular : vincular? 1: 0

        }
        await myModuleFiscal.ExportaProdutoCbenefPagParaBluesoft(parametro)
       
        window.alert("Exportação realizada! Verifique o ambiente Bluesoft para confirmar os dados exportados.")

    } catch (e) {
        window.alert(`Erro ao exportar para a Bluesoft: ${e}`)

    } finally { 
      await consultaProdutos()
      setActionStatus(0)
    }
  }

  const getProdutoSelecionados = () : TpCbenefProduto[] => {
    return produtosList.filter(item => item.selecionado);
  }


  const consultaProdutos = async () => { 

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
        , distribuica_regime_tributacao: DistribuicaoRegimeCliente
        , fornecedor_razao_social: fornecedor_razao_social
        , figurafiscalassociada: figurafiscalassociada
        , figurafiscal: figurafiscal
        , ncm: ncm 
        , cest: cest
        , operacaoVisualizar: operacaoVisualizar
        , filtrar_entrada_saida_negativo: filtrarComMovimentacaoNegativa ? 1 : 0
        , prb_descricao_fiscal: descricaoFiscalFilter
        , filtrarComRegraNfce: filtrarComRegraNfce
        , filtrarcomestoque: filtrarcomestoque
        , ComCbenefPAGFilter: ComCbenefPAGFilter == 1 ? 1 : 0
        , cbenefpagFilter: CbenefPAGFilter
        , ComCbenefBlueFilter: ComCbenefBlueFilter == 1 ? 1 : 0
        , cbenefblueFilter: CbenefBlueFilter
        , CSTFilter: CSTFilter
        , SemCbenefBlueFilter: SemCbenefBlueFilter == 1 ? 1 : 0
    }
    setActionStatus(1)
    setListProduto([])
    

    const response = await myModuleFiscal.getListCbenefProduto(parametro)

    setListProduto(response)
    setActionStatus(0)

  }

  const selecionarProduto = (pr_cdproduto: number) => {
    let listSelecionar : TpCbenefProduto[] = produtosList.map((item) => {
      if (item.pr_cdproduto === pr_cdproduto) {
        item.selecionado = !item.selecionado;
      }
      return item;
    });
    setListProduto(listSelecionar);
  };

  const atualizarCbenefZanthus = async () => {
    try {

        if (!window.confirm("Confirma iniciar o processo de atualização do CBENEF no Zanthus?")) {
            return;
        }
        setActionStatus(1)
        
        await myModuleFiscal.cbenefAtualizarZanthus()

        

    } catch (e) {
      setActionStatus(0)  
      window.alert(`Erro ao iniciar atualização no Zanthus: ${e}`)

    } finally {
      setActionStatus(0)  
      window.alert("Processo de atualização na Zanthus concluído!")
      
    }
  }


  return (
    <div className="min-h-screen bg-gray-50 p-6">
      {ActionStatus === 1 && (
        <div 
          className="fixed inset-0 z-50 cursor-wait bg-black bg-opacity-10"
          style={{ 
            backdropFilter: 'blur(1px)',
            pointerEvents: 'all' // captura todos os eventos do mouse
          }}
        />
      )}
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Produto | CBENEF _ Código de Benefício Fiscal" >
          
          <div className="flex space-x-2">

            {ActionAcessoAtualizaZanthus && (
              <ButtonPag TypeButton="_BUTTON_HEADER" label="Atualiza CBENEF Base Zanthus" TypeIcon="_SALVAR" title="Atualiza Base Zanthus" onClick={atualizarCbenefZanthus} ActionStatus={ActionStatus}></ButtonPag>
            )}

            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={consultaProdutos} ActionStatus={ActionStatus}></ButtonPag>
          </div>              
     
        </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100 grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-4">
         



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

            {/* Filtro por Descrição */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Descrição Fiscal</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por descrição Fiscal"
                value={descricaoFiscalFilter}
                onChange={(e) => setDescricaoFiscalFilter(e.target.value)}
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
                <option value="">Todos</option>
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
          <div className="flex-row col-span-1">
              <label className="block text-sm font-medium text-gray-700 mb-1">
                <input
                  type="checkbox"
                  checked={filtrarcomestoque === 1}
                  onChange={(e) => setfiltrarcomestoque(e.target.checked ? 1 : 0)}
                  className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                />
                Apenas Produtos com Estoque
              </label>
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

              <label className="block text-sm font-medium text-gray-700 mb-1">
                <input
                  type="checkbox"
                  checked={filtrarComMovimentacaoNegativa}
                  disabled={!filtrarComMovimentacao}
                  onChange={(e) => setfiltrarComMovimentacaoNegativa(e.target.checked)}
                  className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                />
                Sem Movimentação
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
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Operação</label>
              <select

                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={operacaoVisualizar}
                onChange={(e) => setOperacaoVisualizar(e.target.value)}
              >
                <option value="2">Loja</option>
                <option value="1">Distribuição</option>
              </select>
            </div>
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Regime Tributação cliente força de venda</label>
              <select

                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black bg-white disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                value={DistribuicaoRegimeCliente}
                onChange={(e) => setDistribuicaoRegimeCliente(e.target.value)}
                disabled={operacaoVisualizar !== "1"}
              >
                <option value="N">Normal</option>
                <option value="S">Simples</option>
                <option value="C">Consumidor</option>
              </select>
            </div>

            {/* Filtro por Fornecedor */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Fornecedor</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por fornecedor"
                value={fornecedor_razao_social}
                onChange={(e) => setfornecedor_razao_social(e.target.value)}
              />
            </div>


            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Status Figura Fiscal</label>
              <select

                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black bg-white disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                value={figurafiscalassociada}
                onChange={(e) => { 
                  clearData()
                  setfigurafiscalassociada(e.target.value)
                  setfigurafiscal("")

                }}

              >
                <option value="T">Todos</option>
                <option value="S">Com Figura Fiscal</option>
                <option value="N">Sem Figura Fiscal</option>
              </select>
            </div>

                        <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Status Regra NFCE</label>
              <select

                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black bg-white disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                value={filtrarComRegraNfce}
                onChange={(e) => { 
                  clearData()
                  setfiltrarComRegraNfce(e.target.value)

                }}
                disabled={!(figurafiscalassociada === "S")}

              >
                <option value="T">Todos</option>
                <option value="S">C/ Regra NFCE</option>
                <option value="N">S/ Regra NFCE</option>
              </select>
            </div> 


            {/* Descrição Figura FIscal */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Descrição Figura Fiscal</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black bg-white disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                placeholder="Filtrar por descrição"
                value={figurafiscal}
                disabled={!(figurafiscalassociada === "S")}
                onChange={(e) => {
                  setfigurafiscal(e.target.value)

                }}
              />
            </div>


            {/* Filtro por ncm */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">NCM</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Informe o NCM"
                value={ncm}
                onChange={(e) => setNCM(e.target.value)}
              />
            </div>

            {/* Filtro por ncm */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">CEST</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Informe o CEST"
                value={cest}
                onChange={(e) => setCest(e.target.value)}
              />
            </div>

            {/* Filtro por CST */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">CEST</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Informe o CEST"
                value={CSTFilter}
                onChange={(e) => setCSTFilter(Number(e.target.value))}
              />
            </div>


        </div>
        



        <div className='md:flex md:items-center md:justify-between mb-4 grid-cols-3 md:grid-cols-3 lg:grid-cols-6 gap-4'>


                      
          <div className= "bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100 grid grid-cols-2 gap-4 ">


              <div className='grid grid-cols-2 gap-2 col-span-1 h-3'>
                <ButtonPag TypeButton="_BUTTON_HEADER" ActionStatus={ActionStatus} label="Selecionar Todos os Produtos da Lista" TypeIcon="_SALVAR" title="Salvar x" type="button" onClick={async () => await SelecionarTodos(true) } ></ButtonPag>
                <ButtonPag TypeButton="_BUTTON_HEADER" ActionStatus={ActionStatus} label="Limpar Seleção" TypeIcon="_SALVAR" title="Salvar x" type="button" onClick={async () => await SelecionarTodos(false) } ></ButtonPag>  
              </div>  
              
              
              <div className='grid grid-cols-2 gap-2'>
                <div className='grid grid-cols-1'>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Associações CBENEF</label>
                  <select
                    className="mt-2 w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                    onChange={async (e) => await CbenefConsultar(e.target.value)}
                    value={fc_cbenef_cdAssociar}
                    > 
                    <option value="X">* Excluir Registro PAG *</option>
                    {CBenefList.map((cbenef: any, index: number) => (
                      <option key={cbenef.fc_cbenef_cd} value={cbenef.fc_cbenef_cd}>{cbenef.fc_cbenef_cd} - {cbenef.fc_cbenef_objetivo}</option>
                    ))}

                  </select>
                  <div className='flex'> 
                      {CBenefCstList.length > 0 &&
                        <div className='mt-4 p-4 bg-purple-50 border border-purple-200 rounded-md'>
                          <h4 className='text-sm font-medium text-purple-700 mb-2'>CSTs Associados ao CBENEF Selecionado acima</h4>
                          <ul className='list-disc list-inside text-sm text-gray-700'>
                            {CBenefCstList.map((cbenefCst: any, index: number) => (
                              <li key={index}>CST: {cbenefCst.icms_codigo_tributacao}</li>
                            ))}
                          </ul>
                        </div>
                      }
                  </div>
                </div>
                
                <div className='row-span-1 items-center'>
                  <ButtonPag TypeButton="_BUTTON_HEADER" ActionStatus={ActionStatus} label="Associar PAG" TypeIcon="_SALVAR" title="Salvar x" type="button" onClick={ProcessarAssociacao} ></ButtonPag>
                </div>
              </div>

            
          </div>



            <div className= "bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100 flex-col grid grid-cols-2 gap-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">
                  <input
                    type="checkbox"
                    checked={ComCbenefPAGFilter === 1}
                    onChange={(e) => SetComCbenefPAGFilter(e.target.checked ? 1 : 0)}
                    className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                  />
                  Com CBenef Pag
                </label>     
                  <div> 
                    <select
                      className="mt-2 w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                      onChange={async (e) => { 
                        clearData()  
                        SetCbenefPAGFilter(e.target.value)
                      
                      } }
                      value={CbenefPAGFilter}
                      >
                      <option value="">Todos</option>
                      {CBenefList.map((cbenef: any, index: number) => (
                        <option key={cbenef.fc_cbenef_cd} value={cbenef.fc_cbenef_cd}>{cbenef.fc_cbenef_cd} - {cbenef.fc_cbenef_objetivo}</option>
                      ))}

                    </select>
                
                  </div>
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700 mb-1">Vincular os itens com a Bluesoft</label>
                    <ButtonPag TypeButton="_BUTTON_HEADER" ActionStatus={ActionStatus} label="Vincular Bluesoft" TypeIcon="_SALVAR" title="Salvar x" type="button" onClick={async () => await ExportarBluesoft(true) } ></ButtonPag>
                </div>
        </div>
          
        <div className= "bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100 flex-col grid grid-cols-2 gap-4">
                <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">
                  <input
                    type="checkbox"
                    checked={SemCbenefBlueFilter === 1}
                    onChange={(e) => { 
                        SetSemCbenefBlueFilter(e.target.checked ? 1 : 0)
                        SetComCbenefBlueFilter(0)
                      }
                    }
                    className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                  />
                  Sem CBenef Blue
                </label>    


                <label className="block text-sm font-medium text-gray-700 mb-1">
                  <input
                    type="checkbox"
                    checked={ComCbenefBlueFilter === 1}
                    onChange={(e) => SetComCbenefBlueFilter(e.target.checked ? 1 : 0)}
                    className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                    disabled={SemCbenefBlueFilter === 1}
                  />
                  Com CBenef Blue
                </label>     
                  <div> 
                    <select
                      className="mt-2 w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                      onChange={async (e) => { 
                        clearData()  
                        SetCbenefBlueFilter(e.target.value)
                      
                      } }
                      value={CbenefBlueFilter}
                      disabled={SemCbenefBlueFilter === 1}
                      >
                      <option value="">Todos</option>
                      {CBenefList.map((cbenef: any, index: number) => (
                        <option key={cbenef.fc_cbenef_cd} value={cbenef.fc_cbenef_cd}>{cbenef.fc_cbenef_cd} - {cbenef.fc_cbenef_objetivo}</option>
                      ))}

                    </select>
                
                  </div>
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700 mb-1">DESVINCULAR Bluesoft</label>
                    <ButtonPag TypeButton="_BUTTON_HEADER" ActionStatus={ActionStatus} label="Desvincular Bluesoft" TypeIcon="_SALVAR" title="Salvar x" type="button" onClick={async () => await ExportarBluesoft(false) } ></ButtonPag>
                </div>
            </div>
        </div>


        
        
        {/* Grid de Produtos */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-gray-100 sticky top-0 z-10">
                  {/* Primeira linha do cabeçalho - Grupos principais */}
                  <tr>
                    <th className="w-12 px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Dep</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">S</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Cd Unit Blue</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Descrição</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Figura (Antiga)</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Figura Fiscal</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Cst ICMS</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">CBENEF Pag</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">CBENEF Blue</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">NCM</th>
                    <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider border-r border-gray-300">Status</th>
                  </tr>
            
                </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {produtosList.length > 0 ? (
                  produtosList.map((product: TpCbenefProduto) => (
                    <tr key={product.pr_cdproduto} className="hover:bg-gray-50">
                      
                      
                      {/*Coluna com as informações do departamento*/}
                      <td className="w-12 px-1 py-2">
                        <div className='flex flex-col text-gray-700' > 
                         <label className='text-[10px]'>Departamento {product.prd_descricao} </label>
                         <label className='text-[10px]'>Grupo {product.prsg_cdsubgrupo}</label>
                         <label className='text-[10px]'>Descrição {product.prsg_descricao}</label>
                       
                        {product.subgrupo_fc_cbenef_cd?  
                        <div className='flex flex-col text-gray-700' > 
                         <label className='text-[12px] font-bold  text-blue-600'>CBenef Grupo {product.subgrupo_fc_cbenef_cd}</label>
                         <label className='text-[12px] font-bold'>Objetivo {product.cbenef_grupo_objetivo}</label>
                        </div>
                        : <label className='text-[12px] font-bold text-red-600'>SEM BENEF GRUPO</label>
                        }                        
                        
                        </div>
                      </td>
                      <td className="px-1 py-2 whitespace-nowrap text-sm text-gray-700 ">
                        <input
                          type="checkbox"
                          className="h-4 w-4 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                          checked={product.selecionado}
                          onChange={() => selecionarProduto(product.pr_cdproduto) }
                        />
                      </td>
                      <td className="px-1 py-2 text-sm text-gray-700 ">{product.prb_cdprodutobluesoft}</td>
                      <td className="px-1 py-2 text-sm text-gray-700 ">{product.prb_descricao}</td>
                      <td className="px-1 py-2 text-sm text-gray-700 ">{product.prbt_icms_saida_cst}</td>
                      <td className="px-1 py-2 text-sm text-gray-700 ">{product.fc_figurafiscal_descricao}</td>
                      <td className="px-1 py-2 text-sm text-gray-700 ">{product.icms_codigo_tributacao}</td>

                      <td className="w-12 px-1 py-2">
                        {product.pr_pag_fc_cbenef_cd?  
                        <div className='flex flex-col text-gray-700' > 
                         <label className='text-[12px] font-bold  text-blue-600'>CBenef Pag {product.pr_pag_fc_cbenef_cd}</label>
                         <label className='text-[12px] font-bold'>Objetivo {product.cbenef_pag_objetivo}</label>
                        </div>
                        : ""
                        }
                      </td>                      
                      <td className="w-12 px-1 py-2">
                        {product.prb_blue_fc_cbenef_cd?  
                        <div className='flex flex-col text-gray-700' > 
                         <label className='text-[12px] font-bold  text-blue-600'>CBenef Blue {product.prb_blue_fc_cbenef_cd}</label>
                         <label className='text-[12px] font-bold'>Objetivo {product.cbenef_blue_objetivo}</label>
                        </div>
                        : ""
                        }
                      </td>

                      <td className="px-1 py-2 text-sm text-gray-700 ">{product.ncm_codigo}</td>
                      <td className="px-1 py-2 text-sm text-gray-700 text-left">{product.prb_status? "Ativo" : "Inativo" }</td>
                      
                  </tr>
                  ))
                ) : (
                  <tr> 
                    <td colSpan={6} className="px-6 py-4 text-center text-sm text-gray-500">
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


          <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
            <div className="flex justify-end items-center">
              <h3 className="text-mg font-medium text-gray-500">A fim de evitar lentidão na interface é altamente recomendável empregar o máximo de filtros disponíveis.</h3>
            </div>
          </div>
      </div>
    </div>
  );
}





