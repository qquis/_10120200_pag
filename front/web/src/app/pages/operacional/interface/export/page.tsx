'use client'
const __SIS_AC_CD : number = 1012

import { useEffect, useState, useMemo } from 'react';
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

const ARQUIVOS_DIAL: tipoArquivo[] = [
    { tipo: "all", descricao: "TODOS", arquivo: "" },
    { tipo: "sales", descricao: "DIAL Venda (Sales)", arquivo: "VENDA_JOHNSON" },
    { tipo: "stock", descricao: "DIAL Estoque (Stock)", arquivo: "ESTOQUE_JOHNSON" },
    { tipo: "client", descricao: "DIAL Cliente (Client)", arquivo: "CLIENTE_JOHNSON" },

];

const ARQUIVOS_MTRIX: tipoArquivo[] = [
    { tipo: "mtrix_cliente", descricao: "Mtrix Cliente", arquivo: "MTRIX_CLIENTE" },
    { tipo: "mtrix_venda", descricao: "Mtrix Venda", arquivo: "MTRIX_VENDA" },
    { tipo: "mtrix_forca_venda", descricao: "Mtrix Força de Venda", arquivo: "MTRIX_FORCA_VENDA" },
    { tipo: "mtrix_produto", descricao: "Mtrix Produto", arquivo: "MTRIX_PRODUTO" },
    { tipo: "mtrix_estoque", descricao: "Mtrix Estoque", arquivo: "MTRIX_ESTOQUE" },
];

const hoje = () => new Date().toISOString().slice(0, 10);
const toYYYYMMDD = (d: string) => d.replace(/-/g, '');

let myModule: moduleInterface;

export default function InterfaceExport() {

    /* USER */
    const { user } = useAuth();

    const myModule = useMemo(
    () => new moduleInterface(user, __SIS_AC_CD),
    [user]
);

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [SelectedArquivoDIAL, setSelectedArquivoDIAL] = useState<string>("all");
    const [SelectedArquivoMTRIX, setSelectedArquivoMTRIX] = useState<string>("mtrix_venda");
    const [dataIni, setDataIni] = useState<string>(hoje());
    const [dataFim, setDataFim] = useState<string>(hoje());
    const [mensagem, setMensagem] = useState<string>("");
    const [resumo, setResumo] = useState<resumoData[]>([]);
    const [pesquisou, setPesquisou] = useState<boolean>(false);

    useEffect(() => {
        
    }, []);

    const validarDatas = (): boolean => {
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
        if (!validarDatas()) return;

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

    const GerarArquivoDIAL = async () => {
        setMensagem("");
        if (!validarDatas()) return;

        try {
            setActionStatus(1);
            await myModule.dial.downloadfiles({
                tipo: SelectedArquivoDIAL,
                data_processamento_ini: toYYYYMMDD(dataIni),
                data_processamento_fim: toYYYYMMDD(dataFim),
            });
        } catch (error) {
            console.error('Erro ao gerar arquivo DIAL:', error);
            setMensagem("Erro ao gerar o arquivo DIAL.");
        } finally {
            setActionStatus(0);
        }
    };

    const GerarArquivoMTRIX = async () => {
        setMensagem("");
        if (!validarDatas()) return;

        try {
            setActionStatus(1);

            await myModule.mtrix.downloadfiles({
                tipo: SelectedArquivoMTRIX,
                data_processamento_ini: toYYYYMMDD(dataIni),
                data_processamento_fim: toYYYYMMDD(dataFim),
            });
        } catch (error) {
            console.error('Erro ao gerar arquivo MTRIX:', error);
            setMensagem("Erro ao gerar o arquivo MTRIX.");
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
                    header_title="Interface | Exportações"
                >
                    <div className="flex space-x-2">
                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={Pesquisar} ></ButtonPag>
                    </div>
                </HeaderMain>


                {/* SEÇÃO DE DATAS COMPARTILHADA */}
                <section className="mt-4 overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
                    <div className="border-b border-gray-100 px-5 py-4 sm:px-6">
                        <h2 className="text-base font-semibold text-gray-800">
                            Período de exportação
                        </h2>
                        <p className="mt-1 text-sm text-gray-500">
                            Defina o período que será utilizado para ambas as exportações.
                        </p>
                    </div>

                    <div className="p-5 sm:p-6">
                        <div className="grid grid-cols-1 gap-5 md:grid-cols-2">
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
                                    className="block w-full rounded-md border border-gray-300 px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 disabled:bg-gray-100 disabled:cursor-not-allowed"
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
                                    className="block w-full rounded-md border border-gray-300 px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 disabled:bg-gray-100 disabled:cursor-not-allowed"
                                />
                            </div>
                        </div>

                        {mensagem && (
                            <div className="mt-4 rounded-md bg-red-50 p-3 border border-red-200">
                                <p className="text-sm text-red-700">{mensagem}</p>
                            </div>
                        )}
                    </div>
                </section>                

                {/* RESUMO DE VENDAS */}
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


                {/* GERAÇÃO DIAL */}
                <section className="mt-4 overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
                    <div className="border-b border-gray-100 px-5 py-4 sm:px-6">
                        <h2 className="text-base font-semibold text-gray-800">
                            Geração de arquivos DIAL
                        </h2>
                        <p className="mt-1 text-sm text-gray-500">
                            Escolha o arquivo a ser exportado.
                        </p>
                    </div>

                    <div className="p-5 sm:p-6">
                        <div className="flex flex-col gap-4 sm:flex-row sm:items-end">
                            <div className="flex-1 min-w-0">
                                <label htmlFor="arquivoDial" className="mb-1.5 block text-sm font-medium text-gray-700">
                                    Arquivo
                                </label>
                                <select
                                    id="arquivoDial"
                                    value={SelectedArquivoDIAL}
                                    disabled={ActionStatus === 1}
                                    onChange={(e) => setSelectedArquivoDIAL(e.target.value)}
                                    className="block w-full rounded-md border border-gray-300 bg-white px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 disabled:bg-gray-100 disabled:cursor-not-allowed"
                                >
                                    {ARQUIVOS_DIAL.map((item) => (
                                        <option key={item.tipo} value={item.tipo}>
                                            {item.descricao}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            <button
                                type="button"
                                className="inline-flex items-center justify-center gap-2 rounded-md bg-green-600 px-6 py-2.5 text-sm font-medium text-white shadow-sm transition hover:bg-green-700 focus:outline-none focus:ring-2 focus:ring-green-500 focus:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-70"
                                title="Gerar arquivo DIAL"
                                onClick={GerarArquivoDIAL}
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

                {/* GERAÇÃO MTRIX */}
                <section className="mt-4 overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
                    <div className="border-b border-gray-100 px-5 py-4 sm:px-6">
                        <h2 className="text-base font-semibold text-gray-800">
                            Geração de arquivos MTRIX
                        </h2>
                        <p className="mt-1 text-sm text-gray-500">
                            Escolha o arquivo a ser exportado.
                        </p>
                    </div>

                    <div className="p-5 sm:p-6">
                        <div className="flex flex-col gap-4 sm:flex-row sm:items-end">
                            <div className="flex-1 min-w-0">
                                <label htmlFor="arquivoMtrix" className="mb-1.5 block text-sm font-medium text-gray-700">
                                    Arquivo
                                </label>
                                <select
                                    id="arquivoMtrix"
                                    value={SelectedArquivoMTRIX}
                                    disabled={ActionStatus === 1}
                                    onChange={(e) => setSelectedArquivoMTRIX(e.target.value)}
                                    className="block w-full rounded-md border border-gray-300 bg-white px-3 py-2.5 text-sm text-gray-800 shadow-sm outline-none transition focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 disabled:bg-gray-100 disabled:cursor-not-allowed"
                                >
                                    {ARQUIVOS_MTRIX.map((item) => (
                                        <option key={item.tipo} value={item.tipo}>
                                            {item.descricao}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            <button
                                type="button"
                                className="inline-flex items-center justify-center gap-2 rounded-md bg-green-600 px-6 py-2.5 text-sm font-medium text-white shadow-sm transition hover:bg-green-700 focus:outline-none focus:ring-2 focus:ring-green-500 focus:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-70"
                                title="Gerar arquivo MTRIX"
                                onClick={GerarArquivoMTRIX}
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
