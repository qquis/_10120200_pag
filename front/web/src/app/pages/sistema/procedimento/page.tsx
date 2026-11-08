"use client"
import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import { moduleSistema, type modelSistemNucleoProcedimento, type modelSistemaNucleo } from "@/api/m0001_sistema/moduleSistema";

// Tipos para o WhatsApp QR
type WhatsAppStatus = {
    status: 'waiting' | 'qrcode' | 'ready' | 'error';
    message: string;
    qrcode?: string;
};

export default function SistemaProcedimentoPage() {
    const { user } = useAuth();

    const [ActionStatus, setActionStatus] = useState(0);
    const [resultMessage, setResultMessage] = useState("Nenhum registro encontrado.");
    const [listProcedimentos, setListProcedimentos] = useState<modelSistemNucleoProcedimento[]>([]);
    const [listNucleos, setListNucleos] = useState<modelSistemaNucleo[]>([]);
    const [selectedNucleoCd, setSelectedNucleoCd] = useState<string>("");

    // Estados para WhatsApp QR Code
    const [whatsappStatus, setWhatsappStatus] = useState<WhatsAppStatus>({
        status: 'waiting',
        message: 'Carregando...'
    });
    const [showQRCode, setShowQRCode] = useState(false);

    useEffect(() => {
        // Carrega núcleos e procedimentos ao montar
        const sistema = new moduleSistema(user);
        const fetchNucleos = async () => {
            try {
                const nucleos = await sistema.sistemaNucleo.SistemaNucleoListGet();
                setListNucleos(nucleos);
                if (nucleos.length > 0) setSelectedNucleoCd(nucleos[0].sis_nucleo_cd);
            } catch (e) {
                // erro silencioso
            }
        };
        fetchNucleos();
    }, [user]);

    // Função para buscar QR Code do WhatsApp
    const fetchWhatsAppQR = async () => {
        try {
            const response = await fetch('http://localhost:3001/api/qrcode');
            const data = await response.json();
            setWhatsappStatus(data);
        } catch (error) {
            setWhatsappStatus({
                status: 'error',
                message: 'Erro ao conectar com o servidor WhatsApp'
            });
        }
    };

    // Verificar status do WhatsApp
    const checkWhatsAppStatus = async () => {
        try {
            const response = await fetch('http://localhost:3001/api/status');
            const data = await response.json();
            return data;
        } catch (error) {
            return { isReady: false, hasQRCode: false };
        }
    };

    // Effect para atualizar QR Code automaticamente
    useEffect(() => {
        let interval: NodeJS.Timeout;
        
        if (showQRCode) {
            // Buscar imediatamente
            fetchWhatsAppQR();
            
            // Configurar atualização automática a cada 3 segundos
            interval = setInterval(fetchWhatsAppQR, 3000);
        }

        return () => {
            if (interval) clearInterval(interval);
        };
    }, [showQRCode]);

    const listarProcedimentos = async () => {
        setActionStatus(1);
        setResultMessage("Nenhum registro encontrado.");
        setListProcedimentos([]);
        try {
            const sistema = new moduleSistema(user);
            const parametros = selectedNucleoCd ? { sis_nucleo_cd: selectedNucleoCd } : {};
            const lista = await sistema.sistemaNucleo.SistemaNucleoListProcedimentoGet(parametros);
            setListProcedimentos(lista);
            if (!lista || lista.length === 0) setResultMessage("Nenhum registro encontrado.");
        } catch (e) {
            setResultMessage("Erro ao carregar procedimentos: " + e);
        } finally {
            setActionStatus(0);
        }
    };

    const getStatusColor = (status: string) => {
        switch (status) {
            case 'ready': return 'text-green-600 bg-green-50 border-green-200';
            case 'qrcode': return 'text-blue-600 bg-blue-50 border-blue-200';
            case 'waiting': return 'text-yellow-600 bg-yellow-50 border-yellow-200';
            case 'error': return 'text-red-600 bg-red-50 border-red-200';
            default: return 'text-gray-600 bg-gray-50 border-gray-200';
        }
    };

    const getStatusIcon = (status: string) => {
        switch (status) {
            case 'ready': return '✅';
            case 'qrcode': return '📱';
            case 'waiting': return '⏳';
            case 'error': return '❌';
            default: return '⚪';
        }
    };

    const executarInicializacaoDiaria = async () => {
        try {
                const sistema = new moduleSistema(user);
                setActionStatus(1);
                await sistema.postSistemaInicializacaoDiaria();
                setActionStatus(0);
        } catch (e) {
            console.error("Erro ao executar inicialização diária: ", e);
        } finally {
            setActionStatus(0);
        }
    };

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">

                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Sistema | Núcleos Procedimentos">
                    <div className="flex space-x-2 items-center">
                        <label className="text-sm font-medium text-gray-700 mr-2">Núcleo:</label>
                        <select
                            className="px-2 py-1 text-sm border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-purple-500 focus:border-purple-500 text-black"
                            value={selectedNucleoCd}
                            onChange={e => setSelectedNucleoCd(e.target.value)}
                        >
                            {listNucleos.map(nucleo => (
                                <option key={nucleo.sis_nucleo_cd} value={nucleo.sis_nucleo_cd}>
                                    {nucleo.sis_nucleo_cd} - {nucleo.sis_nucleo_descricao}
                                </option>
                            ))}
                        </select>
                        
                        
                        {/* Botão WhatsApp QR Code */}
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="Procedimentos" 
                            TypeIcon="_SELECT" 
                            title="Exibir Procedimentos" 
                            onClick={() => listarProcedimentos()}
                        />
                    </div>
                </HeaderMain>



                {/* Grid List */}
                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100 mt-6">
                    <div className="max-h-[500px] overflow-y-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-gray-100 sticky top-0 z-10">
                                <tr>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Núcleo</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">N. Desc</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Procedimento CD</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Descritivo</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tipo</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Permite Execução Manual</th>
                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {listProcedimentos.length > 0 ? (
                                    listProcedimentos.map((item, idx) => (
                                        <tr key={idx} className="hover:bg-gray-50">
                                            <td className="px-4 py-2 text-xs text-gray-700">{item.sis_nucleo_cd}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700">{item.sis_nucleo_descricao}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700">{item.sis_nucleo_prc_cd}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700">{item.sis_nucleo_prc_descritivo}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700">{item.sis_nucleo_prc_tipo}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700">{item.permite_execucao_manual === 1 ? "Sim" : "Não"}</td>
                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan={8} className="px-6 py-4 text-center text-sm text-gray-500">
                                            {resultMessage}
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                    <div className="px-6 py-4 text-left text-sm text-gray-500">Total de Registros {listProcedimentos.length}</div>
                </div>
                <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
                        <div className="flex items-center gap-4">
                          <h2 className="text-base font-semibold text-gray-800">
                                Executar Rotina de INICIALIZAÇÃO DIÁRIA
                          </h2>
                          <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" onClick={executarInicializacaoDiaria} title="Importar Base NFCE"  ActionStatus={ActionStatus}
                          />
                        </div>
                      </div>
            </div>
        </div>
    );
}
