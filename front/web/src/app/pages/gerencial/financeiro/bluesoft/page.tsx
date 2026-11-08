'use client'
import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

const InputDateClassName = "w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"

/*Modulos API*/
import { moduleFinanceiro, tpAutorizacaoPagamento, tpAutorizacaoPagamentoTipo} from "@/api/m0080_financeiro/modulefinanceiro";
import { moduleResultado, re_conta } from "@/api/m0100_resultado/moduleResultado";
import { moduleEnterprise, re_compentencia } from "@/api/m0002_enterprise/moduleEnterprise";

/*Modals*/
import ModalAutorizacaoPgto from "./ModalAutorizacaoPgto";


export default function FinanceiroBlueSoft() {
  
  const { user } = useAuth()
  
  let myModule : moduleFinanceiro = new moduleFinanceiro(user);
  let myModuleResultado : moduleResultado = new moduleResultado()


  /*Scren Controls*/
  const [ActionStatus, setActionStatus] = useState(0)
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [actionOpenModel, setActionOpenModel] = useState("_SELECT")
  
  /*Filtros*/
  //const [filternomerazao, setnomerazao] = useState('');

  const [ModalAutorizacaoPagamentoSelect, setModalAutorizacaoPagamentoSelect] = useState<tpAutorizacaoPagamento | null>(null);
  
  
  const [filterdata_Emissao, setfilterdata_Emissao]= useState(0)
  const [filterdata_Emissao_ini, setfilterdata_Emissao_ini] = useState(new Date())
  const [filterdata_Emissao_fim, setfilterdata_Emissao_fim] = useState(new Date())

  const [filterdata_Vencimento, setfilterdata_Vencimento]= useState(0)
  const [filterdata_Vencimento_ini, setfilterdata_Vencimento_ini] = useState(new Date())
  const [filterdata_Vencimento_fim, setfilterdata_Vencimento_fim] = useState(new Date())

  const [filterdata_Pagamento, setfilterdata_Pagamento]= useState(0)
  const [filterdata_Pagamento_ini, setfilterdata_Pagamento_ini] = useState(new Date())
  const [filterdata_Pagamento_fim, setfilterdata_Pagamento_fim] = useState(new Date())

  const [filterr_conta_cd, setfilterr_conta_cd] = useState(0)
  
  const [filtercancelado, setfiltercancelado] = useState(0)

  const [filterdespesabluesoft, setfilterdespesabluesoft] = useState(0)

  const [filterCompentencia, setfilterCompetencia] = useState<re_compentencia | null>(null)
  const [filterCompentenciabluesoft, setfilterCompetenciabluesoft] = useState<re_compentencia | null>(null)
  const [filterautpgto_tipo, setfilterautpgto_tipo] = useState("")

  const [filterautpgto_seq_pk, setfilterautpgto_seq_pk] = useState(0)
  
  const [filterTipoVisualizacao, setfilterTipoVisualizacao] = useState("DP")
  const [resultMessage, setresultMessage] = useState("Nenhum registro encontrado.")


  //LISTS
  const [ListResultadoConta, setListResultadoConta] = useState<re_conta[]> ([])
  const [ListCompetencia, setListCompetencia] = useState<re_compentencia[]>([])
  const [listOptionAutPgtoTipo, setlistOptionAutPgtoTipo] = useState<tpAutorizacaoPagamentoTipo[]>([])

  /*Lista Principal*/
  const [listAutorizacaoPagamento, SetlistAutorizacaoPagamento] = useState <tpAutorizacaoPagamento[]> ([])

  /*Item modal*/


  /*------------------------------------------------------------------------*/


  useEffect(() => { 
    async function Binding() {
      try {
          setActionStatus(1)
          // Preenchendo combobox de conta ____________________________
          let myListResultadoConta : re_conta[] = await myModuleResultado.getListConta({orderbycolunm:"r_conta_descricao"})
            setListResultadoConta(myListResultadoConta)

          let mylistCompetencia : re_compentencia[] = await new moduleEnterprise(user,0).CompetenciaList()
            setListCompetencia(mylistCompetencia)

          setlistOptionAutPgtoTipo(myModule.listOptionAutPgtoTipo)

      } catch (error) {
          alert(`Erro ao carregar dados iniciais: ${error}`);
      } finally {
          setActionStatus(0);
      }
    }
    Binding()
  }, [])

  
  const ListarRegistros = async () => {
    try {
      ScreenClearGrid("Nenhum registro encontrado.")
      setActionStatus(1)
      let ListResultado : tpAutorizacaoPagamento[] = [] 
      SetlistAutorizacaoPagamento(ListResultado);

            if (filterCompentencia?.competencia_cd == 0 && filterdata_Emissao == 0 && filterdata_Vencimento == 0 && filterdata_Pagamento == 0) {
                alert("Favor informar a Competência ou algum filtro de dada (Emissão, Vencimento ou Pagamento)")
                return
            }


            ListResultado = await myModule.financeiroBlueSoftListGet({
            tipovisualizacao: filterTipoVisualizacao,
            autpgto_seq_pk: filterautpgto_seq_pk,
            autpgto_tipo: filterautpgto_tipo,
            r_conta_cd: filterr_conta_cd, 

            filtrar_dataemissao: filterdata_Emissao, 
            autpgto_dataemissao_ini: filterdata_Emissao_ini.toISOString().split('T')[0], 
            autpgto_dataemissao_fim: filterdata_Emissao_fim.toISOString().split('T')[0],

            filtrar_datavencimento: filterdata_Vencimento, 
            autpgto_datavencimento_ini: filterdata_Vencimento_ini.toISOString().split('T')[0], 
            autpgto_datavencimento_fim: filterdata_Vencimento_fim.toISOString().split('T')[0],

            filtrar_datapagamento: filterdata_Pagamento, 
            autpgto_datapagamento_ini: filterdata_Pagamento_ini.toISOString().split('T')[0], 
            autpgto_datapagamento_fim: filterdata_Pagamento_fim.toISOString().split('T')[0],


            cancelado: filtercancelado, 
            filterdespesabluesoft: filterdespesabluesoft,
            competencia_cd: (filterCompentencia)? filterCompentencia.competencia_cd : 0,
            bluesoft_competencia_cd: (filterCompentenciabluesoft)? filterCompentenciabluesoft.competencia_cd : 0
          })
      SetlistAutorizacaoPagamento(ListResultado);
      setActionStatus(0)
    } catch(e) { 
      setActionStatus(0)
      alert(`${e}`);
    }

  }
  const ScreenOpenModal = async (itemModal: tpAutorizacaoPagamento | null, action: string ) => {
      setActionOpenModel(action)

      let myItemModal : tpAutorizacaoPagamento = {autpgto_seq_pk:0}
      if (itemModal)
        myItemModal = itemModal
      
      setModalAutorizacaoPagamentoSelect(myItemModal)
      setIsModalOpen(true);
  };

  const ScreenCloseModal = () => {
    setModalAutorizacaoPagamentoSelect(null);
    setIsModalOpen(false);
  };

  const ScreenClearGrid = (message : string = "Nenhum Registro Encontrado") => {
    SetlistAutorizacaoPagamento([]);
    setresultMessage(message)
  }

  return (
  <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Financeiro Bluesoft | Consultar Auxiliar" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={ListarRegistros} ></ButtonPag>
          </div>              
        </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
          <h2 className="text-xl font-semibold text-gray-700 mb-4">Filtros</h2>
          
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-y-5 gap-x-5">
            {/* Filtro por Tipo de Visualização */}
            <div>
              <label className="block text-sm font-medium text-red-600 mb-1">Tipo de Visualização</label>
              <select 
                className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 max-w-xs"
                value={filterTipoVisualizacao}
                onChange={(e) => { 
                  ScreenClearGrid("-")
                  setfilterTipoVisualizacao(e.target.value)
                }
              }
              >
                <option value="DP">Por Duplicata</option>
                <option value="CP">Por Comp. Pag</option>
                <option value="CB">Por Comp. Blue</option>
                <option value="CD">Por Comp. Pag / Dt Venc</option>
              </select>
            </div>  
            {/* Número da Duplicata */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Número da Duplicata</label>
                  <input
                    type="number"
                    className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 max-w-xs"  
                    value={filterautpgto_seq_pk}
                    onChange={(e) => {
                      const value = e.target.value;
                      setfilterautpgto_seq_pk(value ? parseInt(value) : 0);
                    }}
                    ></input>
            </div>

            {/* Filtro por Conta */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Conta de Lançamento</label>
                    <select 
                      className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 max-w-xs"
                      value={filterr_conta_cd}
                      onChange={(e) => {
                        const selectValue = e.target.value
                        setfilterr_conta_cd(parseInt(e.target.value))
                      }}      
                    >
                      <option key={0} value = {0} >* Todas as Contas *</option>
                      {ListResultadoConta.map((item) => (
                        <option key={item.r_conta_cd} value={item.r_conta_cd} >
                          {item.r_conta_descricao}
                        </option>
                      ))}
                    </select>
            </div>
            {/* Filtro por Competência */}

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Competência</label>
              <select 
                className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 max-w-30"
                value={filterCompentencia ? filterCompentencia.competencia_cd : ""}
                onChange={(e) => {
                  const selectedValue = e.target.value;
                  const selectedCompetencia = ListCompetencia.find(c => c.competencia_cd === parseInt(selectedValue)) || null;
                  setfilterCompetencia(selectedCompetencia);
                }}
              >
                <option key={0} value="">* Todas as Competências *</option>
                {ListCompetencia.map((item) => (
                  <option key={item.competencia_cd} value={item.competencia_cd}>
                    {item.competencia_descricao}
                  </option>
                ))}
              </select>
            </div>

            {/* Competência BLUESOFT */}

            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Competência BlueSoft</label>
              <select 
                className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 max-w-30"
                value={filterCompentenciabluesoft ? filterCompentenciabluesoft.competencia_cd : ""}
                onChange={(e) => {
                  const selectedValue = e.target.value;
                  const selectedCompetencia = ListCompetencia.find(c => c.competencia_cd === parseInt(selectedValue)) || null;
                  setfilterCompetenciabluesoft(selectedCompetencia);
                }}
              >
                <option key={0} value="">* Todas as Competências *</option>
                {ListCompetencia.map((item) => (
                  <option key={item.competencia_cd} value={item.competencia_cd}>
                    {item.competencia_descricao}
                  </option>
                ))}
              </select>
            </div>


            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Tipo</label>
              <select 
                className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 max-w-xs"
                value={filterautpgto_tipo ? filterautpgto_tipo : ""}
                onChange={(e) => {
                  const selectedValue = e.target.value;
                  setfilterautpgto_tipo(selectedValue);
                }}
              >
                {listOptionAutPgtoTipo.map((item: tpAutorizacaoPagamentoTipo) => (
                  <option key={item.autpgto_tipo} value={item.autpgto_tipo}>
                    {item.autpgto_tipo_descricao}
                  </option>
                ))}
              </select>
            </div>

 
            {/* Filtro por Registros Cancelados */}
            <div>
              <div className="flex items-center mb-1">
                <label className="block text-sm font-medium text-gray-700 mr-2">Registros Cancelados</label>
                <input
                  type="checkbox"
                  className="h-4 w-4 text-purple-500 focus:ring-purple-500 border-gray-300 rounded"
                  onChange={(e) => setfiltercancelado(e.target.checked ? 1 : 0)}
                />
              </div>
              <div className="text-xs text-gray-500 mt-1">
                {filtercancelado === 1 ? "Listar todos os registros" : "Apenas Registros válidos"}
              </div>
            </div>       
            {/* Filtrar apenas despesas bluesoft */}
            <div>
              <div className="flex items-center mb-1">
                <label className="block text-sm font-medium text-gray-700 mr-2">Apenas Pagamento de Despesas Bluesoft</label>
                <input
                  type="checkbox"
                  className="h-4 w-4 text-purple-500 focus:ring-purple-500 border-gray-300 rounded"
                  onChange={(e) => setfilterdespesabluesoft(e.target.checked ? 1 : 0)}
                />
              </div>
              <div className="text-xs text-gray-500 mt-1">
                {filterdespesabluesoft === 1 ? "Despesas Bluesoft (sem fornecedores)" : "Todos tipos de contas contábeis"}
              </div>
            </div>                

            {/* Filtro por Data */}
            <div className="min-w-[300px]">
              <div className="flex items-center mb-1"> {/* Container do label + checkbox */}
                <label className="block text-sm font-medium text-gray-700 mr-2">Emissão</label>
                <input
                  type="checkbox"
                  className="h-4 w-4 text-purple-500 focus:ring-purple-500 border-gray-300 rounded"
                  onChange={(e) => setfilterdata_Emissao(e.target.checked ? 1 : 0)} // "1" se marcado, "0" se não
                />
              </div>
              <div className="grid grid-cols-2 gap-2 w-full">
                <input
                  type="date"
                  disabled = {filterdata_Emissao == 0}
                  className={InputDateClassName}
                  value={user.dateToInputFormat(filterdata_Emissao_ini)}
                  onChange={(e) => setfilterdata_Emissao_ini(user.stringToDate(e.target.value))}
                  placeholder="Data inicial"
                />
                <input
                  type="date"
                  disabled = {filterdata_Emissao == 0}
                  className={InputDateClassName}
                  value={user.dateToInputFormat(filterdata_Emissao_fim)}
                  onChange={(e) => setfilterdata_Emissao_fim(user.stringToDate(e.target.value))}
                  placeholder="Data final"
                />
              </div>
            </div>

            {/* Filtro por Data */}
            <div className="min-w-[300px]">
              <div className="flex items-center mb-1"> {/* Container do label + checkbox */}
                <label className="block text-sm font-medium text-gray-700 mr-2">Vencimento</label>
                <input
                  type="checkbox"
                  className="h-4 w-4 text-purple-500 focus:ring-purple-500 border-gray-300 rounded"
                  onChange={(e) => setfilterdata_Vencimento(e.target.checked ? 1 : 0)} // "1" se marcado, "0" se não
                />
              </div>
              <div className="grid grid-cols-2 gap-2 w-full">
                <input
                  type="date"
                  disabled = {filterdata_Vencimento == 0}
                  className={InputDateClassName}
                  value={user.dateToInputFormat(filterdata_Vencimento_ini)}
                  onChange={(e) => setfilterdata_Vencimento_ini(user.stringToDate(e.target.value))}
                  placeholder="Data inicial"
                />
                <input
                  type="date"
                  disabled = {filterdata_Vencimento == 0}
                  className={InputDateClassName}
                  value={user.dateToInputFormat(filterdata_Vencimento_fim)}
                  onChange={(e) => setfilterdata_Vencimento_fim(user.stringToDate(e.target.value))}
                  placeholder="Data final"
                />
              </div>
            </div>
            
            <div className="min-w-[300px]">
              <div className="flex items-center mb-1"> {/* Container do label + checkbox */}
                <label className="block text-sm font-medium text-gray-700 mr-2">Pagamento</label>
                <input
                  type="checkbox"
                  className="h-4 w-4 text-purple-500 focus:ring-purple-500 border-gray-300 rounded"
                  onChange={(e) => setfilterdata_Pagamento(e.target.checked ? 1 : 0)} // "1" se marcado, "0" se não
                />
              </div>
              <div className="grid grid-cols-2 gap-2 w-full">
                <input
                  type="date"
                  disabled = {filterdata_Pagamento == 0}
                  className={InputDateClassName}
                  value={user.dateToInputFormat(filterdata_Pagamento_ini)}
                  onChange={(e) => setfilterdata_Pagamento_ini(user.stringToDate(e.target.value))}
                  placeholder="Data inicial"
                />
                <input
                  type="date"
                  disabled = {filterdata_Pagamento == 0}
                  className={InputDateClassName}
                  value={user.dateToInputFormat(filterdata_Pagamento_fim)}
                  onChange={(e) => setfilterdata_Pagamento_fim(user.stringToDate(e.target.value))}
                  placeholder="Data final"
                />
              </div>
            </div>
          </div>
        </div>

      {/* Grid List */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                  {filterTipoVisualizacao == "DP" ? <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Ações</th> : ""}
                  {filterTipoVisualizacao == "DP" ? <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">N.</th> : ""}
                  {filterTipoVisualizacao == "DP" ? <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Cta Pag</th> : ""}
                  {filterTipoVisualizacao == "DP" || filterTipoVisualizacao == "CP" || filterTipoVisualizacao == "CD" ? <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Comp.</th> : ""}
                  {filterTipoVisualizacao == "DP" || filterTipoVisualizacao == "CB" ? <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Comp. Blue</th> : ""}
                  
                  {filterTipoVisualizacao == "CD" ? <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Comp. Venc</th> : ""}

                  {filterTipoVisualizacao == "DP" ? <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Sacado/Beneficiário</th> : ""}
                  {filterTipoVisualizacao == "DP" ? <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Emissão</th> : ""}
                  {filterTipoVisualizacao == "DP" ? <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vencimento</th> : ""}
                  {filterTipoVisualizacao == "DP" ? <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Pagamento</th> : ""}
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vl Nominal</th> 
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vl Desc.</th> 
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vl Abatimento</th> 
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vl Juros.</th> 
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vl Pago</th> 

                  {filtercancelado === 1 ? <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Cancelado</th> : ""}
                  


                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {listAutorizacaoPagamento.length > 0 ? (
                  listAutorizacaoPagamento.map((item) => (
                    <tr key={item.autpgto_seq_pk} className="hover:bg-gray-50">
                      {filterTipoVisualizacao == "DP" ?
                      <td className="px-3 py-4 whitespace-nowrap text-xs text-gray-700 text-right">
                      <ButtonPag TypeButton="_BUTTON_ICON" label="" TypeIcon="_SELECT" title="Consultar Registro" 
                          onClick={() => ScreenOpenModal(item, "_SELECT")} >
                      </ButtonPag>

                      </td>: ""}
                      {filterTipoVisualizacao == "DP" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.autpgto_seq_pk} </td> : ""}
                      {filterTipoVisualizacao == "DP" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.r_conta_descricao} </td> : ""}
                      {filterTipoVisualizacao == "DP" || filterTipoVisualizacao == "CP" || filterTipoVisualizacao == "CD" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.competencia_descricao} </td>  : ""}
                      {filterTipoVisualizacao == "DP" || filterTipoVisualizacao == "CB" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.competencia_bluesoft_descricao} </td> : ""} 
                      {filterTipoVisualizacao == "CD" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.competencia_vencimento_descricao} </td> : ""} 
                      {filterTipoVisualizacao == "DP" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.nome_razao} </td>  : ""}
                      {filterTipoVisualizacao == "DP" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.autpgto_dataemissao ? new Date(item.autpgto_dataemissao).toLocaleDateString('pt-BR') : 'Data inválida'}</td> : ""}
                      {filterTipoVisualizacao == "DP" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.autpgto_datavencimento ? new Date(item.autpgto_datavencimento).toLocaleDateString('pt-BR') : 'Data inválida'}</td> : ""}
                      {filterTipoVisualizacao == "DP" ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.autpgto_datapagamento ? new Date(item.autpgto_datapagamento).toLocaleDateString('pt-BR') : 'Data inválida'}</td> : ""}      
                      
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">
                          { Number(item.autpgto_valorfatura).toLocaleString('pt-BR',{minimumFractionDigits: 2,maximumFractionDigits: 2})}
                      </td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">
                          { Number(item.autpgto_valordescontofinanceiro).toLocaleString('pt-BR',{minimumFractionDigits: 2,maximumFractionDigits: 2})}
                      </td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">
                          { Number(item.autpgto_valor_abatimento).toLocaleString('pt-BR',{minimumFractionDigits: 2,maximumFractionDigits: 2})}
                      </td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">
                          { Number(item.autpgto_valor_juros).toLocaleString('pt-BR',{minimumFractionDigits: 2,maximumFractionDigits: 2})}
                      </td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">
                          { Number(item.autpgto_valorpago).toLocaleString('pt-BR',{minimumFractionDigits: 2,maximumFractionDigits: 2})}
                      </td>                                                                  
                      {filterTipoVisualizacao == "DP" && filtercancelado === 1 ? <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {(item.autpgto_status_cd === 2)? "Sim": "Não"} </td> : ""}


                      
                  </tr>

                  
                  ))
                ) : (
                  <tr>
                    <td colSpan={6} className="px-6 py-4 text-center text-sm text-gray-500">
                      {resultMessage}
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
            
          </div>
          <div className="px-6 py-4 text-left text-sm text-gray-500">Total de Registros {listAutorizacaoPagamento.length}</div>
        </div>


        {isModalOpen && ModalAutorizacaoPagamentoSelect && (
          <ModalAutorizacaoPgto 
            autpgto_seq_pk ={ModalAutorizacaoPagamentoSelect.autpgto_seq_pk} 
            action = {actionOpenModel}
            onClose={ScreenCloseModal} />
        )}

      </div>
    </div>
  );
}