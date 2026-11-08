'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";

import ButtonPag from "@/app/components/Buttons/button";

import { moduleInterface } from '@/api/n0071_interface/moduleinterface';



const fmtData = (v: string) => {
    const m = /^(\d{4})-(\d{2})-(\d{2})/.exec(v || "");
    return m ? `${m[3]}/${m[2]}/${m[1]}` : v;
};
const fmtNum = (v: number | string) => Number(v ?? 0).toLocaleString('pt-BR');




const hoje = () => new Date().toISOString().slice(0, 10);
const toYYYYMMDD = (d: string) => {
    const match = /^(\d{4})-?(\d{2})-?(\d{2})$/.exec(d);
    return match ? `${match[1]}-${match[2]}-${match[3]}` : d;
};

let myModule: moduleInterface;

export default function InterfaceProcessamentoConsulta() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [dataIni, setDataIni] = useState<string>(hoje());
    const [dataFim, setDataFim] = useState<string>(hoje());
    const [mensagem, setMensagem] = useState<string>("");
    const [resumo, setResumo] = useState<any[]>([]);
    const [resumoCompetencia, setResumoCompetencia] = useState<any[]>([]);
    const [pesquisou, setPesquisou] = useState<boolean>(false);

    useEffect(() => {
        myModule = new moduleInterface(user, __SIS_AC_CD);
    }, []);

    const validarPeriodo = (): boolean => {
    if (!dataIni || !dataFim) {
        setMensagem("Informe a data inicial e final.");
        return false;
    }

    if (dataIni > dataFim) {
        setMensagem("A data inicial não pode ser maior que a data final.");
        return false;
    }



    return true;
};
    const Pesquisar = async () => {
        setMensagem("");
        if (!dataIni || !dataFim) {
            setMensagem("Informe a data inicial e final.");
            return;
        }
        if (dataIni > dataFim) {
            setMensagem("A data inicial não pode ser maior que a data final.");
            return;
        }
        if (!validarPeriodo()) {
            return;
        }

        try {
            setActionStatus(1);
            const result = await myModule.interfacefaturamentoItem.getInterfaceFaturamentoItem({
                tipo_relatorio: 'RESUMO',
                data_processamento_ini: toYYYYMMDD(dataIni),
                data_processamento_fim: toYYYYMMDD(dataFim),
            });
            const lista = Array.isArray(result) ? result : (result?.data ?? []);
            setResumo(lista);

            
            const resultCompetencia = await myModule.interfacefaturamentoItem.getInterfaceFaturamentoItem({
                tipo_relatorio: 'RESUMO_COMPETENCIA',
                data_processamento_ini: toYYYYMMDD(dataIni),
                data_processamento_fim: toYYYYMMDD(dataFim),
            });
            const listaCompetencia = Array.isArray(resultCompetencia) ? resultCompetencia : (resultCompetencia?.data ?? []);
            setResumoCompetencia(listaCompetencia);



            setPesquisou(true);
        } catch (error) {
            console.error('Erro ao pesquisar resumo:', error);
            setResumo([]);
            setMensagem("Erro ao pesquisar o resumo de vendas.");
        } finally {
            setActionStatus(0);
        }
    };

    const Processar = async () => {
        setMensagem("");
        if (!dataIni || !dataFim) {
            setMensagem("Informe a data inicial e final.");
            return;
        }
        if (dataIni > dataFim) {
            setMensagem("A data inicial não pode ser maior que a data final.");
            return;
        }

        try {
            setActionStatus(1);
            await myModule.interfacefaturamentoItem.postInterfaceFaturamentoProcessar({
                data_processamento_ini: toYYYYMMDD(dataIni),
                data_processamento_fim: toYYYYMMDD(dataFim),
            });
            setMensagem("Processamento concluído com sucesso.");
        } catch (error) {
            console.error('Erro ao processar:', error);
            setMensagem("Erro ao processar o arquivo.");
        } finally {
            setActionStatus(0);
        }
    }




    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain
                    tipo={"_PAGE"}
                    ActionStatus={ActionStatus}
                    header_title="Interface | DIAL"
                >
                    <div className="flex space-x-2">
                        
                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={Pesquisar} ActionStatus={ActionStatus}></ButtonPag>
                    </div>
                </HeaderMain>

                <section className="overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
                    <div className="border-b border-gray-100 px-5 py-4 sm:px-6">
                        <p className="mt-1 text-sm text-gray-500">
                            Escolha o arquivo e o período de processamento.
                        </p>
                    </div>

                    <div className="p-5 sm:p-6">
                        <div className="grid grid-cols-1 gap-5 md:grid-cols-3">
                         

                            <div className="min-w-0">
                                <label htmlFor="dataIni" className="mb-1.5 block text-sm font-medium text-gray-700">
                                    Data inicial
                                </label>
                                <input
                                    id="dataIni"
                                    type="date"
                                    value={dataIni}
                                    disabled={ActionStatus === 1}
                                    onChange={(e) => setDataIni(e.target.value)}
                                    className="block w-full rounded-md border border-gray-300 px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
                                />
                            </div>

                            <div className="min-w-0">
                                <label htmlFor="dataFim" className="mb-1.5 block text-sm font-medium text-gray-700">
                                    Data final
                                </label>
                                <input
                                    id="dataFim"
                                    type="date"
                                    value={dataFim}
                                    disabled={ActionStatus === 1}
                                    onChange={(e) => setDataFim(e.target.value)}
                                    className="block w-full rounded-md border border-gray-300 px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
                                />
                            </div>
                        </div>

                        {mensagem && (
                            <p className="mt-4 text-sm text-gray-600">{mensagem}</p>
                        )}

                       
                    </div>
                </section>                

                <section className="mt-4 overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
                    <div className="border-b border-gray-100 px-5 py-4 sm:px-6">
                        <h2 className="text-base font-semibold text-gray-800">
                            Resumo
                        </h2>
                    </div>

                    <div className="overflow-x-auto">
                        <table className="min-w-full divide-y divide-gray-200 text-sm">
                            <thead className="bg-gray-50 text-left text-xs font-semibold uppercase text-gray-600">
                                <tr>
                                    <th className="px-4 py-3" rowSpan={2}>Seq. interface</th>
                                    <th className="px-4 py-3 text-right" rowSpan={2}>Qtde</th>
                                    <th className="px-4 py-3 text-right" rowSpan={2}>Qtde CMP</th>
                                    <th className="px-4 py-3 text-center bg-slate-400" colSpan={2}>Dial Base</th>
                                    <th className="px-4 py-3 text-center bg-red-400" colSpan={2}>Agendamento</th>
                                </tr>
                                <tr>
                                    <th className="px-4 py-3 text-right">Clientes</th>
                                    <th className="px-4 py-3 text-right">Original</th>
                                    <th className="px-4 py-3 text-right">Clientes</th>
                                    <th className="px-4 py-3 text-right">Volume</th>
                                </tr>
                            </thead>
                            <tbody className="divide-y divide-gray-100 text-gray-800">
                                {resumo.map((r) => (
                                    <tr
                                        key={`${r.seqinterface}-${r.datafaturamento}`}
                                        className="hover:bg-gray-50"
                                    >
                                        <td className="px-4 py-2">{r.seqinterface}</td>
                                        <td className="px-4 py-2 text-right">
                                            {user.formatNumber(r.embalagemestoqueqtde, 0)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {user.formatNumber(r.embalagemcompraqtde, 1)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {fmtNum(r.cdparticipantecliente)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {fmtNum(r.cdparticipantecliente_original)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {user.formatNumber(r.simulado_cdparticipantecliente, 0)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {user.formatNumber(r.simulado_embalagemcompraqtde, 1)}
                                        </td>
                                    </tr>
                                ))}
                                {resumo.length === 0 && (
                                    <tr>
                                        <td colSpan={7} className="px-4 py-6 text-center text-gray-500">
                                            {pesquisou
                                                ? "Nenhum registro encontrado."
                                                : "Clique em Pesquisar para exibir o resumo."}
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>


                    <div className="overflow-x-auto">
                        <table className="min-w-full divide-y divide-gray-200 text-sm">
                            <thead className="bg-gray-50 text-left text-xs font-semibold uppercase text-gray-600">
                                <tr>
                                    <th className="px-4 py-3" rowSpan={2}>Seq. interface</th>
                                    <th className="px-4 py-3" rowSpan={2}>Competência</th>
                                    <th className="px-4 py-3 text-right" rowSpan={2}>Qtde</th>
                                    <th className="px-4 py-3 text-right" rowSpan={2}>Qtde CMP</th>
                                    <th className="px-4 py-3 text-center" colSpan={2}>Dial Base</th>
                                    <th className="px-4 py-3 text-center" colSpan={2}>Agendamento</th>
                                </tr>
                                <tr>
                                    <th className="px-4 py-3 text-right">Clientes</th>
                                    <th className="px-4 py-3 text-right">Original</th>
                                    <th className="px-4 py-3 text-right">Clientes</th>
                                    <th className="px-4 py-3 text-right">Volume</th>
                                </tr>
                            </thead>
                            <tbody className="divide-y divide-gray-100 text-gray-800">
                                {resumoCompetencia.map((r) => (
                                    <tr
                                        key={`${r.seqinterface}-${r.datafaturamento}`}
                                        className="hover:bg-gray-50"
                                    >
                                        <td className="px-4 py-2">{r.seqinterface}</td>
                                        <td className="px-4 py-2 text-right">
                                            {r.competencia_descricao}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {user.formatNumber(r.embalagemestoqueqtde, 0)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {user.formatNumber(r.embalagemcompraqtde, 1)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {fmtNum(r.cdparticipantecliente)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {fmtNum(r.cdparticipantecliente_original)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {user.formatNumber(r.simulado_cdparticipantecliente, 0)}
                                        </td>
                                        <td className="px-4 py-2 text-right">
                                            {user.formatNumber(r.simulado_embalagemcompraqtde, 1)}
                                        </td>
                                    </tr>
                                ))}
                                {resumo.length === 0 && (
                                    <tr>
                                        <td colSpan={7} className="px-4 py-6 text-center text-gray-500">
                                            {pesquisou
                                                ? "Nenhum registro encontrado."
                                                : "Clique em Pesquisar para exibir o resumo."}
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>                    
                </section>



            </div>
        </div>
    );
}
