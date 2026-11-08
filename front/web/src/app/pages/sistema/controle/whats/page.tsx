"use client"
import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";


// Tipos para o WhatsApp QR
type WhatsAppStatus = {
    status: 'waiting' | 'qrcode' | 'ready' | 'error';
    message: string;
    qrcode?: string;
};

export default function ControleWhats() {
    const { user } = useAuth();

    const [ActionStatus, setActionStatus] = useState(0);

    const [selectedNucleoCd, setSelectedNucleoCd] = useState<string>("");

    // Estados para WhatsApp QR Code
    const [whatsappStatus, setWhatsappStatus] = useState<WhatsAppStatus>({
        status: 'waiting',
        message: 'Carregando...'
    });
    const [showQRCode, setShowQRCode] = useState(false);


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

    // Função para controlar o comportamento do botão
    const handleQRCodeAction = () => {
        if (showQRCode && whatsappStatus.status === 'ready') {
            // WhatsApp conectado - apenas atualizar status
            fetchWhatsAppQR();
        } else if (showQRCode && whatsappStatus.status !== 'ready') {
            // QR Code visível mas não conectado - gerar novo QR Code
            fetchWhatsAppQR();
        } else {
            // QR Code não está sendo exibido - mostrar QR Code
            setShowQRCode(true);
            fetchWhatsAppQR();
        }
    };

    // Função para verificar status e atualizar o estado
    const handleVerifyStatus = async () => {
        try {
            const statusData = await checkWhatsAppStatus();
            
            // Atualizar o estado com base no retorno
            if (statusData.isReady) {
                setWhatsappStatus({
                    status: 'ready',
                    message: 'WhatsApp conectado e pronto!'
                });
            } else if (statusData.hasQRCode) {
                setWhatsappStatus({
                    status: 'qrcode',
                    message: 'QR Code disponível para escaneamento'
                });
                // Opcional: buscar o QR Code atual
                fetchWhatsAppQR();
            } else {
                setWhatsappStatus({
                    status: 'waiting',
                    message: 'Aguardando conexão...'
                });
            }
        } catch (error) {
            setWhatsappStatus({
                status: 'error',
                message: 'Erro ao verificar status'
            });
        }
    };

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">

                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Gerencimento de Serviços">
                    <div className="flex space-x-2 items-center">

                        
                        
                        {/* Botão WhatsApp QR Code */}
                        <ButtonPag 
                            TypeButton="_BUTTON_HEADER" 
                            label="WhatsApp QR" 
                            TypeIcon="_SELECT" 
                            title="Exibir QR Code WhatsApp" 
                            onClick={handleQRCodeAction} 
                        />
                    </div>
                </HeaderMain>

                {/* Modal/Card do QR Code WhatsApp */}
                {showQRCode && (
                    <div className="bg-white rounded-lg shadow-lg border border-purple-100 mt-6 p-6">
                        <div className="flex justify-between items-center mb-4">
                            <h3 className="text-lg font-semibold text-gray-800">WhatsApp QR Code</h3>
                            <button
                                onClick={() => setShowQRCode(false)}
                                className="text-gray-500 hover:text-gray-700 text-xl font-bold"
                            >
                                ×
                            </button>
                        </div>

                        {/* Status */}
                        <div className={`inline-flex items-center px-3 py-2 rounded-md text-sm font-medium border mb-4 ${getStatusColor(whatsappStatus.status)}`}>
                            <span className="mr-2">{getStatusIcon(whatsappStatus.status)}</span>
                            {whatsappStatus.message}
                        </div>

                        {/* QR Code Display */}
                        <div className="flex justify-center items-center min-h-[300px] border-2 border-dashed border-gray-300 rounded-lg bg-gray-50">
                            {whatsappStatus.status === 'ready' ? (
                                <div className="text-center">
                                    <div className="text-6xl mb-4">✅</div>
                                    <div className="text-xl text-green-600 font-semibold">WhatsApp Conectado!</div>
                                    <div className="text-sm text-gray-600 mt-2">Sistema pronto para enviar mensagens</div>
                                </div>
                            ) : whatsappStatus.qrcode ? (
                                <div className="text-center">
                                    <img 
                                        src={whatsappStatus.qrcode} 
                                        alt="QR Code WhatsApp" 
                                        className="max-w-full max-h-[280px] mx-auto rounded-lg shadow-sm"
                                    />
                                    <div className="text-sm text-gray-600 mt-3">
                                        Escaneie o código com seu WhatsApp
                                    </div>
                                </div>
                            ) : whatsappStatus.status === 'waiting' ? (
                                <div className="text-center">
                                    <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-purple-600 mx-auto mb-4"></div>
                                    <div className="text-gray-600">Aguardando QR Code...</div>
                                </div>
                            ) : (
                                <div className="text-center">
                                    <div className="text-4xl mb-4">❌</div>
                                    <div className="text-red-600">Erro de conexão</div>
                                    <button
                                        onClick={fetchWhatsAppQR}
                                        className="mt-3 px-4 py-2 bg-purple-600 text-white rounded-md hover:bg-purple-700 text-sm"
                                    >
                                        Tentar Novamente
                                    </button>
                                </div>
                            )}
                        </div>

                        {/* Botões de ação */}
                        <div className="flex justify-center space-x-3 mt-6">
                            <button
                                onClick={fetchWhatsAppQR}
                                className="px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 text-sm font-medium"
                            >
                                🔄 Atualizar/Gerar QRCODE
                            </button>
                            <button
                                onClick={handleVerifyStatus}
                                className="px-4 py-2 bg-gray-600 text-white rounded-md hover:bg-gray-700 text-sm font-medium"
                            >
                                📊 Verificar Status
                            </button>
                        </div>
                    </div>
                )}

            </div>
        </div>
    );
}
