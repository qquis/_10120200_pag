'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";

import ButtonPag from "@/app/components/Buttons/button";

import { moduleInterface } from '@/api/n0071_interface/moduleinterface';

type resumoData = {
    seqinterface: number;
    datafaturamento: string;
    embalagemestoqueqtde: number | string;
    embalagemcompraqtde: number | string;
    cdparticipantecliente: number | string;
}

const fmtData = (v: string) => {
    const m = /^(\d{4})-(\d{2})-(\d{2})/.exec(v || "");
    return m ? `${m[3]}/${m[2]}/${m[1]}` : v;
};
const fmtNum = (v: number | string) => Number(v ?? 0).toLocaleString('pt-BR');

type tipoArquivo = {
    tipo: string;
    descricao: string;
    arquivo: string;
}

const ARQUIVOS: tipoArquivo[] = [
    { tipo: "all", descricao: "TODOS", arquivo: "" },
    { tipo: "sales", descricao: "Venda (Sales)", arquivo: "VENDA_JOHNSON" },
    { tipo: "stock", descricao: "Estoque (Stock)", arquivo: "ESTOQUE_JOHNSON" },
    { tipo: "client", descricao: "Cliente (Client)", arquivo: "CLIENTE_JOHNSON" },
];

const hoje = () => new Date().toISOString().slice(0, 10);
const toYYYYMMDD = (d: string) => d.replace(/-/g, '');

let myModule: moduleInterface;

export default function InterfaceDial() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [SelectedArquivo, setSelectedArquivo] = useState<string>("all");
    const [dataIni, setDataIni] = useState<string>(hoje());
    const [dataFim, setDataFim] = useState<string>(hoje());
    const [mensagem, setMensagem] = useState<string>("");
    const [resumo, setResumo] = useState<resumoData[]>([]);
    const [pesquisou, setPesquisou] = useState<boolean>(false);

    useEffect(() => {
        myModule = new moduleInterface(user, __SIS_AC_CD);
    }, []);

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

        try {
            setActionStatus(1);
            const result = await myModule.interfacefaturamentoItem.getInterfaceFaturamentoItem({
                tipo_relatorio: 'RESUMO_DATA',
                data_processamento_ini: toYYYYMMDD(dataIni),
                data_processamento_fim: toYYYYMMDD(dataFim),
            });
            const lista = Array.isArray(result) ? result : (result?.data ?? []);
            setResumo(lista);
            setPesquisou(true);
        } catch (error) {
            console.error('Erro ao pesquisar resumo:', error);
            setResumo([]);
            setMensagem("Erro ao pesquisar o resumo de vendas.");
        } finally {
            setActionStatus(0);
        }
    };



    const GerarArquivo = async () => {
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

            await myModule.dial.downloadfiles({
                tipo: SelectedArquivo,
                data_processamento_ini: toYYYYMMDD(dataIni),
                data_processamento_fim: toYYYYMMDD(dataFim),
            });
        } catch (error) {
            console.error('Erro ao gerar arquivo:', error);
            setMensagem("Erro ao gerar o arquivo.");
        } finally {
            setActionStatus(0);
        }
    };

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain
                    tipo={"_PAGE"}
                    ActionStatus={ActionStatus}
                    header_title="Interface | DIAL"
                >
                    <div className="flex space-x-2">
                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={Pesquisar} ></ButtonPag>
                    </div>
                </HeaderMain>

                <section className="mt-4 overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
                    <div className="border-b border-gray-100 px-5 py-4 sm:px-6">
                        <h2 className="text-base font-semibold text-gray-800">
                            Resumo de vendas por data
                        </h2>
                        <p className="mt-1 text-sm text-gray-500">
                            Dados de venda disponíveis para exportação no período informado.
                        </p>
                    </div>

                    <div className="overflow-x-auto">
                        <table className="min-w-full divide-y divide-gray-200 text-sm">
                            <thead className="bg-gray-50 text-left text-xs font-semibold uppercase text-gray-600">
                                <tr>
                                    <th className="px-4 py-3">Seq. interface</th>
                                    <th className="px-4 py-3">Data faturamento</th>
                                    <th className="px-4 py-3 text-right">Embalagem estoque (qtde)</th>
                                    <th className="px-4 py-3 text-right">Embalagem compra (qtde)</th>
                                    <th className="px-4 py-3 text-right">Participantes (clientes)</th>
                                </tr>
                            </thead>
                            <tbody className="divide-y divide-gray-100 text-gray-800">
                                {resumo.map((r) => (
                                    <tr key={`${r.seqinterface}-${r.datafaturamento}`} className="hover:bg-gray-50">
                                        <td className="px-4 py-2">{r.seqinterface}</td>
                                        <td className="px-4 py-2">{fmtData(r.datafaturamento)}</td>
                                        <td className="px-4 py-2 text-right">{fmtNum(r.embalagemestoqueqtde)}</td>
                                        <td className="px-4 py-2 text-right">{fmtNum(r.embalagemcompraqtde)}</td>
                                        <td className="px-4 py-2 text-right">{fmtNum(r.cdparticipantecliente)}</td>
                                    </tr>
                                ))}
                                {resumo.length === 0 && (
                                    <tr>
                                        <td colSpan={5} className="px-4 py-6 text-center text-gray-500">
                                            {pesquisou ? "Nenhum registro encontrado." : "Clique em Pesquisar para exibir o resumo."}
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </section>

                <section className="overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
                    <div className="border-b border-gray-100 px-5 py-4 sm:px-6">
                        <h2 className="text-base font-semibold text-gray-800">
                            Geração de arquivos
                        </h2>
                        <p className="mt-1 text-sm text-gray-500">
                            Escolha o arquivo e o período de processamento.
                        </p>
                    </div>

                    <div className="p-5 sm:p-6">
                        <div className="grid grid-cols-1 gap-5 md:grid-cols-3">
                            <div className="min-w-0">
                                <label htmlFor="arquivo" className="mb-1.5 block text-sm font-medium text-gray-700">
                                    Arquivo
                                </label>
                                <select
                                    id="arquivo"
                                    value={SelectedArquivo}
                                    disabled={ActionStatus === 1}
                                    onChange={(e) => setSelectedArquivo(e.target.value)}
                                    className="block w-full rounded-md border border-gray-300 bg-white px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
                                >
                                    {ARQUIVOS.map((item) => (
                                        <option key={item.tipo} value={item.tipo}>
                                            {item.descricao}
                                        </option>
                                    ))}
                                </select>
                            </div>

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

                        <div className="mt-6 flex justify-stretch border-t border-gray-100 pt-5 sm:justify-end">
                            <button
                                type="button"
                                className="inline-flex w-full items-center justify-center gap-2 rounded-md bg-green-600 px-4 py-2.5 text-sm font-medium text-white shadow-sm transition hover:bg-green-700 focus:outline-none focus:ring-2 focus:ring-green-500 focus:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-70 sm:w-auto"
                                title="Gerar arquivo"
                                onClick={() => GerarArquivo()}
                                disabled={ActionStatus === 1}
                            >
                                {ActionStatus === 1 ? (
                                    <svg className="h-4 w-4 animate-spin" fill="none" viewBox="0 0 24 24" aria-hidden="true">
                                        <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                                        <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                                    </svg>
                                ) : (
                                    <svg className="h-4 w-4" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24" aria-hidden="true">
                                        <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v12m0 0 4-4m-4 4-4-4M4 20h16" />
                                    </svg>
                                )}
                                Gerar arquivo
                            </button>
                        </div>
                    </div>
                </section>

            </div>
        </div>
    );
}
