'use client'
import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";
import { moduleRh , rh_tipo_contrato, rh_setor_operacional} from "@/api/m0141_rh/moduleRh";
import { re_compentencia } from "@/api/m0002_enterprise/moduleEnterprise";
import HeaderMain from "@/app/components/divs/headerMain";


import dynamic from 'next/dynamic';

const Chart = dynamic(() => import('react-apexcharts'), { ssr: false });

//import Chart from 'react-apexcharts';




type tipo_relatorio = { 
  tipo_relatorio: string 
  descricao_relatorio: string 
}

const tipos_relatorios : tipo_relatorio[] = [
  {tipo_relatorio : "F", descricao_relatorio : "Lista de Funcionário"}, 
  {tipo_relatorio : "C", descricao_relatorio : "Por tipo de Contrato"}, 
  {tipo_relatorio : "S", descricao_relatorio : "Por Setor Operacional"},
  {tipo_relatorio : "P", descricao_relatorio : "Por Competência"},
  {tipo_relatorio : "O", descricao_relatorio : "Por Conta de Resultado Pag"},
] 
  

export default function Rhfolhacontratada() {
  const [TipoContratoList, setTiposDeContrato] = useState<rh_tipo_contrato[]>([]);
  const [SetorOperacionalList, setSetoresOperacionais] = useState<rh_setor_operacional[]>([]);
  const [folhaContratada, setFolhaContratada] = useState<any | null>([]);
  const [listCmbCompetencia, setListCmbCompetencia] = useState<re_compentencia[]>([]);
  const [listCmbColumnOrderby, setListCmbColumnOrderBy] = useState<any[]>([]);
  
  

  
  /* Screen / Action */
  const [ActionStatus, setActionStatus] = useState(0); // Status da ação (ex: "Carregando", "Erro", "Sucesso")
  const [ScreenViewChart, setScreenViewChart] = useState(0); // Exibir gráfico ou tabela

  /*Filtros*/
  const [nomerazaofilter, setnomerazaofilter] = useState('');
  const [tipoRelatorioFilter, settipoRelatorioFilter] = useState("F")
  const [tipoContratoFilter, settipoContratoFilter] = useState("0");
  const [setorOperacionalFilter, setSetorOperacionalFilter] = useState("0");
  const [competencia_cdFilter, setCompetencia_cdFilter] = useState(0);
  const [columnorderbyfilter, setColumnOrderByFilter] = useState(0);
  const [orderbydirectionfilter, setOrderByDirectionFilter] = useState('asc');
  


  const { login, user } = useAuth()
  let myModyleRh : moduleRh = new moduleRh(user);
  

  useEffect(() => { 
    async function tipoContratoBinding() {
      
      //myModyleRh = new moduleRh();
       
      // Atualiza as lists filtes da class
      setActionStatus(1);
      await myModyleRh.bindin() 
       
      if (myModyleRh.TipoContratoList.length > 0) 
          setTiposDeContrato(myModyleRh.TipoContratoList);

      if (myModyleRh.SetorOperacionalList.length > 0)
          setSetoresOperacionais(myModyleRh.SetorOperacionalList);

      if (myModyleRh.orderbycolumns.length > 0)
          setListCmbColumnOrderBy(myModyleRh.orderbycolumns);

      let mylistCmbCompetencia = await myModyleRh.getFolhaCompetencia({});
      if (mylistCmbCompetencia.length > 0)
          setListCmbCompetencia(mylistCmbCompetencia);
      setActionStatus(0);        
    }

    tipoContratoBinding()
  }, [])





  
  const consultarFolhaContratada = async () => {
    try {

      if ((   tipoRelatorioFilter === "F"
          ||  tipoRelatorioFilter === "S"
          ||  tipoRelatorioFilter === "C"
          ||  tipoRelatorioFilter === "O"

      ) && competencia_cdFilter === 0) {
        alert("Para o tipo de relatório por funcionário, Setor, Tipo de Contrato e por conta de Resultado Pag é necessário informar a competência.");
        return;
      }

      setActionStatus(1);
      setFolhaContratada({});
      await myModyleRh.getFolhaPorCompetencia(
          { tipo_relatorio: tipoRelatorioFilter, 
            rh_tipo_contrato_cd: tipoContratoFilter, 
            rh_setor_operacional_cd: setorOperacionalFilter, 
            nome_razao: nomerazaofilter, 
            competencia_cd: competencia_cdFilter, 
            r_conta_cd: 0,
            orderbycolumnnumber: columnorderbyfilter,
            orderbydirection: orderbydirectionfilter
          
          });
      setFolhaContratada(myModyleRh.folhaPorCompetencia);

      if (tipoRelatorioFilter === "C" || tipoRelatorioFilter === "S" || tipoRelatorioFilter === "P" || tipoRelatorioFilter === "O") 
        setScreenViewChart(1); // Exibir gráfico
      else
        setScreenViewChart(0); // Exibir gráfico


      setActionStatus(0); 
    } catch (error) {
      console.error("Erro ao consultar folha contratada:", error);
      setActionStatus(0); // Define o status de erro
    }

  }

  return (
  <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Folha de Pgto Oxan" >

            <div>
              <button onClick={consultarFolhaContratada} className="flex items-center bg-[#8B5CF6] hover:bg-purple-700 text-white font-medium py-1.5 px-4 rounded-full text-sm transition-colors duration-300" >
                
                Pesquisar
                </button>  
            </div>  

        </HeaderMain>
        
        {/* Área de Filtros */}
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
          <h2 className="text-xl font-semibold text-gray-700 mb-4">Filtros</h2>
          
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-4">

            {/* Tipo Relatório  */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Tipo de Visualização</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                value={tipoRelatorioFilter}
                onChange={(e) => settipoRelatorioFilter(e.target.value)}
              >
                {tipos_relatorios.map(item => (
                  <option key={item.tipo_relatorio} value={item.tipo_relatorio}>{item.descricao_relatorio}</option>
                ))}
              </select>
            </div>


            {/* Filtro por Competência */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Competência</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                value={competencia_cdFilter}
                onChange={(e) => setCompetencia_cdFilter(Number(e.target.value))}
              >
                <option value="0">Todas</option>
                {listCmbCompetencia.map(item => (
                  <option key={item.competencia_cd} value={item.competencia_cd}>{item.competencia_descricao}</option>
                ))}
              </select>
            </div>

            {/* Filtro por Descrição */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Nome do Colaborador</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                placeholder="Filtrar por descrição"
                value={nomerazaofilter}
                onChange={(e) => setnomerazaofilter(e.target.value)}
              />
            </div>





            
            {/* Filtro por Tipo de Contrato */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Tipo de Contrato</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                value={tipoContratoFilter}
                onChange={(e) => settipoContratoFilter(e.target.value)}
              >
                <option value="0">Todos</option>
                {TipoContratoList.map(itemTipoContrato => (
                  <option key={itemTipoContrato.rh_tipo_contrato_cd} value={itemTipoContrato.rh_tipo_contrato_cd}>{itemTipoContrato.rh_tipo_contrato_descricao}</option>
                ))}
              </select>
            </div>


            {/* Setor Operacoinal */}
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Setor Operacional</label>
              <select
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                value={setorOperacionalFilter}
                onChange={(e) => setSetorOperacionalFilter(e.target.value)}
              >
                <option value="0">Todos</option>
                {SetorOperacionalList.map(itemTipoContrato => (
                  <option key={itemTipoContrato.rh_setor_operacional_cd} value={itemTipoContrato.rh_setor_operacional_cd}>{itemTipoContrato.rh_setor_operacional_descricao}</option>
                ))}
              </select>
            </div>

            {/* Filtro por Ordem de Coluna */}
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <label className="block text-sm font-medium text-gray-700 mb-1">Ordem de Coluna</label>
                <div className="flex items-center mb-1">
                  <label className="block text-xs font-medium text-gray-700 mr-2">Order Descendente</label>
                  <input
                    type="checkbox"
                    className="h-4 w-4 text-purple-500 focus:ring-purple-500 border-gray-300 rounded"
                    onChange={(e) => setOrderByDirectionFilter(e.target.checked ? 'desc' : 'asc')}
                  />
                </div>
                <div className="col-span-full">
                  <select
                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                    value={columnorderbyfilter}
                    onChange={(e) => setColumnOrderByFilter(Number(e.target.value))}
                  >
                    {listCmbColumnOrderby.map(item => (
                      <option key={item.columnNumber} value={item.columnNumber}>{item.columnName}</option>
                    ))}
                  </select>
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
                  <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Comp.</th>
                  <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Cod</th>
                  <th className="px-2 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Nome</th>
                  <th className="px-2 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Admissão</th>
                  <th className="px-2 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Rescisão</th>
                  <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Contrato</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Setor Op. Pag</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Conta</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Conta Descrição</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Folha</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Pj</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Outros</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Previsão Total</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">N. Func</th>
                  <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Vl Tot Md</th>
                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {folhaContratada.length > 0 ? (
                  folhaContratada.map((itemFolha: any) => (
                    <tr key={itemFolha.funcionario_cd} className="hover:bg-gray-50">
                      <td className="px-3 py-4 whitespace-nowrap text-xs text-gray-700 text-right">{itemFolha.competencia_cd}</td>
                      <td className="px-3 py-4 whitespace-nowrap text-xs text-gray-700 text-right">{itemFolha.rh_funcionario_cd}</td>
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">{itemFolha.nome_razao}</td>
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">{itemFolha.data_admissao ? new Date(itemFolha.data_admissao).toLocaleDateString('pt-BR') : 'Data inválida'}</td>
                      <td className="px-2 py-4 whitespace-nowrap text-xs text-gray-700">{itemFolha.data_rescisao ? new Date(itemFolha.data_rescisao).toLocaleDateString('pt-BR') : 'Data inválida'}</td>
                      <td className="px-1 py-4 whitespace-nowrap text-xs text-gray-700">{itemFolha.rh_tipo_contrato_descricao}</td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700">{itemFolha.rh_setor_operacional_descricao} ({itemFolha.rh_setor_operacional_cd})</td>
                      <td className="px-1 py-4 whitespace-nowrap text-xs text-gray-700">{itemFolha.r_conta_cd}</td>
                      <td className="px-1 py-4 whitespace-nowrap text-xs text-gray-700">{itemFolha.r_conta_descricao}</td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">{Number(itemFolha.rh_vl_salario).toLocaleString('pt-BR', {minimumFractionDigits: 2, maximumFractionDigits: 2 })}</td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">{Number(itemFolha.rh_vl_pj).toLocaleString('pt-BR', {minimumFractionDigits: 2, maximumFractionDigits: 2 })}</td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">{Number(itemFolha.rh_vl_outros).toLocaleString('pt-BR', {minimumFractionDigits: 2, maximumFractionDigits: 2 })}</td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">{Number(itemFolha.calc_rh_vl_total).toLocaleString('pt-BR', {minimumFractionDigits: 2, maximumFractionDigits: 2 })}</td>
                      <td className="px-3 py-4 whitespace-nowrap text-xs text-gray-700 text-right">{itemFolha.calc_numero_funcionarios}</td>
                      <td className="px-4 py-4 whitespace-nowrap text-xs text-gray-700 text-right">{Number(itemFolha.calc_salario_medio).toLocaleString('pt-BR', {minimumFractionDigits: 0, maximumFractionDigits: 0 })}</td>
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
      
        {/* Exibir gráfico se o tipo de contrato for "C" */}
        {ScreenViewChart == 1 && (folhaContratada.length > 0) && (
          <div className="bg-white rounded-lg shadow-md p-6 mt-6 border border-purple-100">
            <h2 className="text-xl font-semibold text-gray-700 mb-4">
              Dados por {
                (tipoRelatorioFilter === "C") ? "Tipo de Contrato" : 
                (tipoRelatorioFilter === "S") ? "Setor Operacional" : 
                (tipoRelatorioFilter === "P") ? "Competência" : "Funcionário"
              }
            </h2>
            <Chart
              options={{
                chart: {
                  id: 'folha-contratada',
                },
                xaxis: {
                  categories: folhaContratada.map((item: any) => (
                    (tipoRelatorioFilter === "C") ? item.rh_tipo_contrato_descricao :
                    (tipoRelatorioFilter === "S") ? item.rh_setor_operacional_descricao :
                    (tipoRelatorioFilter === "P") ? item.competencia_descricao :
                    (tipoRelatorioFilter === "O") ? item.r_conta_descricao :
                    "NA"
                  )),
                },
                stroke: {
                  width: [4, 2],
                },
                yaxis: [
                  {
                    title: {
                      text: 'Total',
                    },
                  },
                  {
                    opposite: true,
                    title: {
                      text: 'Nº Funcionários',
                    },
                  },
                ],
              }}
              series={[
                {
                  name: 'Total',
                  type: 'bar',
                  data: folhaContratada.map((item: any) => item.calc_rh_vl_total),
                },
                {
                  name: 'Nº Funcionários',
                  type: 'line',
                  data: folhaContratada.map((item: any) => item.calc_numero_funcionarios),
                },
              ]}
              type="bar"
              height={350}
            />
          </div>
        )}


      </div>
    </div>
  );
}