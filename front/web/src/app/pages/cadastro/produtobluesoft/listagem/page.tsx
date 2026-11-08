'use client'
const __SIS_AC_CD: number = 1150

import { useEffect, useState } from "react"
import { useAuth } from "@/app/context/context"

/* Componentes */
import HeaderMain from "@/app/components/divs/headerMain"
import ButtonPag from "@/app/components/Buttons/button"
import ProdutoModal from "../../produto/listagem/modalproduto";

import { moduleProdutoBluesoft, moduleProdutoBluesoftParametro } from "@/api/m0021_produtoBluesoft/moduleprodutobluesoft"
import {moduleProduto
      , moduleProdutoCategoria
      , TpProduto
      , TpProdutoCategoria
      , TpProdutoDepartamento
      , TpProdutoGrupo
      , TpProdutoSecao
      , TpProdutoSubGrupo
    
    } from '@/api/m0020_produto/moduleproduto'


let myModule: moduleProdutoBluesoft
let myModuleProdutoCategoria : moduleProdutoCategoria




export default function ProdutoBluesoftListagemPage() {
  const { user } = useAuth()

  const [modalOpen, setModalOpen] = useState(false);
  const [selectedProdutoId, setSelectedProdutoId] = useState<number | null>(null);

  const [ActionStatus, setActionStatus] = useState<number>(0)
  const [List, setList] = useState<any[]>([])

  /* Filtros */
  const [prb_cdprodutobluesoft, setPrbCdProdutoBluesoft] = useState<number>(0)
  const [prb_cdprodutobluesoftunitario, setPrbCdProdutoBluesoftUnitario] = useState<number>(0)
  const [prb_descricao, setPrbDescricao] = useState<string>("")
  const [prb_cdbarra_principal, setPrbCdBarraPrincipal] = useState<string>("")
  const [prb_status, setPrbStatus] = useState<string>("1")

  const [dtlog_insert_filter, setDtlogInsertFilter] = useState<boolean>(false)
  const [dtlog_insert_ini, setDtlogInsertIni] = useState<string>(() => user.formatDateNowToStr())
  const [dtlog_insert_fim, setDtlogInsertFim] = useState<string>(() => user.formatDateNowToStr())

  const [dtlog_update_filter, setDtlogUpdateFilter] = useState<boolean>(false)
  const [dtlog_update_ini, setDtlogUpdateIni] = useState<string>(() => user.formatDateNowToStr())
  const [dtlog_update_fim, setDtlogUpdateFim] = useState<string>(() => user.formatDateNowToStr())

  const [prb_dtupdate_from_api_filter, setPrbDtUpdateFromApiFilter] = useState<boolean>(false)
  const [prb_dtupdate_from_api_ini, setPrbDtUpdateFromApiIni] = useState<string>(() => user.formatDateNowToStr())
  const [prb_dtupdate_from_api_fim, setPrbDtUpdateFromApiFim] = useState<string>(() => user.formatDateNowToStr())

  const [informacao_checkout_filter, setInformacaoCheckoutFilter] = useState<boolean>(false)
  const [informacao_checkout, setInformacaoCheckout] = useState<string>("1") // 1=incompleto / 0=completo
  const [apenasunitario, setApenasUnitario] = useState<boolean>(true)

  const [listEmbalagemPadrao, setListEmbalagemPadrao] = useState<any[]>([])

  const [prb_embalagemfiltro, setPrbEmbalagemFiltro] = useState<string>("")

  const [ProdutoDepartamento, setProdutoDepartamento] = useState<TpProdutoDepartamento[]>([]);
  const [ProdutosSecao, setProdutosSecao] = useState<TpProdutoSecao[]>([]);


  const [DepartamentoFilterID, setDepartamentoFilterId] = useState("");
  const [SecaoFilterID, setSecaoFilterId] = useState("");

  const [processamentoProdutoApi, setProcessamentoProdutoApi] = useState<string>("")


      const [filtrarComMovimentacao, setfiltrarComMovimentacao] = useState(false);
      const [filtrarComMovimentacaoZero, setfiltrarComMovimentacaoZero] = useState(false);
      const [filtrarComMovimentacaoTipo, setfiltrarComMovimentacaoTipo] = useState('ENTRADA');
      const [filtrarComMovimentacaoNumeroMes, setfiltrarComMovimentacaoNumeroMes] = useState(1);
      const [filtrarcomestoque, setfiltrarcomestoque] = useState(0);

  const changeDepartamento = async (prd_cddepartamento: number) => { 
      setDepartamentoFilterId(prd_cddepartamento.toString())
      await FiltrarSecao(prd_cddepartamento)
  }

  const FiltrarSecao = async (departamentoID: number) => { 
    try {
        setActionStatus(1)
        await myModuleProdutoCategoria.getSecao(departamentoID)
        setProdutosSecao(myModuleProdutoCategoria.Secao)
        setSecaoFilterId("")
        setActionStatus(0)

    } catch (e) {
       setActionStatus(0)
        console.log(`Filtrar Secao Error ${e}`)

  }
}

  useEffect(() => {
    myModule = new moduleProdutoBluesoft(user, __SIS_AC_CD)
    myModuleProdutoCategoria = new moduleProdutoCategoria(user);

    setListEmbalagemPadrao(myModule.listEmbalagemPadrao)

        const BindingData = async () => {
        await myModuleProdutoCategoria.getCategoria()
        setProdutoDepartamento( await myModuleProdutoCategoria.getDepartamento() );
        await FiltrarSecao(0)
    };
  
    BindingData();

  }, [user])

  const limparFiltros = () => {
    setPrbCdProdutoBluesoft(0)
    setPrbCdProdutoBluesoftUnitario(0)
    setPrbDescricao("")
    setPrbCdBarraPrincipal("")
    setPrbStatus("")

    setDtlogInsertFilter(false)
    setDtlogInsertIni("")
    setDtlogInsertFim("")

    setDtlogUpdateFilter(false)
    setDtlogUpdateIni("")
    setDtlogUpdateFim("")

    setPrbDtUpdateFromApiFilter(false)
    setPrbDtUpdateFromApiIni("")
    setPrbDtUpdateFromApiFim("")

    setInformacaoCheckoutFilter(false)
    setInformacaoCheckout("1")
    setApenasUnitario(false)
  }

  

  const consultarList = async () => {
    try {

      if (    prb_cdprodutobluesoft == 0
           && prb_cdprodutobluesoftunitario == 0
           && prb_descricao == ""
           && prb_cdbarra_principal == ""
           && !dtlog_insert_filter
           && !dtlog_update_filter
           && !prb_dtupdate_from_api_filter
           && SecaoFilterID == ""
           && !informacao_checkout_filter
          && !filtrarComMovimentacao
          )
           
           {
          alert("Favor informar ao menos um filtro para consulta.")
          return
      }

      setActionStatus(1)
      setList([])

      

      const parametro: any = {
        prb_cdprodutobluesoft: prb_cdprodutobluesoft !== 0 ? Number(prb_cdprodutobluesoft) : 0,
        prb_cdprodutobluesoftunitario: prb_cdprodutobluesoftunitario !== 0 ? Number(prb_cdprodutobluesoftunitario) : 0,
        prb_descricao: prb_descricao,
        prb_cdbarra_principal: prb_cdbarra_principal,
        prb_status: prb_status,

        dtlog_insert_filter: dtlog_insert_filter ? "1" : "0",
        dtlog_insert_ini: dtlog_insert_ini,
        dtlog_insert_fim: dtlog_insert_fim,

        dtlog_update_filter: dtlog_update_filter ? "1" : "0",
        dtlog_update_ini: dtlog_update_ini,
        dtlog_update_fim: dtlog_update_fim,

        prb_dtupdate_from_api_filter: prb_dtupdate_from_api_filter ? "1" : "0",
        prb_dtupdate_from_api_ini: prb_dtupdate_from_api_ini,
        prb_dtupdate_from_api_fim: prb_dtupdate_from_api_fim,

        informacao_checkout_filter: informacao_checkout_filter ? "1" : "0",
        informacao_checkout: informacao_checkout,
        apenasunitario: apenasunitario ? "1" : "0", 
        prb_embalagemfiltro: prb_embalagemfiltro,
        prd_cddepartamento: DepartamentoFilterID,
        prs_cdsecao: SecaoFilterID 

        , filtrar_entrada_saida : filtrarComMovimentacao ? 1 : 0
        , filtrar_entrada_saida_tipo : filtrarComMovimentacaoTipo
        , filtrar_entrada_saida_numero_mes : filtrarComMovimentacaoNumeroMes        
        , filtrar_entrada_saida_zero : filtrarComMovimentacaoZero ? 1 : 0

      }

      const response = await myModule.getList(parametro)

      setList(Array.isArray(response) ? response : [])

    } catch (error) {

      console.error("Erro ao consultar lista de produtos bluesoft:", error)
      setList([])

    } finally {

      setActionStatus(0)
    }
  }

  const exportarExcel = () => {
    user.exportGridToExcel(
      List,
      "produtobluesoft_listagem",
      (item: any) => ({
        Secao: item.prs_descricao ?? "",
        Unitario: `${item.prb_descricaounitaria ?? ""} - ${item.prb_cdprodutobluesoftunitario ?? ""}`,
        Status: item.prb_status === 1 ? "Ativo" : "Inativo",
        Codigo: item.prb_cdprodutobluesoft_pk ?? "",
        Descricao: item.prb_descricao ?? "",
        Embalagem: item.prb_embalagemestoque ?? "",
        PesoBruto: item.prb_pesobruto ?? 0,
        PesoLiquido: item.prb_pesoliquido ?? 0,
        Comprimento: item.prb_comprimento ?? 0,
        Largura: item.prb_largura ?? 0,
        Altura: item.prb_altura ?? 0,
        PesoAproximado: item.prb_pesoaproximado ?? 0
      })
    )
  }


  
  const AtualizarProdutoList = async () => {
        try {
            setActionStatus(1);

            for await (const item of (List as any[])) {

                let parametros: moduleProdutoBluesoftParametro = {
                    numeroDiasUltimaAlteracao: 0,
                    AtualizaLog: 1,
                    produtoKey: item.prb_cdprodutobluesoft_pk,   
                    NaoProcessarBasePag: 1

                }
                const response = await myModule.postImportList(parametros);
                setProcessamentoProdutoApi(`Atualizando produto ${item.prb_cdprodutobluesoft_pk} - ${item.prb_descricao} ...`)
            }
            setProcessamentoProdutoApi(``)
            setActionStatus(0);

        } catch (error) {
            console.error('Erro ao importar produtos Bluesoft:', error);
            setActionStatus(0);
        }
  };
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
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Produto Bluesoft | Listagem">
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={consultarList} />
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Limpar" TypeIcon="_PESQUISAR" title="Limpar filtros" onClick={limparFiltros} />
          </div>
        </HeaderMain>

        <div className="bg-white rounded-lg shadow-md p-4 mb-6 border border-purple-100">
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-6 gap-x-3 gap-y-2">
            <div>
              <label className="block text-xs font-medium text-gray-700 mb-1">Código Bluesoft PK</label>
              <input className="w-full p-1.5 text-sm border border-gray-300 rounded-md text-black" value={prb_cdprodutobluesoft} onChange={(e) => setPrbCdProdutoBluesoft(user.toNumber(e.target.value))} />
            </div>

            <div>
              <label className="block text-xs font-medium text-gray-700 mb-1">Código Unitário</label>
              <input className="w-full p-1.5 text-sm border border-gray-300 rounded-md text-black" value={prb_cdprodutobluesoftunitario} onChange={(e) => setPrbCdProdutoBluesoftUnitario(user.toNumber(e.target.value))} />
            </div>

            <div className="sm:col-span-2 lg:col-span-2">
              <label className="block text-xs font-medium text-gray-700 mb-1">Descrição</label>
              <input className="w-full p-1.5 text-sm border border-gray-300 rounded-md text-black" value={prb_descricao} onChange={(e) => setPrbDescricao(e.target.value)} />
            </div>

            <div>
              <label className="block text-xs font-medium text-gray-700 mb-1">Código de Barras</label>
              <input className="w-full p-1.5 text-sm border border-gray-300 rounded-md text-black" value={prb_cdbarra_principal} onChange={(e) => setPrbCdBarraPrincipal(e.target.value)} />
            </div>

            <div>
              <label className="block text-xs font-medium text-gray-700 mb-1">Status</label>
              <select className="w-full p-1.5 text-sm border border-gray-300 rounded-md text-black" value={prb_status} onChange={(e) => setPrbStatus(e.target.value)}>
                <option value="">Todos</option>
                <option value="1">Ativo</option>
                <option value="0">Inativo</option>
              </select>
            </div>

            <div className="lg:col-span-2">
              <label className="block text-xs font-medium text-gray-700 mb-1">Departamento</label>
              <select
                className="w-full p-1.5 text-sm border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
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
            <div className="lg:col-span-2">
              <label className="block text-xs font-medium text-gray-700 mb-1">Seção</label>
              <select
                className="w-full p-1.5 text-sm border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                value={SecaoFilterID}
                onChange={(e) => setSecaoFilterId((e.target.value))}
              >
                <option value="">Todas</option>
                {ProdutosSecao.map((section, index) => (
                  <option key={index} value={section.prs_cdsecao}>{section.prs_descricao}</option>
                ))}
              </select>
            </div>
            <div className="lg:col-span-2">
              <label className="block text-xs font-medium text-gray-700 mb-1">Filtro Embalagem</label>
              <select
                className="w-full p-1.5 text-sm border border-gray-300 rounded-md text-black"
                value={prb_embalagemfiltro}
                onChange={(e) => setPrbEmbalagemFiltro(e.target.value)}
              >
                {listEmbalagemPadrao.map((item) => (
                  <option key={item.prb_embalagemfiltro} value={item.prb_embalagemfiltro}>
                    {item.prb_embalagemfiltro_descricao}
                  </option>
                ))}
              </select>
            </div>

            <div className="lg:col-span-2 border rounded p-2">
              <div className="flex items-center gap-2 mb-1">
                <input type="checkbox" checked={dtlog_insert_filter} onChange={(e) => setDtlogInsertFilter(e.target.checked)} />
                <label className="text-xs font-medium text-gray-700">Filtrar Dt Log Insert</label>
              </div>
              <div className="grid grid-cols-2 gap-2">
                <input type="date" disabled={!dtlog_insert_filter} className="min-w-0 w-full p-1.5 text-sm border border-gray-300 rounded-md text-black disabled:bg-gray-100" value={dtlog_insert_ini} onChange={(e) => setDtlogInsertIni(e.target.value)} />
                <input type="date" disabled={!dtlog_insert_filter} className="min-w-0 w-full p-1.5 text-sm border border-gray-300 rounded-md text-black disabled:bg-gray-100" value={dtlog_insert_fim} onChange={(e) => setDtlogInsertFim(e.target.value)} />
              </div>
            </div>

            <div className="lg:col-span-2 border rounded p-2">
              <div className="flex items-center gap-2 mb-1">
                <input type="checkbox" checked={dtlog_update_filter} onChange={(e) => setDtlogUpdateFilter(e.target.checked)} />
                <label className="text-xs font-medium text-gray-700">Filtrar Dt Log Update</label>
              </div>
              <div className="grid grid-cols-2 gap-2">
                <input type="date" disabled={!dtlog_update_filter} className="min-w-0 w-full p-1.5 text-sm border border-gray-300 rounded-md text-black disabled:bg-gray-100" value={dtlog_update_ini} onChange={(e) => setDtlogUpdateIni(e.target.value)} />
                <input type="date" disabled={!dtlog_update_filter} className="min-w-0 w-full p-1.5 text-sm border border-gray-300 rounded-md text-black disabled:bg-gray-100" value={dtlog_update_fim} onChange={(e) => setDtlogUpdateFim(e.target.value)} />
              </div>
            </div>

            <div className="lg:col-span-2 border rounded p-2">
              <div className="flex items-center gap-2 mb-1">
                <input type="checkbox" checked={prb_dtupdate_from_api_filter} onChange={(e) => setPrbDtUpdateFromApiFilter(e.target.checked)} />
                <label className="text-xs font-medium text-gray-700">Filtrar Dt Update API</label>
              </div>
              <div className="grid grid-cols-2 gap-2">
                <input type="date" disabled={!prb_dtupdate_from_api_filter} className="min-w-0 w-full p-1.5 text-sm border border-gray-300 rounded-md text-black disabled:bg-gray-100" value={prb_dtupdate_from_api_ini} onChange={(e) => setPrbDtUpdateFromApiIni(e.target.value)} />
                <input type="date" disabled={!prb_dtupdate_from_api_filter} className="min-w-0 w-full p-1.5 text-sm border border-gray-300 rounded-md text-black disabled:bg-gray-100" value={prb_dtupdate_from_api_fim} onChange={(e) => setPrbDtUpdateFromApiFim(e.target.value)} />
              </div>
            </div>

            <div className="lg:col-span-2 border rounded p-2">
              <div className="flex items-center gap-2 mb-1">
                <input
                  type="checkbox"
                  checked={informacao_checkout_filter}
                  onChange={(e) => setInformacaoCheckoutFilter(e.target.checked)}
                />
                <label className="text-xs font-medium text-gray-700">Filtro Informação Checkout</label>
              </div>
              <select
                disabled={!informacao_checkout_filter}
                className="w-full p-1.5 text-sm border border-gray-300 rounded-md text-black disabled:bg-gray-100"
                value={informacao_checkout}
                onChange={(e) => setInformacaoCheckout(e.target.value)}
              >
                <option value="1">Incompleto</option>
                <option value="0">Completo</option>
              </select>
            </div>

            <div className="lg:col-span-2 flex items-center border rounded p-2">
              <div className="flex items-center gap-2">
                <input
                  type="checkbox"
                  checked={apenasunitario}
                  onChange={(e) => setApenasUnitario(e.target.checked)}
                />
                <label className="text-xs font-medium text-gray-700">Listar apenas unitário</label>
              </div>
            </div>
            <div className="lg:col-span-6 grid grid-cols-1 sm:grid-cols-6 gap-2 items-end border rounded p-2">
              <div className="sm:col-span-2 flex flex-wrap items-center gap-x-3 gap-y-1">
                <label className="flex items-center text-xs font-medium text-gray-700">
                  <input
                    type="checkbox"
                    checked={filtrarComMovimentacao}
                    onChange={(e) => setfiltrarComMovimentacao(e.target.checked)}
                    className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                  />
                  Filtrar por Movimentação de Estoque
                </label>
                <label className="flex items-center text-xs font-medium text-gray-700">
                  <input
                    type="checkbox"
                    checked={filtrarComMovimentacaoZero}
                    disabled={!filtrarComMovimentacao}
                    onChange={(e) => setfiltrarComMovimentacaoZero(e.target.checked)}
                    className="mr-2 h-3 w-3 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                  />
                  Sem Movimentação
                </label>
              </div>

              <div className="sm:col-span-3">
                <label className="block text-xs font-medium text-gray-700 mb-1">Tipo Movimentação</label>
                <select
                  className="w-full p-1.5 text-sm border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                  value={filtrarComMovimentacaoTipo}
                  onChange={(e) => setfiltrarComMovimentacaoTipo(e.target.value)}
                  disabled={!filtrarComMovimentacao}
                >
                  <option value="ENTRADA">Entrada (Tab Nota Fiscais de Entrada)</option>
                  <option value="SAIDA">Saída (Tabela de Estatística PRIME)</option>
                </select>
              </div>
              <div className="sm:col-span-1">
                <label className="block text-xs font-medium text-gray-700 mb-1">N. de Meses</label>
                <input
                  type="number"
                  className="w-full p-1.5 text-sm border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                  placeholder="Meses"
                  value={filtrarComMovimentacaoNumeroMes}
                  onChange={(e) => setfiltrarComMovimentacaoNumeroMes(Number(e.target.value))}
                  disabled={!filtrarComMovimentacao}
                />
              </div>
              </div>
        </div>
        </div>


        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                  
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Produto Unitário</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Código</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Status</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Descrição</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Seção</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700"></th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Peso Bruto</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Peso Líquido</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Comprimento</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Largura</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Altura</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Peso Aproximado</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700">Log</th>
                  
                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {List.length > 0 ? (
                  List.map((item: any, index: number) => (
                    <tr key={item.prb_cdprodutobluesoft_pk ?? index} className="hover:bg-gray-50">
                      

                      
  <td 
                        className="px-1 py-2 whitespace-nowrap text-sm text-blue-600 text-right cursor-pointer hover:text-blue-800 hover:underline"
                        onClick={() => abrirModalProduto(item.prb_cdprodutobluesoftunitario)}
                        title="Clique para ver detalhes do produto"
                      >
                        {item.prb_cdprodutobluesoftunitario}
                      </td>

                      <td className="px-4 py-2 text-sm text-gray-700">
                        {item.prb_cdprodutobluesoft_pk}
                      </td>

                      
                      <td className="px-4 py-2 text-sm text-gray-700">
                          <span className={`inline-block w-3 h-3 rounded-full ${item.prb_status === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                      </td>   


                   
                      
                      
                    <td className="px-4 py-2 text-sm text-gray-700 min-w-[320px]">
                      {item.prb_descricao}
                      <div>Seção {item.prs_descricao}: </div>
                      <div className="font-semibold">
                        Ref. Pag: {item.pr_cdproduto}
                      </div>
                    </td>


                      <td className="px-4 py-2 text-sm text-gray-700">{item.prs_descricao}</td>

                      <td className="px-4 py-2 text-sm text-gray-700">{item.prb_embalagemestoque}</td>
                      <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.prb_pesobruto,3)}</td>
                      <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.prb_pesoliquido,3)}</td>
                      <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.prb_comprimento,3)}</td>
                      <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.prb_largura,3)}</td>
                      <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.prb_altura,3)}</td>
                      <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.prb_pesoaproximado,3)}</td>
                      <td className="px-4 py-2 text-sm text-gray-700 text-left align-top whitespace-normal break-words min-w-[220px]">
                        I. {user.formatDateTimeToStringYYYMMDDHHMMSS(item.dtlog_insert)} <br />
                        U. {user.formatDateTimeToStringYYYMMDDHHMMSS(item.dtlog_update)} <br />
                        Api {user.formatDateTimeToStringYYYMMDDHHMMSS(item.prb_dtupdate_from_api)}
                      </td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan={11} className="px-6 py-4 text-center text-sm text-gray-500">
                      Nenhum registro encontrado
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>

        <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
          <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
            Total de Registros {List.length}
          </span>
                 <div className="mt-4 flex items-center justify-end gap-2">
          {processamentoProdutoApi && (
            <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-yellow-100 text-yellow-800">
              {processamentoProdutoApi}
            </span>
          )}

        

          <ButtonPag
            TypeButton="_BUTTON_HEADER"
            label="Atualizar Produto"
            TypeIcon="_SALVAR"
            title={List.length > 0 ? "Atualizar produtos da listagem" : "Sem dados para atualizar"}
            onClick={() => {
              if (List.length === 0) return
              AtualizarProdutoList()
            }}
            ActionStatus={ActionStatus}
          />

          <ButtonPag
            TypeButton="_BUTTON_HEADER"
            label="Exportar Excel"
            TypeIcon="_SALVAR"
            title={List.length > 0 ? "Exportar dados da listagem" : "Sem dados para exportar"}
            onClick={() => {
              if (List.length === 0) return
              exportarExcel()
            }}
            ActionStatus={ActionStatus}
          />
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
    
  )
}
