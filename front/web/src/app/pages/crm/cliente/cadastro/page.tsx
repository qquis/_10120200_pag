'use client';

import { useState, useEffect } from 'react';
import { useAuth } from '../../../../context/context';
import { modulecrm, tpParticipante_Crm } from '@/api/m0090_crm/modulecrm';


/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

export default function ClientesPage() {
  const [clientes, setClientes] = useState<tpParticipante_Crm[]>([]);
  
  const [ActionStatus, setActionStatus] = useState(0);
  const [error, setError] = useState<string | null>(null);
  const [filtros, setFiltros] = useState({
    nome: '',
    email: '',
    cpf: '',
    status: 'todos'
  });

  const { user } = useAuth();

  useEffect(() => {
    carregarClientes();
  }, []);

  const carregarClientes = async () => {
    try {
      setActionStatus(1);
      setError(null);
      
      if (!user) {
        setError('Usuário não autenticado');
        return;
      }

      const crm = new modulecrm(user);
      const dados = await crm.getcliente({});
      setClientes(dados);
      
    } catch (err) {
      setError('Erro ao carregar clientes');
      console.error('Erro:', err);
    } finally {
      setActionStatus(0);
    }
  };



  const formatarData = (data: Date) => {
    return new Date(data).toLocaleDateString('pt-BR');
  };

  const getStatusText = (status: number) => {
    switch (status) {
      case 1: return 'Inicializado';
      case 2: return 'Concluído';
      case 9: return 'Concluído';
      default: return 'Indefinido';
    }
  };

  
  return (
    <div className="min-h-screen bg-gray-50 p-4">
      <div className="max-w-7xl mx-auto">
        
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="CRM | Clientes" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={carregarClientes} ></ButtonPag>
          </div>
        </HeaderMain>


        {/* Filtros */}
        <div className="bg-white rounded-lg shadow-sm border p-4 mb-4">
          <h2 className="text-sm font-medium text-gray-700 mb-3">Filtros</h2>
          
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-5 gap-3">
            {/* Nome */}
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">
                Nome
              </label>
              <input
                type="text"
                value={filtros.nome}
                onChange={(e) => setFiltros({...filtros, nome: e.target.value})}
                className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500 focus:border-purple-500"
                placeholder="Digite o nome..."
              />
            </div>

            {/* Email */}
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">
                Email
              </label>
              <input
                type="text"
                value={filtros.email}
                onChange={(e) => setFiltros({...filtros, email: e.target.value})}
                className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500 focus:border-purple-500"
                placeholder="Digite o email..."
              />
            </div>

            {/* CPF */}
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">
                CPF
              </label>
              <input
                type="text"
                value={filtros.cpf}
                onChange={(e) => setFiltros({...filtros, cpf: e.target.value})}
                className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500 focus:border-purple-500"
                placeholder="Digite o CPF..."
              />
            </div>

            {/* Status */}
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">
                Status
              </label>
              <select
                value={filtros.status}
                onChange={(e) => setFiltros({...filtros, status: e.target.value})}
                className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500 focus:border-purple-500"
              >
                <option value="0">TODOS</option>
                <option value="1">Inicializado</option>
                <option value="2">Concluído</option>
                <option value="9">Inativo</option>
              </select>
            </div>

            {/* Placeholder para manter o grid alinhado */}
            <div></div>
          </div>
        </div>

        {/* Mensagem de erro */}
        {error && (
          <div className="bg-red-50 border border-red-200 rounded-lg p-3 mb-4">
            <div className="flex items-center">
              <span className="text-red-500 mr-2 text-sm">⚠️</span>
              <span className="text-red-800 font-medium text-sm">{error}</span>
            </div>
          </div>
        )}



        {/* Tabela principal */}
        <div className="bg-white rounded-b-lg shadow-sm border overflow-hidden">
          <div className="overflow-x-auto">
            <table className="min-w-full">
              <thead className="bg-gray-100">
                <tr>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700  tracking-wider border-r border-gray-200">
                    Seq
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700  tracking-wider border-r border-gray-200">
                    Nome
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700  tracking-wider border-r border-gray-200">
                    Email
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700  tracking-wider border-r border-gray-200">
                    CPF
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700  tracking-wider border-r border-gray-200">
                    Nascimento
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700  tracking-wider border-r border-gray-200">
                    Sexo
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700  tracking-wider border-r border-gray-200">
                    Status
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700  tracking-wider">
                    Dt. Cadastro
                  </th>
                </tr>
              </thead>
              <tbody className="bg-white">
                {clientes.map((cliente, index) => (
                  <tr 
                    key={cliente.crm_seq} 
                    className={`${index % 2 === 0 ? 'bg-white' : 'bg-gray-50'} hover:bg-purple-50 transition-colors duration-150`}
                  >
                    <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                      {cliente.crm_seq}
                    </td>
                    <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                      {cliente.nome} {cliente.sobre_nome}
                    </td>
                    <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                      {cliente.crm_email}
                    </td>
                    <td className="px-3 py-2 text-xs font-mono text-gray-900 border-r border-gray-200">
                      {cliente.cpf}
                    </td>
                    <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                      {formatarData(cliente.data_nascimento)}
                    </td>
                    <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                      {cliente.pf_sexo === 'M' ? 'M' : 'F'}
                    </td>
                    <td className="px-3 py-2 text-xs border-r border-gray-200">
                      <span className={`inline-flex px-2 py-1 text-xs font-medium rounded ${
                        cliente.crm_status_cd === 1 
                          ? 'bg-green-100 text-green-800' 
                          : 'bg-red-100 text-red-800'
                      }`}>
                        {getStatusText(cliente.crm_status_cd)}
                      </span>
                    </td>
                    <td className="px-3 py-2 text-xs text-gray-900">
                      {formatarData(cliente.crm_dt_cadastro)}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          {/* Estado vazio */}
          {clientes.length === 0 && !(ActionStatus == 0) && (
            <div className="text-center py-8">
              <p className="text-gray-500 text-sm">Nenhum registro encontrado.</p>
            </div>
          )}
        </div>

        {/* Footer com total */}
        <div className="mt-3 text-xs text-gray-600 text-center">
          Total de Registros: {clientes.length}
        </div>

      </div>
    </div>
  );
}