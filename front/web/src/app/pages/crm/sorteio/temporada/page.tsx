'use client';
 
import { useState, useEffect } from 'react';
import { useAuth } from '../../../../context/context';
import { modulecrm, tpTemporada } from '@/api/m0090_crm/modulecrm';

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import ModelTemporada from './modeltemporada';


export default function TemporadasPage() {
  const [temporadas, setTemporadas] = useState<tpTemporada[]>([]);
  const [showModal, setShowModal] = useState(false);
  const [temporadaSelecionada, setTemporadaSelecionada] = useState<tpTemporada | null>(null);
  
  const [ActionStatus, setActionStatus] = useState(0);
  const [error, setError] = useState<string | null>(null);
  const [filtros, setFiltros] = useState({
    crm_so_temp_descricao: '',
    valor_minimo: '',
    data_ini: '',
    data_fim: '',
    apenas_ativa: false
  });

  const { user } = useAuth();

  useEffect(() => {
    carregarTemporadas();
  }, []);

  const carregarTemporadas = async () => {
    try {

      setTemporadaSelecionada(null)
      setActionStatus(1);
      setError(null);
      
      if (!user) {
        setError('Usuário não autenticado');
        return;
      }


      const crm = new modulecrm(user);
      const dados = await crm.AdmSorteio.getTemporada({
        ...(filtros.apenas_ativa && { crm_so_temp_status: 1 }),
        ...(filtros.crm_so_temp_descricao && { crm_so_temp_descricao: filtros.crm_so_temp_descricao })
      });
      setTemporadas(dados);
      
    } catch (err) {
        if (err instanceof Error) {
        setError(`Erro ao carregar temporadas: ${err.message}`);
        } else {
        setError('Erro ao carregar temporadas');
        }

    } finally {
      setActionStatus(0);
    }
  };

  const handleEditarTemporada = (temporada: tpTemporada) => {
    setTemporadaSelecionada(temporada);
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setTemporadaSelecionada(null);
  };

  const handleSalvarTemporada = () => {
    // Recarrega a lista após salvar
    carregarTemporadas();
    handleCloseModal();
  };

  const formatarData = (data: Date) => {
    return new Date(data).toLocaleDateString('pt-BR');
  };

  const formatarMoeda = (valor: number) => {
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    }).format(valor);
  };

  const getStatusText = (status: number) => {
    switch (status) {
      case 1: return 'Ativa';
      case 2: return 'Finalizada';
      case 0: return 'Inativa';
      default: return 'Indefinido';
    }
  };

  const getStatusClass = (status: number) => {
    switch (status) {
      case 1: return 'bg-green-100 text-green-800';
      case 2: return 'bg-blue-100 text-blue-800';
      case 0: return 'bg-red-100 text-red-800';
      default: return 'bg-gray-100 text-gray-800';
    }
  };

  return (
    <div className="min-h-screen bg-gray-50 p-4">
      <div className="max-w-7xl mx-auto">
        
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="CRM | Temporadas de Sorteios" >
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={carregarTemporadas} ></ButtonPag>
          </div>
        </HeaderMain>

        {/* Filtros */}
        <div className="bg-white rounded-lg shadow-sm border p-4 mb-4">
          <h2 className="text-sm font-medium text-gray-700 mb-3">Filtros</h2>
          
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-3">
            {/* Descrição */}
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">
                Descrição
              </label>
              <input
                type="text"
                value={filtros.crm_so_temp_descricao}
                onChange={(e) => setFiltros({...filtros, crm_so_temp_descricao: e.target.value})}
                className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500 focus:border-purple-500"
                placeholder="Digite a descrição..."
              />
            </div>

        

            {/* Status */}
           <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">
                Status
              </label>
              <div className="flex items-center mt-2">
                <input
                  type="checkbox"
                  id="apenas_ativa"
                  checked={filtros.apenas_ativa}
                  onChange={(e) => setFiltros({...filtros, apenas_ativa: e.target.checked})}
                  className="h-4 w-4 text-purple-600 focus:ring-purple-500 border-gray-300 rounded"
                />
                <label htmlFor="apenas_ativa" className="ml-2 text-xs text-gray-700">
                  Apenas ativa
                </label>
              </div>
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
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700 tracking-wider border-r border-gray-200">
                    Código
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700 tracking-wider border-r border-gray-200">
                    Descrição
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700 tracking-wider border-r border-gray-200">
                    Valor Mínimo
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700 tracking-wider border-r border-gray-200">
                    Data Início
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700 tracking-wider border-r border-gray-200">
                    Data Fim
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700 tracking-wider border-r border-gray-200">
                    Status
                  </th>
                  <th className="px-3 py-2 text-left text-xs font-medium text-gray-700 tracking-wider">
                    Ações
                  </th>
                </tr>
              </thead>
              <tbody className="bg-white">
              
                {temporadas.length > 0 ? (
                  temporadas.map((temporada, index) => (
                    <tr 
                      key={temporada.crm_so_temp_cd} 
                      className={`${index % 2 === 0 ? 'bg-white' : 'bg-gray-50'} hover:bg-purple-50 transition-colors duration-150`}
                    >
                      <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                        {temporada.crm_so_temp_cd}
                      </td>
                      <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                        {temporada.crm_so_temp_descricao}
                      </td>
                      <td className="px-3 py-2 text-xs font-mono text-gray-900 border-r border-gray-200">
                        {formatarMoeda(temporada.crm_so_temp_valor_minimo)}
                      </td>
                      <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                        {formatarData(temporada.crm_so_temp_data_ini)}
                      </td>
                      <td className="px-3 py-2 text-xs text-gray-900 border-r border-gray-200">
                        {formatarData(temporada.crm_so_temp_data_fim)}
                      </td>
                      <td className="px-3 py-2 text-xs border-r border-gray-200">
                        <span className={`inline-flex px-2 py-1 text-xs font-medium rounded ${getStatusClass(temporada.crm_so_temp_status)}`}>
                          {getStatusText(temporada.crm_so_temp_status)}
                        </span>
                      </td>
                      <td className="px-3 py-2 text-xs text-gray-900">
                        <div className="flex space-x-1">
                          <button 
                            className="text-blue-600 hover:text-blue-800 font-medium"
                            title="Editar"
                            onClick={() => handleEditarTemporada(temporada)}
                          >
                            Editar
                          </button>
                          <span className="text-gray-300">|</span>
                          <button 
                            className="text-green-600 hover:text-green-800 font-medium"
                            title="Ver Sorteios"
                          >
                            Sorteios
                          </button>
                        </div>
                      </td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan={7} className="px-3 py-8 text-center text-gray-500 text-sm">
                      Nenhuma temporada encontrada.
                    </td>
                  </tr>
                )}
              
              </tbody>
            </table>
          </div>

          {/* Estado vazio */}
          {temporadas.length === 0 && ActionStatus !== 1 && (
            <div className="text-center py-8">
              <p className="text-gray-500 text-sm">Nenhuma temporada encontrada.</p>
            </div>
          )}
        </div>

        {/* Footer com total */}
        <div className="mt-3 text-xs text-gray-600 text-center">
          Total de Temporadas: {temporadas.length}
        </div>

        {/* Modal de Temporada */}
        {showModal && temporadaSelecionada && (
          <ModelTemporada
            temporada={temporadaSelecionada}
            onClose={handleCloseModal}
            onSave={handleSalvarTemporada}
          />
        )}

      </div>
    </div>
  );
}