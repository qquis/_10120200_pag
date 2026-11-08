'use client'
import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";
import { usePersistedState } from "@/app/hooks/usePersistedState";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";


/*Modulos API*/
import { moduleFinanceiro, tpAutorizacaoPagamentoPag} from "@/api/m0080_financeiro/modulefinanceiro";
import { moduleResultado, re_conta } from "@/api/m0100_resultado/moduleResultado";
import { moduleEnterprise, re_compentencia } from "@/api/m0002_enterprise/moduleEnterprise";

/*Modals*/
import ModalFinanceiroPagItem from "./ModalAutorizacaoPgtoPag";


export default function FinanceiroPag() {
  
  const { user } = useAuth()
  
  let myModule : moduleFinanceiro = new moduleFinanceiro(user);
  let myModuleResultado : moduleResultado = new moduleResultado()


    // Estados que serão persistidos entre navegações de guias
  const [ActionStatus, setActionStatus] = usePersistedState('ActionStatus', 0);
  const [isModalOpen, setIsModalOpen] = usePersistedState('isModalOpen', false);
  const [actionOpenModel, setActionOpenModel] = usePersistedState('actionOpenModel', "_SELECT");
  
  // Filtros persistidos
  const [filterdata, setfilterdata] = usePersistedState('filterdata', 0);
  const [filterdata_ini, setfilterdata_ini] = usePersistedState('filterdata_ini', new Date());
  const [filterdata_fim, setfilterdata_fim] = usePersistedState('filterdata_fim', new Date());
  const [filterr_conta_cd, setfilterr_conta_cd] = usePersistedState('filterr_conta_cd', 0);
  const [filtercancelado, setfiltercancelado] = usePersistedState('filtercancelado', 0);
  const [filterCompentencia, setfilterCompetencia] = usePersistedState<re_compentencia | null>('filterCompentencia', null);

  // Listas persistidas
  const [ListResultadoConta, setListResultadoConta] = usePersistedState<re_conta[]>('ListResultadoConta', []);
  const [ListCompetencia, setListCompetencia] = usePersistedState<re_compentencia[]>('ListCompetencia', []);

  // Lista principal persistida
  const [listAutorizacaoPagamento, SetlistAutorizacaoPagamento] = usePersistedState<tpAutorizacaoPagamentoPag[]>('listAutorizacaoPagamento', []);

  // Item modal persistido
  const [itemModalAutorizacaoPagamentoSelect, setModalAutorizacaoPagamentoSelect] = usePersistedState<tpAutorizacaoPagamentoPag | null>('itemModalAutorizacaoPagamentoSelect', null);

  /*------------------------------------------------------------------------*/


  useEffect(() => { 
    async function Binding() {
      // Preenchendo combobox de conta ____________________________
      let myListResultadoConta : re_conta[] = await myModuleResultado.getListConta({r_conta_lancamento_manual:1, orderbycolunm:"r_conta_descricao"})
        setListResultadoConta(myListResultadoConta)

      let mylistCompetencia : re_compentencia[] = await new moduleEnterprise(user,0).CompetenciaList()
        setListCompetencia(mylistCompetencia)

    }
    Binding()
  }, [])

  
  const ListarRegistros = async () => {
    try {
      setActionStatus(1)
      let ListResultado : tpAutorizacaoPagamentoPag[] = [] 
      SetlistAutorizacaoPagamento(ListResultado);
          ListResultado = await myModule.financeiroPagListGet({
            r_conta_cd: filterr_conta_cd, 
            filtrar_data_pgto: filterdata, 
            data_pgto_ini: filterdata_ini, 
            data_pgto_fim: filterdata_fim,
            cancelado: filtercancelado, 
            competencia_cd: (filterCompentencia)? filterCompentencia.competencia_cd : 0
          })
      SetlistAutorizacaoPagamento(ListResultado);
      setActionStatus(0)
    } catch(e) { 
      setActionStatus(0)
    }

  }
  const ScreenOpenModal = async (itemModal: tpAutorizacaoPagamentoPag | null, action: string ) => {
      setActionOpenModel(action)

      let myItemModal : tpAutorizacaoPagamentoPag = await myModule.modulelancamentoPag.new()
      if (itemModal)
        myItemModal = itemModal

      setModalAutorizacaoPagamentoSelect(myItemModal)
      setIsModalOpen(true);
  };

  /*------------------------------------------------------------------------*/  
  
  const ScreenCloseModal = () => {
    setModalAutorizacaoPagamentoSelect(null);
    setIsModalOpen(false);
  };

  return (
  <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Financeiro Operacional (PAG) | Consultar" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={ListarRegistros} ></ButtonPag>
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Novo" TypeIcon="_NEW" title="Novo Lançamento" onClick={() => ScreenOpenModal(null, "_NEW")} ></ButtonPag>
          </div>              
        </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
          <h2 className="text-xl font-semibold text-gray-700 mb-4">Filtros</h2>
          
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-1 ">



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
                className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 max-w-xs"
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



            {/* Filtro por Data */}
            <div>
              <div className="flex items-center mb-1"> {/* Container do label + checkbox */}
                <label className="block text-sm font-medium text-gray-700 mr-2">Período de Pagamento</label>
                <input
                  type="checkbox"
                  className="h-4 w-4 text-purple-500 focus:ring-purple-500 border-gray-300 rounded"
                  onChange={(e) => setfilterdata(e.target.checked ? 1 : 0)} // "1" se marcado, "0" se não
                />
              </div>
              <div className="flex gap-4">
                <input
                  type="date"
                  disabled = {filterdata == 0}
                  className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                  value={user.dateToInputFormat(filterdata_ini)}
                  onChange={(e) => setfilterdata_ini(user.stringToDate(e.target.value))}
                  placeholder="Data inicial"

                />
                <input
                  type="date"
                  disabled = {filterdata == 0}
                  className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black disabled:bg-gray-200 disabled:text-gray-500 disabled:cursor-not-allowed disabled:border-gray-200"
                  value={user.dateToInputFormat(filterdata_fim)}
                  onChange={(e) => setfilterdata_fim(user.stringToDate(e.target.value))}
                  placeholder="Data final"
                />
              </div>
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
          </div>
        </div>

      {/* Grid List */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                  <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Registro</th>
                  <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Conta de Fechamento</th>
                  <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Competência</th>
                  <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descrição Resumida</th>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Lançamento</th>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Pagamento</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Valor</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Cancelado</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Ações</th>
                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {listAutorizacaoPagamento.length > 0 ? (
                  listAutorizacaoPagamento.map((item) => (
                    <tr key={item.aut_pgto_pag_seq} className="hover:bg-gray-50">
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.aut_pgto_pag_seq} </td>
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.r_conta_descricao} </td>
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.competencia_descricao} </td> 
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.aut_pgto_pag_obs} </td>  
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.aut_pgto_pag_data ? new Date(item.aut_pgto_pag_data).toLocaleDateString('pt-BR') : 'Data inválida'}</td>    
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {item.aut_pgto_pag_data ? new Date(item.aut_pgto_pag_data_pgto).toLocaleDateString('pt-BR') : 'Data inválida'}</td>    
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">
                          { Number(item.aut_pgto_pag_valor).toLocaleString('pt-BR',{minimumFractionDigits: 2,maximumFractionDigits: 2})}
                      </td>
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">  {(item.aut_pgto_pag_cancelado === 1)? "Sim": "Não"} </td>
                      <td className="px-3 py-4 whitespace-nowrap text-xs text-gray-700 text-right">
                      <ButtonPag TypeButton="_BUTTON_ICON" label="" TypeIcon="_SELECT" title="Consultar Registro" onClick={() => ScreenOpenModal(item, "_SELECT")} ></ButtonPag>
                        {(item.aut_pgto_pag_cancelado === 0) && (
                      <ButtonPag TypeButton="_BUTTON_ICON" label="" TypeIcon="_EDIT" title="Editar" onClick={() => ScreenOpenModal(item, "_EDIT")} ></ButtonPag>)}
                      </td>
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

        {isModalOpen && itemModalAutorizacaoPagamentoSelect && (
          <ModalFinanceiroPagItem 
            aut_pgto_pag_seq ={itemModalAutorizacaoPagamentoSelect.aut_pgto_pag_seq} 
            action = {actionOpenModel}
            onClose={ScreenCloseModal} 
            tipo_lancamento={1}
            />
        )}

      </div>
    </div>
  );
}