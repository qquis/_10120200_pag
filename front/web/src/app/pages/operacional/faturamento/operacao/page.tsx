'use client'
    const __SIS_AC_CD : number = 3090 
    
import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";

import ButtonPag from "@/app/components/Buttons/button";
import CmbOperacao from '@/app/pages/cadastro/_components/CmbOperacao/page';
import { moduleFaturamento } from '@/api/m0070_faturamento/moduleFaturamento';
import {moduleforcavendameta} from '@/api/m0005_forcaVendaMeta/moduleforcavendameta';
const listCompeencia = [
    {competencia_cd: 202610, descricao : 'Outubro/2026'},
    {competencia_cd: 202611, descricao : 'Novembro/2026'}
]


let myModule: moduleFaturamento;
let myModuleForcaVendaMeta: moduleforcavendameta;

export default function FaturamentoOperacao() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [DataFaturamentoIni, setDataFaturamentoIni] = useState<string>('');
    const [DataFaturamentoFim, setDataFaturamentoFim] = useState<string>('');
    
    const [op_cdoperacaoFilter, setOp_CdOperacaoFilter] = useState('');
    const [gridData, setGridData] = useState<any[]>([]);

    const [DataFaturamentoProcessamento, setDataFaturamentoProcessamento] = useState<string>('');
    const [competencia_meta_cd, setCompetencia_meta_cd] = useState<number>(0);

    useEffect(() => {
            const hoje = new Date();
            myModule = new moduleFaturamento(user, __SIS_AC_CD);
            myModuleForcaVendaMeta = new moduleforcavendameta(user, __SIS_AC_CD);

            setDataFaturamentoIni(new Date(hoje.getFullYear(), hoje.getMonth(), hoje.getDate() - 1).toISOString().split('T')[0]);

            setDataFaturamentoIni(user.dateToInputFormat(hoje));
            setDataFaturamentoFim(user.dateToInputFormat(hoje));
            setDataFaturamentoProcessamento(user.dateToInputFormat(hoje));
    }, []);


    const parametroGet = () => { 
        return {
            op_cdoperacao: op_cdoperacaoFilter,
            dataFaturamento_filter: 1,
            dataFaturamento_ini: DataFaturamentoIni,
            dataFaturamento_fim: DataFaturamentoFim,
            statusfaturamentoFiltrar: 0,
            statusfaturamento: 0,
            data_processamento: DataFaturamentoProcessamento,
        }
    }

    const ConsultarOperacaoConferencia = async () => {
        try {
            setActionStatus(1);
            setGridData([]);    
            const response = await myModule.getFaturamentoOperacaoConferencia(parametroGet());
            setGridData(response);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao consultar serviços:', error);
            setActionStatus(0);
        }
    };

    const ProcessarVendasBluesoft = async () => {
        try {
            setActionStatus(1);

            const response = await myModule.postProcessarVendasBluesoft(parametroGet());


            setGridData(response);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao processar vendas Bluesoft:', error);
            setActionStatus(0);
        }
    };

    const ProcessarMeta = async () => {
        try {
            setActionStatus(1);

            const response = await myModuleForcaVendaMeta.postProcessarMeta({competencia_cd: competencia_meta_cd});

            setGridData(response);
            setActionStatus(0);
        } catch (error) {
            console.error('Erro ao processar meta:', error);
            setActionStatus(0);
        }
    };

    const clearData = () => {
        setGridData([]);
    }



 
    return (

        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Faturamento Prime | Operações">
                    <div className="flex space-x-2">
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Pesquisar" 
                            TypeIcon="_PESQUISAR" 
                            title="Pesquisar Serviços" 
                            onClick={() => { 
                                clearData();
                                ConsultarOperacaoConferencia() 
                            }} 
                        />

                    </div>
                </HeaderMain>

                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
    <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        <div className="flex flex-col">
            <label className="text-sm font-medium text-gray-700 mb-1">
                Operação
            </label>
            <CmbOperacao
                user={user}
                onChange={(value) => setOp_CdOperacaoFilter(value)}
                value={op_cdoperacaoFilter}
                sis_ac_cd={__SIS_AC_CD}
            />
        </div>

        <div className="flex flex-col">
            <label htmlFor="dataInicial" className="text-sm font-medium text-gray-700 mb-1">
                Data Inicial
            </label>
            <input
                id="dataInicial"
                name="dataInicial"
                type="date"
                value={DataFaturamentoIni}
                onChange={(e) => setDataFaturamentoIni(e.target.value)}
                className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
            />
        </div>

        <div className="flex flex-col">
            <label htmlFor="dataFinal" className="text-sm font-medium text-gray-700 mb-1">
                Data Final
            </label>
            <input
                id="dataFinal"
                name="dataFinal"
                type="date"
                value={DataFaturamentoFim}
                onChange={(e) => setDataFaturamentoFim(e.target.value)}
                className="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
            />
        </div>
    </div>
</div>

                <div className="flex flex-col gap-4">
                
                    <div className="flex flex-col gap-4">
 <div className="max-h-[500px] overflow-y-auto">
        <table className="min-w-full divide-y divide-gray-200">
            <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Data Faturamento</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Empresa</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Operação</th>
                    <th className="px-6 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Faturamento Base</th>
                    <th className="px-6 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Subsídios Correntes</th>
                    <th className="px-6 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Faturamento</th>
                    <th className="px-6 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Desconto Financeiro</th>
                    <th className="px-6 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Subsídios Aplicados</th>
                    <th className="px-6 py-3 text-right text-xs font-medium text-purple-700 tracking-wider">Faturamento Líquido</th>
                </tr>
            </thead>
            <tbody className="bg-white divide-y divide-gray-200">
                {gridData.length > 0 ? (
                    gridData.map((item) => (
                        <tr key={item.em_cdempresa + '-' + item.op_cdoperacao} className="hover:bg-gray-50">
                            <td className="px-4 py-2 text-sm text-gray-700">{user.formatDateDDMMYYYY(item.datafaturamento)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700">{item.em_descricao}</td>
                            <td className="px-4 py-2 text-sm text-gray-700">{item.op_descricao} - {item.op_cdoperacao}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.valortotalfaturamentobase, 2, true)}</td>
                            <td className={"px-4 py-2 text-sm text-right " + (Number(item.valortotalsubsidioscorrentes) < 0 ? 'text-red-600 font-medium' : 'text-gray-700')}>
                                {user.formatNumber(item.valortotalsubsidioscorrentes, 2, true)}
                            </td>
                            <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.valortotalfaturamento, 2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.valortotaldescontofinanceiro, 2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 text-right">{user.formatNumber(item.valortotalsubsidiosaplicados, 2, true)}</td>
                            <td className="px-4 py-2 text-sm text-gray-700 text-right font-semibold">{user.formatNumber(item.valortotalfaturamentoliquido, 2, true)}</td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan={9} className="px-6 py-4 text-center text-sm text-gray-500">
                            Nenhum dado encontrado para o período informado.
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    </div>



  <div className="grid grid-cols-1 xl:grid-cols-2 gap-4">
    <section className="flex flex-col gap-5 rounded-xl border border-gray-200 bg-white p-5 shadow-sm">
      <h2 className="border-l-4 border-purple-500 pl-3 text-base font-semibold text-gray-800">
        Atualização Geral da Base Prime de Faturamento
      </h2>

      <div className="flex flex-col gap-4 sm:flex-row sm:items-end">
        <div className="flex min-w-0 flex-1 flex-col">
          <label htmlFor="dataInicial" className="mb-1 text-sm font-medium text-gray-700">
            Data de Processamento
          </label>
          <input
            id="dataInicial"
            name="dataInicial"
            type="date"
            value={DataFaturamentoProcessamento}
            onChange={(e) => setDataFaturamentoProcessamento(e.target.value)}
            className="w-full rounded-md border border-gray-300 px-3 py-2 shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
          />
        </div>

        <button
          type="button"
          className="inline-flex h-10 items-center justify-center gap-2 rounded-md bg-green-600 px-4 text-sm font-medium text-white shadow-sm transition hover:bg-green-700 disabled:cursor-not-allowed disabled:opacity-70"
          title="Atualizar Base Geral de Preços do Força de Venda"
          onClick={ProcessarVendasBluesoft}
          disabled={ActionStatus === 1}
        >
          {ActionStatus === 1 ? (
            <svg className="h-4 w-4 animate-spin" fill="none" viewBox="0 0 24 24">
              <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
              <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
            </svg>
          ) : (
            <svg className="h-4 w-4" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v16m8-8H4" />
            </svg>
          )}
          Processar Vendas Bluesoft
        </button>
      </div>
    </section>

    <section className="flex flex-col gap-5 rounded-xl border border-gray-200 bg-white p-5 shadow-sm">
      <h2 className="border-l-4 border-purple-500 pl-3 text-base font-semibold text-gray-800">
        Atualização Meta Força de Venda
      </h2>

      <div className="flex flex-col gap-4 sm:flex-row sm:items-end">
        <div className="flex min-w-0 flex-1 flex-col">
          <label className="mb-1 text-sm font-medium text-gray-700">
            Competência
          </label>
          <select
            value={competencia_meta_cd || ''}
            onChange={(e) => setCompetencia_meta_cd(Number(e.target.value))}
            className="w-full rounded-md border border-gray-300 bg-white px-3 py-2 shadow-sm focus:outline-none focus:ring-2 focus:ring-green-500"
          >
            <option value="">Selecione a Meta</option>
            {listCompeencia.map((meta) => (
              <option key={meta.competencia_cd} value={meta.competencia_cd}>{meta.descricao}  </option>
            ))}
          </select>
        </div>

        <button
          type="button"
          className="inline-flex h-10 items-center justify-center gap-2 rounded-md bg-green-600 px-4 text-sm font-medium text-white shadow-sm transition hover:bg-green-700 disabled:cursor-not-allowed disabled:opacity-70"
          title="Atualizar Base Geral de Preços do Força de Venda"
          onClick={ProcessarMeta}
          disabled={ActionStatus === 1}
        >
          {ActionStatus === 1 ? (
            <svg className="h-4 w-4 animate-spin" fill="none" viewBox="0 0 24 24">
              <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
              <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
            </svg>
          ) : (
            <svg className="h-4 w-4" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v16m8-8H4" />
            </svg>
          )}
          Processar Vendas Bluesoft
        </button>
      </div>
    </section>
  </div>

</div>
            </div>
        </div>

    </div>
    );
}