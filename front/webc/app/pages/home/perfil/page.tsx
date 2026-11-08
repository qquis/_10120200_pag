'use client';

import React from 'react';
import { useState, useEffect } from 'react';
import { moduleParticipanteCrm, TpParticipanteCRM } from '@/app/api/m0011_participante/moduleparticipante';
import { useAuth } from '../../../context/context';
import { useRouter } from 'next/navigation';

export default function perfilpage() { 
    const { user } = useAuth();
    const router = useRouter();
    //const [myModuleParticipanteCRM] = useState(() => new moduleParticipanteCrm());
    const [loading, setLoading] = useState(false);
    const [message, setMessage] = useState('');

    const module : moduleParticipanteCrm = new moduleParticipanteCrm();

    const [participante, setParticipante] = useState<TpParticipanteCRM>({
        crm_seq: 0,
        crm_status_cd: 2,
        crm_email: '',
        cpf: '',
        nome: '',
        sobre_nome: '',
        data_nascimento: new Date('1900-01-01'),
        pf_sexo: 'N',
        crm_dt_cadastro : new Date('1900-01-01'),
    });

    useEffect(() => {
    const fetchParticipante = async () => {
        try {
            const consultarParticipante: TpParticipanteCRM = await module.consultar({crm_email: user.email_main});
            if (consultarParticipante.crm_seq && consultarParticipante.crm_seq > 0) {
                setParticipante(consultarParticipante);
            } else { 
                setParticipante(prev => ({
                    ...prev,
                    crm_email: user.email_main
                }));
            }
        } catch (error) {
            console.error('Erro ao consultar participante:', error);
            setMessage('Erro ao carregar dados do participante');
        }
    };

    if (user.email_main) {
        fetchParticipante();
    }
}, [user.email_main]);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        
        if (name === 'data_nascimento') {
            setParticipante(prev => ({
                ...prev,
                [name]: new Date(value)
            }));
        } else {
            setParticipante(prev => ({
                ...prev,
                [name]: value
            }));
        }
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setMessage('');

        try {
            const resultado = await module.incluir(participante);
            
            if (resultado) {
                setMessage('Participante incluído com sucesso!');
                // Reset form
                setParticipante(resultado);
                if (resultado.crm_seq && resultado.crm_seq > 0) {
                    // Redirecionar para a página home com parâmetros de usuário
                    setTimeout(() => {
                        const urlParams = new URLSearchParams({
                            email: user.email_main || '',
                            crm_seq: resultado.crm_seq?.toString() || '0',
                            nome: resultado.nome || '',
                            status: 'cadastrado'
                        });
                        router.push(`/pages/home?${urlParams.toString()}`);
                    }, 2000);
                }
            } else {
                setMessage(`Erro na inclusão do registro.`);
            }
        } catch (error) {
            setMessage('Erro ao incluir participante');
            console.error('Erro:', error);
        } finally {
            setLoading(false);
        }
    };

    // Função para formatar data para input type="date"
const formatDateForInput = (date: Date | string) => {
    if (!date) {
        return ''; // Retorna string vazia se a data for null/undefined
    }
    
    let dateObj: Date;
    
    // Se for string, converte para Date
    if (typeof date === 'string') {
        dateObj = new Date(date);
    } else {
        dateObj = date;
    }
    
    // Verifica se a data é válida
    if (!(dateObj instanceof Date) || isNaN(dateObj.getTime())) {
        return ''; // Retorna string vazia se a data for inválida
    }
    
    return dateObj.toISOString().split('T')[0];
};

    return (
        <div style={{
            background: 'white',
            minHeight: '100vh',
            fontFamily: "'Neue Helvetica', 'Helvetica Neue', 'Inter', -apple-system, BlinkMacSystemFont, sans-serif"
        }}>
            {/* Hero Section */}
            <div style={{
                textAlign: 'center',
                padding: '3rem 0',
                color: '#1e3a8a',
                background: 'white'
            }}>
                <div style={{maxWidth: '1200px', margin: '0 auto', padding: '0 1rem'}}>
                    <h1 style={{
                        fontSize: '2.2rem',
                        fontWeight: '800',
                        marginBottom: '1rem',
                        background: 'linear-gradient(45deg, #fbbf24, #f97316, #dc2626)',
                        WebkitBackgroundClip: 'text',
                        WebkitTextFillColor: 'transparent'
                    }}>
                        🔐 ÁREA DO PARTICIPANTE
                    </h1>
                    <p style={{fontSize: '1.4rem', marginBottom: '2rem', opacity: '0.8'}}>
                        Cadastre-se para participar do nosso aniversário premiado!
                    </p>
                </div>
            </div>

            {/* Form Section */}
            <div style={{background: 'white', padding: '4rem 0'}}>
                <div style={{maxWidth: '800px', margin: '0 auto', padding: '0 1rem'}}>
                    <div style={{
                        background: '#f8f9fa',
                        borderRadius: '25px',
                        padding: '3rem 2rem',
                        border: '2px solid #1e3a8a',
                        boxShadow: '0 10px 30px rgba(30, 58, 138, 0.1)'
                    }}>
                        <h2 style={{
                            textAlign: 'center',
                            fontSize: '1.8rem',
                            color: '#1e3a8a',
                            marginBottom: '2rem',
                            fontWeight: '700'
                        }}>
                            📝 Informações Cadastrais
                        </h2>

                        <form onSubmit={handleSubmit} style={{display: 'flex', flexDirection: 'column', gap: '1.5rem'}}>
                            {/* Email Field */}
                            <div>
                                <label htmlFor="crm_email" style={{
                                    display: 'block',
                                    fontSize: '1.1rem',
                                    fontWeight: '600',
                                    marginBottom: '0.5rem',
                                    color: '#1e3a8a'
                                }}>
                                    📧 Email:
                                </label>
                                <input
                                    type="email"
                                    id="crm_email"
                                    name="crm_email"
                                    disabled={true}
                                    value={participante.crm_email}
                                    onChange={handleInputChange}
                                    required
                                    style={{
                                        width: '100%',
                                        padding: '1rem',
                                        border: '2px solid #dee2e6',
                                        borderRadius: '15px',
                                        fontSize: '1rem',
                                        color: '#2d3748',
                                        backgroundColor: '#f8f9fa',
                                        transition: 'all 0.3s ease',
                                        outline: 'none'
                                    }}
                                />
                            </div>

                            {/* CPF Field */}
                            <div>
                                <label htmlFor="cpf" style={{
                                    display: 'block',
                                    fontSize: '1.1rem',
                                    fontWeight: '600',
                                    marginBottom: '0.5rem',
                                    color: '#1e3a8a'
                                }}>
                                    🆔 CPF:
                                </label>
                                <input
                                    type="text"
                                    id="cpf"
                                    name="cpf"
                                    value={participante.cpf}
                                    onChange={handleInputChange}
                                    required
                                    style={{
                                        width: '100%',
                                        padding: '1rem',
                                        border: '2px solid #dee2e6',
                                        borderRadius: '15px',
                                        fontSize: '1rem',
                                        color: '#2d3748',
                                        transition: 'all 0.3s ease',
                                        outline: 'none'
                                    }}
                                    onFocus={(e) => {
                                        const target = e.target as HTMLInputElement;
                                        target.style.borderColor = '#f97316';
                                        target.style.boxShadow = '0 0 0 3px rgba(249, 115, 22, 0.1)';
                                    }}
                                    onBlur={(e) => {
                                        const target = e.target as HTMLInputElement;
                                        target.style.borderColor = '#dee2e6';
                                        target.style.boxShadow = 'none';
                                    }}
                                />
                            </div>

                            {/* Nome Field */}
                            <div>
                                <label htmlFor="nome" style={{
                                    display: 'block',
                                    fontSize: '1.1rem',
                                    fontWeight: '600',
                                    marginBottom: '0.5rem',
                                    color: '#1e3a8a'
                                }}>
                                    👤 Nome:
                                </label>
                                <input
                                    type="text"
                                    id="nome"
                                    name="nome"
                                    value={participante.nome}
                                    onChange={handleInputChange}
                                    required
                                    style={{
                                        width: '100%',
                                        padding: '1rem',
                                        border: '2px solid #dee2e6',
                                        borderRadius: '15px',
                                        fontSize: '1rem',
                                        color: '#2d3748',
                                        transition: 'all 0.3s ease',
                                        outline: 'none'
                                    }}
                                    onFocus={(e) => {
                                        const target = e.target as HTMLInputElement;
                                        target.style.borderColor = '#f97316';
                                        target.style.boxShadow = '0 0 0 3px rgba(249, 115, 22, 0.1)';
                                    }}
                                    onBlur={(e) => {
                                        const target = e.target as HTMLInputElement;
                                        target.style.borderColor = '#dee2e6';
                                        target.style.boxShadow = 'none';
                                    }}
                                />
                            </div>

                            {/* Sobrenome Field */}
                            <div>
                                <label htmlFor="sobre_nome" style={{
                                    display: 'block',
                                    fontSize: '1.1rem',
                                    fontWeight: '600',
                                    marginBottom: '0.5rem',
                                    color: '#1e3a8a'
                                }}>
                                    👥 Sobrenome:
                                </label>
                                <input
                                    type="text"
                                    id="sobre_nome"
                                    name="sobre_nome"
                                    value={participante.sobre_nome}
                                    onChange={handleInputChange}
                                    required
                                    style={{
                                        width: '100%',
                                        padding: '1rem',
                                        border: '2px solid #dee2e6',
                                        borderRadius: '15px',
                                        fontSize: '1rem',
                                        color: '#2d3748',
                                        transition: 'all 0.3s ease',
                                        outline: 'none'
                                    }}
                                    onFocus={(e) => {
                                        const target = e.target as HTMLInputElement;
                                        target.style.borderColor = '#f97316';
                                        target.style.boxShadow = '0 0 0 3px rgba(249, 115, 22, 0.1)';
                                    }}
                                    onBlur={(e) => {
                                        const target = e.target as HTMLInputElement;
                                        target.style.borderColor = '#dee2e6';
                                        target.style.boxShadow = 'none';
                                    }}
                                />
                            </div>

                            {/* Data de Nascimento Field */}
                            <div>
                                <label htmlFor="data_nascimento" style={{
                                    display: 'block',
                                    fontSize: '1.1rem',
                                    fontWeight: '600',
                                    marginBottom: '0.5rem',
                                    color: '#1e3a8a'
                                }}>
                                    🎂 Data de Nascimento:
                                </label>
                                <input
                                    type="date"
                                    id="data_nascimento"
                                    name="data_nascimento"
                                    value={formatDateForInput(participante.data_nascimento)}
                                    onChange={handleInputChange}
                                    required
                                    style={{
                                        width: '100%',
                                        padding: '1rem',
                                        border: '2px solid #dee2e6',
                                        borderRadius: '15px',
                                        fontSize: '1rem',
                                        color: '#2d3748',
                                        transition: 'all 0.3s ease',
                                        outline: 'none'
                                    }}
                                    onFocus={(e) => {
                                        const target = e.target as HTMLInputElement;
                                        target.style.borderColor = '#f97316';
                                        target.style.boxShadow = '0 0 0 3px rgba(249, 115, 22, 0.1)';
                                    }}
                                    onBlur={(e) => {
                                        const target = e.target as HTMLInputElement;
                                        target.style.borderColor = '#dee2e6';
                                        target.style.boxShadow = 'none';
                                    }}
                                />
                            </div>

                            {/* Sexo Field */}
                            <div>
                                <label htmlFor="pf_sexo" style={{
                                    display: 'block',
                                    fontSize: '1.1rem',
                                    fontWeight: '600',
                                    marginBottom: '0.5rem',
                                    color: '#1e3a8a'
                                }}>
                                    ⚧ Sexo:
                                </label>
                                <select
                                    id="pf_sexo"
                                    name="pf_sexo"
                                    value={participante.pf_sexo}
                                    onChange={handleInputChange}
                                    required
                                    style={{
                                        width: '100%',
                                        padding: '1rem',
                                        border: '2px solid #dee2e6',
                                        borderRadius: '15px',
                                        fontSize: '1rem',
                                        color: '#2d3748',
                                        backgroundColor: 'white',
                                        transition: 'all 0.3s ease',
                                        outline: 'none'
                                    }}
                                    onFocus={(e) => {
                                        const target = e.target as HTMLSelectElement;
                                        target.style.borderColor = '#f97316';
                                        target.style.boxShadow = '0 0 0 3px rgba(249, 115, 22, 0.1)';
                                    }}
                                    onBlur={(e) => {
                                        const target = e.target as HTMLSelectElement;
                                        target.style.borderColor = '#dee2e6';
                                        target.style.boxShadow = 'none';
                                    }}
                                >
                                    {module.tipo_sexo.map((sexo) => (
                                        <option key={sexo.pf_sexo} value={sexo.pf_sexo}>
                                            {sexo.pf_sexo_descricao}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            {message && (
                                <div style={{
                                    padding: '1rem',
                                    borderRadius: '15px',
                                    textAlign: 'center',
                                    fontWeight: '600',
                                    background: message.includes('sucesso') ? '#d1fae5' : '#fef2f2',
                                    color: message.includes('sucesso') ? '#065f46' : '#dc2626',
                                    border: `2px solid ${message.includes('sucesso') ? '#10b981' : '#ef4444'}`
                                }}>
                                    {message.includes('sucesso') ? '✅' : '❌'} {message}
                                </div>
                            )}

                            <button
                                type="submit"
                                disabled={loading || (participante.crm_seq > 0)}
                                style={{
                                    width: '100%',
                                    background: (loading || participante.crm_seq > 0) ? '#9ca3af' : 'linear-gradient(45deg, #f97316, #fb923c)',
                                    color: 'white',
                                    border: 'none',
                                    padding: '1rem 2rem',
                                    borderRadius: '25px',
                                    fontSize: '1.1rem',
                                    fontWeight: 'bold',
                                    cursor: (loading || participante.crm_seq > 0) ? 'not-allowed' : 'pointer',
                                    transition: 'all 0.3s ease',
                                    marginTop: '1rem',
                                    opacity: (participante.crm_seq > 0) ? 0.6 : 1
                                }}
                                onMouseOver={(e) => {
                                    if (!loading && participante.crm_seq === 0) {
                                        const target = e.target as HTMLButtonElement;
                                        target.style.transform = 'scale(1.02)';
                                        target.style.boxShadow = '0 5px 15px rgba(249, 115, 22, 0.3)';
                                    }
                                }}
                                onMouseOut={(e) => {
                                    if (!loading && participante.crm_seq === 0) {
                                        const target = e.target as HTMLButtonElement;
                                        target.style.transform = 'scale(1)';
                                        target.style.boxShadow = 'none';
                                    }
                                }}
                            >
                                {loading ? '⏳ Cadastrando...' : 
                                participante.crm_seq > 0 ? '✅ Obrigado por fazer parte de nossa base de dados!' : 
                                'Registrar acesso'}
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}