'use client';

import { useState, useCallback, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { useAuth } from '../../context/context';

interface ServicoDisponivel {
  id: string;
  nome: string;
  descricao: string;
  icone: string;
  ativo: boolean;
  url?: string;
}

export default function ClienteHomePage() {
  const [navegando, setNavegando] = useState(false);
  const router = useRouter();
  const { user, cliente, logout } = useAuth();


  // useEffect para console.log
  useEffect(() => {
    console.log('Dados do usuário:', user);
    console.log('Dados do cliente:', cliente);
    console.log('Data de cadastro:', cliente?.crm_dt_cadastro);
  }, [user, cliente]);

  // Lista de serviços disponíveis
  const [servicosDisponiveis] = useState<ServicoDisponivel[]>([
    {
      id: 'perfil',
      nome: 'Meu Perfil',
      descricao: 'Visualizar e editar informações pessoais',
      icone: '👤',
      ativo: true,
      url: '/pages/home/perfil'
    },
    {
      id: 'sorteios',
      nome: 'Sorteios',
      descricao: 'Consultar sorteios disponíveis',
      icone: '🎉',
      ativo: true,
      url: '/pages/home/sorteio'
    },
    {
      id: 'sac',
      nome: 'SAC',
      descricao: 'Abrir chamados e solicitar ajuda',
      icone: '🎧',
      ativo: true,
      url: '/cliente/suporte'
    },
  ]);

  const handleServicoClick = useCallback(async (servico: ServicoDisponivel) => {
    if (navegando || !servico.ativo || !servico.url) return;
    
    try {
      setNavegando(true);
      const url = `${servico.url}?email=${encodeURIComponent(cliente?.crm_email || '')}`;
      
      const isMobile = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);
      
      await router.push(url);
      /*if (isMobile) {
        window.location.replace(url);
      } else {
        await router.push(url);
      }*/
    } catch (error) {
      console.error('Erro na navegação:', error);
      window.location.replace(`${servico.url}?email=${encodeURIComponent(cliente?.crm_email || '')}`);
    } finally {
      setTimeout(() => setNavegando(false), 2000);
    }
  }, [navegando, cliente?.crm_email, router]);

  const handleLogout = useCallback(() => {
    logout();
    window.location.replace('/login');
  }, [logout]);

  // Verificar se usuário está logado e cliente carregado
  if (user.autorizado == 0) {
    return (
      <div className="min-h-screen bg-gradient-to-br from-purple-50 to-blue-50 flex items-center justify-center">
        <div className="text-center">
          <div className="animate-spin rounded-full h-16 w-16 border-4 border-purple-500 border-t-transparent mx-auto mb-4"></div>
          <p className="text-gray-600 font-medium">Carregando dados...</p>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-purple-50 to-blue-50">
      {/* Header */}
      <header className="bg-white shadow-sm border-b">
        <div className="max-w-7xl mx-auto px-4 py-4">
          <div className="flex justify-between items-center">
            <div className="flex items-center space-x-4">
              <div className="bg-purple-100 rounded-full p-3">
                <span className="text-purple-600 text-xl">👤</span>
              </div>
              <div>
                <h1 className="text-xl font-bold text-gray-800">
                  Olá, {cliente?.nome} {cliente?.sobre_nome}!
                </h1>
                <p className="text-sm text-gray-600">{cliente?.crm_email}</p>
              </div>
            </div>
            <button 
              onClick={handleLogout}
              className="text-gray-500 hover:text-gray-700 text-sm flex items-center gap-2 touch-manipulation"
              style={{ WebkitTapHighlightColor: 'transparent' }}
            >
              <span>🚪</span>
              Sair
            </button>
          </div>
        </div>
      </header>

      {/* Main Content */}
      <main className="max-w-7xl mx-auto px-4 py-8">
        
        {/* Welcome Section */}
        <div className="bg-white rounded-lg shadow-sm border p-6 mb-8">
          <h2 className="text-lg font-semibold text-gray-800 mb-2">
            Bem-vindo ao Portal do Cliente
          </h2>
          <p className="text-gray-600">
            Acesse os serviços disponíveis para sua conta. Em caso de dúvidas, entre em contato com nosso suporte.
          </p>
        </div>

        {/* Services Grid */}
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
          {servicosDisponiveis.map((servico) => (
            <div
              key={servico.id}
              onClick={() => handleServicoClick(servico)}
              className={`
                bg-white rounded-lg shadow-sm border p-6 transition-all duration-200 
                touch-manipulation select-none
                ${servico.ativo && !navegando
                  ? 'hover:shadow-md hover:border-purple-200 cursor-pointer hover:scale-105 active:scale-95' 
                  : 'opacity-50 cursor-not-allowed'
                }
              `}
              style={{ WebkitTapHighlightColor: 'transparent' }}
            >
              <div className="text-center">
                <div className={`
                  text-4xl p-4 rounded-lg mx-auto w-fit mb-4
                  ${servico.ativo ? 'bg-purple-100' : 'bg-gray-100'}
                `}>
                  {servico.icone}
                </div>
                <h3 className="font-semibold text-gray-800 mb-2">
                  {servico.nome}
                </h3>
                <p className="text-xs text-gray-600 mb-4 line-clamp-2">
                  {servico.descricao}
                </p>
                <div className="flex flex-col items-center space-y-2">
                  <span className={`
                    text-xs px-3 py-1 rounded-full
                    ${servico.ativo 
                      ? 'bg-green-100 text-green-800' 
                      : 'bg-gray-100 text-gray-600'
                    }
                  `}>
                    {servico.ativo ? 'Disponível' : 'Em breve'}
                  </span>
                  {servico.ativo && !navegando && (
                    <span className="text-purple-600 text-sm font-medium">
                      Acessar →
                    </span>
                  )}
                  {navegando && (
                    <span className="text-gray-500 text-sm">
                      Carregando...
                    </span>
                  )}
                </div>
              </div>
            </div>
          ))}
        </div>

        {/* Quick Stats */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          <div className="bg-white rounded-lg shadow-sm border p-4">
            <div className="flex items-center space-x-3">
              <div className="bg-blue-100 rounded-full p-2">
                <span className="text-blue-600">📊</span>
              </div>
              <div>
                <p className="text-sm text-gray-600">Status da Conta</p>
                <p className="font-semibold text-green-600">Ativa</p>
              </div>
            </div>
          </div>
          
          <div className="bg-white rounded-lg shadow-sm border p-4">
            <div className="flex items-center space-x-3">
              <div className="bg-green-100 rounded-full p-2">
                <span className="text-green-600">📅</span>
              </div>
                <div>
                  <p className="text-sm text-gray-600">Cliente desde</p>
                  <p className="font-semibold text-gray-800">
                    {cliente?.crm_dt_cadastro ? (
                      new Date(cliente.crm_dt_cadastro).toLocaleDateString('pt-BR', {
                        month: 'long', 
                        year: 'numeric' 
                      })
                    ) : (
                      'Data não disponível'
                    )}
                  </p>
                </div>
            </div>
          </div>
        </div>

      </main>

      {/* Footer */}
      <footer className="bg-white border-t mt-12">
        <div className="max-w-7xl mx-auto px-4 py-6">
          <div className="text-center text-sm text-gray-600">
            <p>© 2025 Sistema CRM. Todos os direitos reservados.</p>
            <p className="mt-1">
              Dúvidas? Entre em contato: 
              <a href="mailto:suporte@empresa.com" className="text-purple-600 hover:underline ml-1">
                suporte@empresa.com
              </a>
            </p>
          </div>
        </div>
      </footer>
    </div>
  );
}