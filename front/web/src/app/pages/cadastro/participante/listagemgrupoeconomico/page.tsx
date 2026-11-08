'use client'

import { useState } from 'react';
import { useAuth } from "@/app/context/context";

import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import CmbFormaPgtoBluesoft from '../../_components/CmbFormaPgtoBluesoft/page';
import CmbVendedor from '@/app/pages/cadastro/_components/CmbVendedor/page';

import { moduleParticipante } from "@/api/m0011_Participante/moduleParticipante";

const listTipoStatusCredito = [
    { bluesoftcliente_creditostatus_cd: 1, status_credito_cd: "CREDITO_OK", label: "CRÉDITO OK" },
    { bluesoftcliente_creditostatus_cd: 2,status_credito_cd: "BLOQUEADO", label: "BLOQUEADO" },
    { bluesoftcliente_creditostatus_cd: 3, status_credito_cd: "DEVEDOR", label: "DEVEDOR" },
    { bluesoftcliente_creditostatus_cd: 4, status_credito_cd: "PROTESTADO", label: "PROTESTADO" },
    { bluesoftcliente_creditostatus_cd: 5, status_credito_cd: "EM_ANALISE", label: "EM ANÁLISE" }
];
    


export default function ParticipanteGrupoEconomico() {
    const __SIS_AC_CD: number = 1015;
    const { user } = useAuth();

    const [vendedorCarregado, setVendedorCarregado] = useState(false);
    const [formaPgtoCarregada, setFormaPgtoCarregada] = useState(false);
    const [consultando, setConsultando] = useState(false);
    const [atualizandoCredito, setAtualizandoCredito] = useState(false);
    const actionStatus = !vendedorCarregado || !formaPgtoCarregada || consultando || atualizandoCredito ? 1 : 0;
    const [list, setList] = useState<any[]>([]);
    const [selecionados, setSelecionados] = useState<Set<string>>(new Set());
    const [erroCredito, setErroCredito] = useState('');
    const [nomeRazaoFilter, setNomeRazaoFilter] = useState('');

    const [statusCreditoSelecionado, setStatusCreditoSelecionado] = useState('');
    const [bluesoftclienteCreditoStatusSelecionado, setBluesoftclienteCreditoStatusSelecionado] = useState(0);
    const [cdParticipanteVendedorFilter, setCdParticipanteVendedor] = useState(0);
    const [forma_pgto_cd_filter, setFormaPgtoCdFilter] = useState(0);

    const consultarLista = async () => {
        try {
            setList([]);
            setSelecionados(new Set());
            setErroCredito('');
            setConsultando(true);

            const participanteModule = new moduleParticipante(user, __SIS_AC_CD);
            const response = await participanteModule.getParticipanteGrupoEconomicoList({
                nome_razao: nomeRazaoFilter,
                participante_tipo_cd: 0,
                bluesoftcliente_creditostatus_cd: bluesoftclienteCreditoStatusSelecionado,
                cdparticipante_vendedor: cdParticipanteVendedorFilter,
                forma_pgto_cd_grupo_economico_padrao: forma_pgto_cd_filter
                
            });

            setList(response || []);
        } catch (error) {
            console.error('Erro ao consultar participantes vinculados ao grupo econômico:', error);
            setList([]);
        } finally {
            setConsultando(false);
        }
    };

    const limparFiltros = () => {
        setNomeRazaoFilter('');
        setBluesoftclienteCreditoStatusSelecionado(0);
        setCdParticipanteVendedor(0);
        setFormaPgtoCdFilter(1);
    };



    const alternarSelecionado = (cdparticipante: string) => {
        setSelecionados((anteriores) => {
            const novos = new Set(anteriores);
            if (novos.has(cdparticipante)) {
                novos.delete(cdparticipante);
            } else {
                novos.add(cdparticipante);
            }
            return novos;
        });
    };

    const atualizaStatsCredito = async (status_credito_cd: string) => {
        if (atualizandoCredito) return;

        const itensSelecionados = list.filter((item) => selecionados.has(String(item.cdparticipante)));
        if (!status_credito_cd || itensSelecionados.length === 0) {
            setErroCredito('Selecione um status de crédito e pelo menos um participante.');
            return;
        }
        if (itensSelecionados.some((item) => item.cdpessoabluesoft == null || item.cdpessoabluesoft === '')) {
            setErroCredito('Há participante selecionado sem código BlueSoft.');
            return;
        }

        setErroCredito('');
        setAtualizandoCredito(true);
        let participanteAtual = '';
        try {
            const participanteModule = new moduleParticipante(user, __SIS_AC_CD);
            for (const item of itensSelecionados) {
                participanteAtual = String(item.cdparticipante);
                const parametro = {
                    cdpessoabluesoft: item.cdpessoabluesoft,
                    status_credito_cd: status_credito_cd
                };
                await participanteModule.postOperacaoBluesoftApiAtualizarStatusCredito(parametro);
                setSelecionados((anteriores) => {
                    const novos = new Set(anteriores);
                    novos.delete(String(item.cdparticipante));
                    return novos;
                });
            }
        } catch (error) {
            console.error('Erro ao atualizar status de crédito:', error);
            setErroCredito(`Erro ao processar o participante ${participanteAtual}. Os itens não processados continuam selecionados.`);
        } finally {
            setAtualizandoCredito(false);
        }
    };

    const statusClass = (value: number | boolean) =>
        value === 1 || value === true ? 'bg-green-500' : 'bg-red-500';

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain
                    tipo="_PAGE"
                    ActionStatus={actionStatus}
                    header_title="Participante | Grupo Econômico"
                >
                    <div className="flex space-x-2">
                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            label="Pesquisar"
                            TypeIcon="_PESQUISAR"
                            title="Pesquisar participantes"
                            onClick={consultarLista}
                            ActionStatus={actionStatus}
                        />
                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            label="Limpar"
                            TypeIcon="_PESQUISAR"
                            title="Limpar filtros"
                            onClick={limparFiltros}
                        />
                    </div>
                </HeaderMain>

                <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Nome / Razão Social
                            </label>
                            <input
                                type="text"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                                placeholder="Filtrar por nome ou razão social"
                                value={nomeRazaoFilter}
                                onChange={(event) => setNomeRazaoFilter(event.target.value)}
                            />
                        </div>
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Vendedor</label>
                            <CmbVendedor user={user} onChange={(value) => setCdParticipanteVendedor(Number(value))} value={cdParticipanteVendedorFilter.toString()} sis_ac_cd={__SIS_AC_CD} onLoadComplete={() => setVendedorCarregado(true)} />
                        </div> 

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Forma de pgto padrão do Grupo Econômico</label>
                            <CmbFormaPgtoBluesoft
                             user={user} onChange={(value) => setFormaPgtoCdFilter(Number(value))} value={`${forma_pgto_cd_filter}`} sis_ac_cd={__SIS_AC_CD} onLoadComplete={() => setFormaPgtoCarregada(true)} />
                        </div> 
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Status de Crédito
                            </label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md text-black"
                                value={bluesoftclienteCreditoStatusSelecionado}
                                onChange={(event) => setBluesoftclienteCreditoStatusSelecionado(Number(event.target.value))}
                            >
                                <option value="">Todos os status</option>
                                {listTipoStatusCredito.map((status) => (
                                    <option
                                        key={status.bluesoftcliente_creditostatus_cd}
                                        value={status.bluesoftcliente_creditostatus_cd}
                                    >
                                        {status.label}
                                    </option>
                                ))}
                            </select>
                        </div>
                    </div>
                </div>

                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
                    <div className="max-h-[500px] overflow-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-gray-100 sticky top-0 z-10">
                                <tr>
                                    <th scope="col" className="px-4 py-2 text-left text-xs font-medium text-purple-700">
                                        Selecionar
                                    </th>
                                    {[
                                        'Cod',
                                        'CPF/CNPJ',
                                        'PJ',
                                        'Info',
                                        'Nome/Razão Social',
                                        'Grupo Econômico',
                                        'Vendedor',
                                        'M01', 
                                        'M02',
                                        'M03'
                                    ].map((title) => (
                                        <th
                                            key={title}
                                            className={`px-6 py-2 text-left text-xs font-medium text-purple-700 tracking-wider whitespace-nowrap ${
                                                title === 'Nome/Razão Social' ? 'w-[25%]' :
                                                title === 'Grupo Econômico' ? 'w-[20%]' :
                                                title === 'Vendedor' ? 'w-[18%]' : ''
                                            }`}
                                        >
                                            {title}
                                        </th>
                                    ))}
                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {list.length > 0 ? (
                                    list.map((item) => (
                                        <tr key={item.cdparticipante} className="hover:bg-gray-50">
                                            <td className="px-4 py-1">
                                                <input
                                                    type="checkbox"
                                                    aria-label={`Selecionar participante ${item.nome_razao} (${item.cdparticipante})`}
                                                    checked={selecionados.has(String(item.cdparticipante))}
                                                    onChange={() => alternarSelecionado(String(item.cdparticipante))}
                                                    disabled={atualizandoCredito}
                                                />
                                            </td>
                                            <td className="px-4 py-1 text-sm text-gray-700">
                                                Blue {item.cdpessoabluesoft}
                                                <div className="break-words">
                                                    Pag {item.cdparticipante}
                                                </div>
                                            </td>
                                            <td className="px-4 py-1 text-sm text-gray-700">{item.cpf_cnpj}</td>
                                            <td className="px-4 py-1 text-sm text-gray-700">
                                                {item.pessoajuridica ? 'Sim' : 'Não'}
                                            </td>
                                            <td className="px-4 py-1 text-sm text-gray-700">
                                                P: <span className={`inline-block w-3 h-3 rounded-full ${statusClass(item.bluesoft_pessoa_status)}`} /> C: <span className={`inline-block w-3 h-3 rounded-full ${statusClass(item.bluesoftclientestatus)}`} />
                                                <div className="break-words">
                                                Cad.: {user.formatDateDDMMYYYY(item.bluesoft_pessoa_data_cadastro)}
                                                </div>
                                            </td>
                                            <td className="w-[25%] px-4 py-1 text-sm text-gray-700">
                                                {item.nome_razao}
                                                <div className="break-words">
                                                    Nome Abreviado: {item.nome_abreviado}
                                                </div>
                                            </td>


                                            <td className="w-[20%] px-4 py-1 text-sm text-gray-700 break-words">
                                                {item.descricao}
                                                
                                                <div className="break-words">
                                                Código: {item.cdgrupoeconomico} Forma Pgto: {item.forma_pgto_descricao}
                                                </div>



                                            </td>
                                            
                                            <td className="w-[18%] px-4 py-1 text-sm text-gray-700 break-words">
                                                {item.nome_vendedor}
                                                <div className="break-words">
                                                    Código: {item.cdpessoabluesoft_vendedor}
                                                </div>
                                            </td>
                                            
                                            <td className="w-[10%] px-4 py-1 text-sm text-gray-700 break-words">
                                                {user.formatNumber(item.mes01,2)}
                                            </td>
                                            <td className="w-[10%] px-4 py-1 text-sm text-gray-700 break-words">
                                                {user.formatNumber(item.mes02,2)}
                                            </td>
                                            <td className="w-[10%] px-4 py-1 text-sm text-gray-700 break-words">
                                                {user.formatNumber(item.mes03,2)}
                                            </td>
                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan={11} className="px-6 py-8 text-center text-sm text-gray-500">
                                            Nenhum participante vinculado a grupo econômico encontrado.
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                            <tfoot className="bg-gray-100">
                                <tr>
                                    <td colSpan={11} className="px-6 py-2 text-sm font-medium text-gray-700">
                                        Total de registros: {list.length}
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>

                {erroCredito && (
                    <p role="alert" className="mt-4 text-sm text-red-600">{erroCredito}</p>
                )}
                <div className="mt-4 flex flex-col gap-2 sm:flex-row sm:items-center sm:justify-end">
                    <select
                        className="p-2 border border-gray-300 rounded-md text-black"
                        value={statusCreditoSelecionado}
                        onChange={(event) => setStatusCreditoSelecionado(event.target.value)}
                        aria-label="Status de crédito"
                        disabled={atualizandoCredito}
                    >
                        <option value="">Selecione o status de crédito</option>
                        {listTipoStatusCredito.map((status) => (
                            <option key={status.status_credito_cd} value={status.status_credito_cd}>
                                {status.label}
                            </option>
                        ))}
                    </select>
                    <ButtonPag
                        TypeButton="_BUTTON_HEADER"
                        label="Atualizar status de crédito"
                        TypeIcon="_UPDATE"
                        title="Atualizar status de crédito"
                        onClick={() => atualizaStatsCredito(statusCreditoSelecionado)}
                        ActionStatus={actionStatus || !statusCreditoSelecionado || selecionados.size === 0 ? 1 : 0}
                    />
                </div>
            </div>
        </div>
    );
}