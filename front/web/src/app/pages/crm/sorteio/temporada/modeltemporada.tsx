'use client';

import { useState, useEffect } from 'react';
import { useAuth } from '../../../../context/context';
import { modulecrm, tpTemporada, tpSorteio, tpsorteio_numero_cupom } from '@/api/m0090_crm/modulecrm';
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";



interface ModelTemporadaProps {
  temporada?: tpTemporada;
  temporadaId?: number;
  onClose: () => void;
  onSave?: (temporada: tpTemporada) => void;
}

export default function ModelTemporada({ temporada: temporadaProp, temporadaId, onClose }: ModelTemporadaProps) {
  const [temporada, setTemporada] = useState<tpTemporada>({
    crm_so_temp_cd: 0,
    crm_so_temp_descricao: '',
    crm_so_temp_valor_minimo: 0,
    crm_so_temp_status: 0,
    crm_so_temp_data_ini: new Date(),
    crm_so_temp_data_fim: new Date()
  });

  const [listSorteios, setListSorteios] = useState<tpSorteio[]>([]);
  const [listNumerosCupom, setListNumerosCupom] = useState<tpsorteio_numero_cupom[]>([]);
  
  const [filtrosCupom, setFiltrosCupom] = useState({
    status_envio_sorteio: "0",
    cpf_cnpj: '',
    numero_cupom: '',
    nf_chave: '',
    crm_so_cpf: '',
    limit: 5000, 
    data: new Date().toISOString().split('T')[0] // Formato YYYY-MM-DD para input date
  });

  const [ActionStatus, setActionStatus] = useState(0);
  const [error, setError] = useState<string | null>(null);
  const { user } = useAuth();

  const crm = new modulecrm(user!);

  useEffect(() => {
    if (temporadaProp) {
      setTemporada(temporadaProp);
      BindingSorteiosDaTemporada(temporadaProp);
    } else if (temporadaId && temporadaId > 0) {
      BindingTemporadas();
    }
  }, [temporadaProp, temporadaId, user]);

  const BindingTemporadas = async () => {
    try {
      setActionStatus(1);
      setError(null);
      
      if (!user) {
        setError('Usuário não autenticado');
        return;
      }

      const dados = await crm.AdmSorteio.getTemporada({
        crm_so_temp_cd: temporadaId
      });

      if (dados && dados.length > 0) {
        setTemporada(dados[0]);


        await BindingSorteiosDaTemporada(temporada);
                  setFiltrosCupom({ 
    ...filtrosCupom, 
    data: dados[0].crm_so_temp_data_ini instanceof Date 
      ? dados[0].crm_so_temp_data_ini.toISOString().split('T')[0] 
      : new Date(dados[0].crm_so_temp_data_ini).toISOString().split('T')[0] 
  });
      }
      
    } catch (err) {
      if (err instanceof Error) {
        setError(`Erro ao carregar temporada: ${err.message}`);
      } else {
        setError('Erro ao carregar temporada');
      }
    } finally {
      setActionStatus(0);
    }
  };


  
  const BindingSorteiosDaTemporada = async (value: tpTemporada) => {
  
    try { 
   
        const resultlistSorteio : tpSorteio[] = await crm.AdmSorteio.getSorteios({crm_so_temp_cd: value.crm_so_temp_cd});
        setListSorteios(resultlistSorteio);

    } catch (e) { 
        throw e
    }


 }

  const BindingNumerosCupomDaTemporada = async (value: tpTemporada) => {
    try { 
      setActionStatus(1);
      const parametros = {
        crm_so_temp_cd: value.crm_so_temp_cd,
        ...filtrosCupom
      };
      console.log('Parâmetros para consultar cupom:', parametros);
      
      const resultlistNumeroCupom: tpsorteio_numero_cupom[] = await crm.AdmSorteio.getConsultarCupom(parametros);
      setListNumerosCupom(resultlistNumeroCupom);
    } catch (e) { 
      setError('Erro ao carregar números/cupons');
      throw e;
    } finally {
      setActionStatus(0);
    }   
  };


  const ExportarTemporada = async () => {
    try {
      setActionStatus(1);
      const dataFormatada = filtrosCupom.data || new Date().toISOString().split('T')[0];
      const result = await crm.AdmSorteio.ExportarCupons({ data_emissao: dataFormatada });
      
      setError(result.message);
    } catch (e) {
      setError('Erro ao processar temporada/números de sorteio');
    } finally {
      await handleFiltrarCupons();
      setActionStatus(0);
    }
  };

    const ExportarCupomIndividual = async (numeroCupom: tpsorteio_numero_cupom) => {
    try {
      setActionStatus(1);
        const dataFormatada = filtrosCupom.data || new Date().toISOString().split('T')[0];
      const result = await crm.AdmSorteio.ExportarCupons({ 
        crm_so_cupom_seq: numeroCupom.crm_so_cupom_seq,
        data_emissao: dataFormatada
      });
      setError(`Exportação individual: ${result.message}`);
    } catch (e) {
      setError('Erro ao exportar cupom individual');
    } finally {
      await handleFiltrarCupons();
      setActionStatus(0);
    }
  };


  const AtualizarBase = async () => {
    try {
      setActionStatus(1);
     const dataFormatada = filtrosCupom.data || new Date().toISOString().split('T')[0];
     const result = await crm.AdmSorteio.TemporadaAtivaAtualizarBase({ data_emissao: dataFormatada });

      setError(result.message);
    } catch (e) {
      setError('Erro ao processar temporada/números de sorteio');
    } finally {
      setActionStatus(0);
    }
  };
  const handleFiltrarCupons = () => {
    if (temporada.crm_so_temp_cd > 0) {
      BindingNumerosCupomDaTemporada(temporada);
    }
  };

  const formatarCPF_CNPJ = (documento: string) => {
    if (!documento) return '';
    
    // Remove caracteres não numéricos
    const numeros = documento.replace(/\D/g, '');
    
    //if (numeros.length === 11) {
      // CPF: 000.000.000-00
     // return numeros.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');
    //} else if (numeros.length === 14) {
      // CNPJ: 00.000.000/0000-00
      //return numeros.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5');
   // }
    
    return documento;
  };

  const formatarData = (data: Date | string | null | undefined) => {
    if (!data) return 'Não definida';
    
    try {
      const dataObj = typeof data === 'string' ? new Date(data) : data;
      return dataObj.toLocaleDateString('pt-BR');
    } catch {
      return 'Data inválida';
    }
  };

  const formatarMoeda = (valor: number) => {
    if (!valor || isNaN(valor)) return 'R$ 0,00';
    
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

      <div className="p6">
        
        <HeaderMain 
          tipo={"_PAGE"} 
          ActionStatus={ActionStatus} 
          header_title={`CRM | Temporada: ${temporada.crm_so_temp_descricao || 'Nova Temporada'}`}
        >
          <div className="flex space-x-2">
            <ButtonPag 
              TypeButton="_BUTTON_HEADER" 
              label="fechar" 
              TypeIcon='_VOLTAR' 
              title="Voltar para listagem" 
              onClick={onClose}
            />
          </div>
        </HeaderMain>

        {/* Mensagem de erro */}
        {error && (
          <div className="bg-red-50 border border-red-200 rounded-lg p-3 mb-4">
            <div className="flex items-center">
              <span className="text-red-700 text-sm">{error}</span>
            </div>
          </div>
        )}

        {/* Layout principal com card da temporada e tabela lado a lado */}
        <div className="grid grid-cols-1 lg:grid-cols-4 gap-6">
          
          {/* Card principal com informações da temporada - coluna da esquerda */}
          <div className="lg:col-span-1">
            <div className="bg-white rounded-lg shadow-lg border p-3 hover:shadow-xl transition-shadow duration-300">
              <h2 className="text-sm font-semibold text-gray-800 mb-3">
                Informações da Temporada
              </h2>

              <div className="bg-gradient-to-br from-gray-50 to-gray-100 rounded-lg p-3 border shadow-inner">
                {/* Primeira linha: Código, Data Início, Data Fim */}
                <div className="grid grid-cols-3 gap-4 mb-3">
                  {/* Código */}
                  <div className="flex flex-col">
                    <label className="block text-xs font-medium text-gray-600 mb-1">
                      Código
                    </label>
                    <div className="text-xs font-semibold text-gray-900 bg-white px-2 py-1 rounded border">
                      {temporada.crm_so_temp_cd || 'Novo'}
                    </div>
                  </div>

                  {/* Data Início */}
                  <div className="flex flex-col">
                    <label className="block text-xs font-medium text-gray-600 mb-1">
                      Data Início
                    </label>
                    <div className="text-xs font-semibold text-gray-900 bg-white px-2 py-1 rounded border">
                      {formatarData(temporada.crm_so_temp_data_ini)}
                    </div>
                  </div>

                  {/* Data Fim */}
                  <div className="flex flex-col">
                    <label className="block text-xs font-medium text-gray-600 mb-1">
                      Data Fim
                    </label>
                    <div className="text-xs font-semibold text-gray-900 bg-white px-2 py-1 rounded border">
                      {formatarData(temporada.crm_so_temp_data_fim)}
                    </div>
                  </div>
                </div>

                {/* Segunda linha: Status e Valor Mínimo */}
                <div className="grid grid-cols-2 gap-4 mb-4">
                  {/* Status */}
                  <div className="flex flex-col">
                    <label className="block text-xs font-medium text-gray-600 mb-1">
                      Status
                    </label>
                    <span className={`inline-flex px-2 py-1 text-xs font-medium rounded-full w-fit ${getStatusClass(temporada.crm_so_temp_status)}`}>
                      {getStatusText(temporada.crm_so_temp_status)}
                    </span>
                  </div>

                  {/* Valor Mínimo */}
                  <div className="flex flex-col">
                    <label className="block text-xs font-medium text-gray-600 mb-1">
                      Valor Mínimo
                    </label>
                    <div className="text-sm font-bold text-green-700 bg-green-50 px-2 py-1 rounded border text-center">
                      {temporada.crm_so_temp_valor_minimo}
                    </div>
                  </div>
                </div>

                {/* Descrição ocupando toda a largura */}
                <div className="flex flex-col">
                  <label className="block text-xs font-medium text-gray-600 mb-1">
                    Descrição
                  </label>
                  <div className="text-xs text-gray-900 bg-white p-2 rounded border min-h-[40px]">
                    {temporada.crm_so_temp_descricao || 'Não informado'}
                  </div>
                </div>
              </div>
            </div>

      
          </div>

          {/* Lista de Sorteios da Temporada - colunas da direita */}
          <div className="lg:col-span-3">
            <div className="bg-white rounded-lg shadow-sm border">
              <div className="px-6 py-4 border-b border-gray-200">
                <h2 className="text-lg font-semibold text-gray-800">
                  Sorteios da Temporada
                </h2>
                <p className="text-sm text-gray-600 mt-1">
                  Total: {listSorteios.length} sorteio(s)
                </p>
              </div>

              {/* Tabela de Sorteios */}
              <div className="overflow-x-auto">
                <table className="w-full">
                  <thead className="bg-gray-50">
                    <tr>
                      <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        Código
                      </th>
                      <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        Descrição
                      </th>
                      <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        Data Início
                      </th>                      
                      <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        Data Fim
                      </th>
                      <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        Data Sorteio
                      </th>
                    </tr>
                  </thead>
                  <tbody className="bg-white divide-y divide-gray-200">
                    {listSorteios.length > 0 ? (
                      listSorteios.map((sorteio, index) => (
                        <tr 
                          key={sorteio.crm_so_cd || index} 
                          className={`${index % 2 === 0 ? 'bg-white' : 'bg-gray-50'} hover:bg-purple-50 transition-colors duration-150 cursor-pointer`}
                        >
                          <td className="px-4 py-3 text-sm text-gray-900">
                            {sorteio.crm_so_cd}
                          </td>
                          <td className="px-4 py-3 text-sm text-gray-900">
                            {sorteio.crm_so_descricao || 'Sem descrição'}
                          </td>
                          <td className="px-4 py-3 text-sm text-gray-900">
                            {formatarData(sorteio.crm_so_data_ini)}
                          </td>
                          <td className="px-4 py-3 text-sm text-gray-900">
                            {formatarData(sorteio.crm_so_data_fim)}
                          </td>
                          <td className="px-4 py-3 text-sm text-gray-900">
                            {formatarData(sorteio.crm_so_data_sorteio)}
                          </td>
                        </tr>
                      ))
                    ) : (
                      <tr>
                        <td colSpan={3} className="px-4 py-8 text-center text-gray-500 text-sm">
                          Nenhum sorteio encontrado para esta temporada.
                        </td>
                      </tr>
                    )}
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>


        {/* Lista de Números/Cupons */}
        <div className="mt-6">
          <div className="bg-white rounded-lg shadow-sm border">
<div className="px-6 py-4 border-b border-gray-200">
  <div className="flex flex-row items-end justify-between">
    {/* Título */}
    <h2 className="text-lg font-semibold text-gray-800">
      Operações
    </h2>

    {/* Controles na mesma linha */}
    <div className="flex flex-row items-end space-x-3">
      {/* Filtro de Data */}
      <div>
        <label className="block text-xs font-medium text-gray-600 mb-1">
          Data 
        </label>
        <input
          type="date"
          value={filtrosCupom.data}
          onChange={(e) => setFiltrosCupom({...filtrosCupom, data: e.target.value})}
          className="px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500"
        />
      </div>

      {/* Botão 1: Processar Vendas Pendentes */}
      <ButtonPag 
        TypeButton="_BUTTON_HEADER"
        label="Processar Vendas" 
        TypeIcon="_SALVAR" 
        title="Processar vendas pendentes da temporada" 
        onClick={async () => {await AtualizarBase() }}
      />

      {/* Botão 2: Criar Número de Sorteios */}
      <ButtonPag 
        TypeButton="_BUTTON_HEADER" 
        label="Exportar" 
        TypeIcon="_SALVAR" 
        title="Exportar" 
        onClick={() => {ExportarTemporada()}}
      />
    </div>
  </div>
</div>


            {/* Filtros */}
            <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
              <h3 className="text-sm font-medium text-gray-700 mb-3">Filtros</h3>
     

              

              
              <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-3">
                <div>
                  <label className="block text-xs font-medium text-gray-600 mb-1">
                    Sequencial Pag
                  </label>
                  <input
                    type="text"
                    value={filtrosCupom.numero_cupom}
                    onChange={(e) => setFiltrosCupom({...filtrosCupom, numero_cupom: e.target.value})}
                    className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500"
                    placeholder="Número do cupom..."
                  />
                </div>
                {/* CPF/CNPJ */}
                <div>
                  <label className="block text-xs font-medium text-gray-600 mb-1">
                    CPF/CNPJ
                  </label>
                  <input
                    type="text"
                    value={filtrosCupom.cpf_cnpj}
                    onChange={(e) => setFiltrosCupom({...filtrosCupom, cpf_cnpj: e.target.value})}
                    className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500"
                    placeholder="Digite o CPF/CNPJ..."
                  />
                </div>

                {/* Número do Cupom */}

                
                <div>
                  <label className="block text-xs font-medium text-gray-600 mb-1">
                    Número do Cupom
                  </label>
                  <input
                    type="text"
                    value={filtrosCupom.numero_cupom}
                    onChange={(e) => setFiltrosCupom({...filtrosCupom, numero_cupom: e.target.value})}
                    className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500"
                    placeholder="Número do cupom..."
                  />
                </div>

                {/* Chave NF */}
                <div>
                  <label className="block text-xs font-medium text-gray-600 mb-1">
                    Chave NF
                  </label>
                  <input
                    type="text"
                    value={filtrosCupom.nf_chave}
                    onChange={(e) => setFiltrosCupom({...filtrosCupom, nf_chave: e.target.value})}
                    className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500"
                    placeholder="Chave da NF..."
                  />
                </div>


                {/* Limite */}
                <div>
                  <label className="block text-xs font-medium text-gray-600 mb-1">
                    Limite
                  </label>
                  <select
                    value={filtrosCupom.limit}
                    onChange={(e) => setFiltrosCupom({...filtrosCupom, limit: parseInt(e.target.value)})}
                    className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500"
                  >
                    <option value={5000}>5000</option>
                  </select>
                </div>

                {/* Não Registrado */}
                <div>
                  <label className="block text-xs font-medium text-gray-600 mb-1">
                    Status de Envio
                  </label>
                  <select
                    value={filtrosCupom.status_envio_sorteio}
                    onChange={(e) => setFiltrosCupom({...filtrosCupom, status_envio_sorteio: e.target.value})}
                    className="w-full px-2 py-1 text-sm border text-black border-gray-300 rounded focus:outline-none focus:ring-1 focus:ring-purple-500"
                  >
                    <option value="99">Todos os status (99)</option>
                    <option value="0">Não enviado (0)</option>
                    <option value="1">Enviado (1)</option>
                    <option value="9">Com erro (9)</option>
                  </select>
                </div>
              </div>

              <div className="flex justify-end mt-3">
                <ButtonPag 
                  TypeButton="_BUTTON_HEADER" 
                  label="Filtrar" 
                  TypeIcon="_PESQUISAR" 
                  title="Aplicar filtros" 
                  onClick={handleFiltrarCupons}
                />
              </div>
            </div>

            {/* Tabela de Números/Cupons */}
            <div className="overflow-x-auto max-h-96 overflow-y-auto border-t">
  <table className="w-full">
                <thead className="bg-gray-50 sticky top-0 z-10">
                  <tr>
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      Exportar
                    </th>
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      Seq
                    </th>
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      N. Cupom / Número Pedido
                    </th>
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      ECF
                    </th>                    
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      Data Emissão
                    </th>
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      NF / ECF
                    </th>
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      Valor
                    </th>
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      CPF/CNPJ
                    </th>
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      Status Sort. Ext 
                    </th>                    
                    <th className="px-3 py-2 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                      Dt Envio Sort Ext.
                    </th>                                        
                  </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                  {listNumerosCupom.length > 0 ? (
                    listNumerosCupom.map((numeroCupom, index) => (
                      <tr 
                        key={`${numeroCupom.crm_so_numero_seq}-${index}`} 
                        className={`${index % 2 === 0 ? 'bg-white' : 'bg-gray-50'} hover:bg-purple-50 transition-colors duration-150`}
                      >
                        <td className="px-3 py-2 text-xs">
                            {numeroCupom.crm_so_externo_enviado === 0 ? (
                            <button
                              onClick={() => ExportarCupomIndividual(numeroCupom)}
                              className="inline-flex items-center justify-center p-1 text-xs bg-blue-600 text-white rounded hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-1 transition-colors duration-200"
                              title="Exportar este cupom"
                            >
                              <svg className="w-3 h-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 10v6m0 0l-3-3m3 3l3-3M3 17V7a2 2 0 012-2h6l2 2h6a2 2 0 012 2v10a2 2 0 01-2 2H5a2 2 0 01-2-2z" />
                              </svg>
                            </button>
                          ) : (
                            <span className="text-xs text-gray-400">-</span>
                          )}
                        </td>
                        <td className="px-3 py-2 text-xs text-gray-900">
                          {numeroCupom.crm_so_cupom_seq}
                        </td>
                        <td className="px-3 py-2 text-xs font-mono text-gray-900">
                          {numeroCupom.numero_cupom} / {numeroCupom.numero_pedido}
                        </td>
                        <td className="px-3 py-2 text-xs font-mono text-gray-900">
                          {numeroCupom.sat_ecf} 
                        </td>                        
                        <td className="px-3 py-2 text-xs text-gray-900">
                          {formatarData(numeroCupom.data_emissao)}
                        </td>
                        <td className="px-3 py-2 text-xs font-mono text-gray-900">
                          {numeroCupom.nf_numero} 
                        </td>                        
                        <td className="px-3 py-2 text-xs font-mono text-gray-900 text-right">
                          {numeroCupom.valor}
                        </td>
                        <td className="px-3 py-2 text-xs font-mono text-gray-900">
                          {formatarCPF_CNPJ(numeroCupom.cpf_cnpj)}
                        </td>
                        <td className="px-3 py-2 text-xs text-gray-900">
                          {numeroCupom.crm_so_externo_enviado === 1 ? 'Enviado' : numeroCupom.crm_so_externo_enviado === 0 ? 'Não Enviado' : 'Erro'}
                        </td>                        
                        <td className="px-3 py-2 text-xs text-gray-900">
                          {formatarData(numeroCupom.crm_so_externo_enviado_data)}
                        </td> 
                      </tr>
                    ))
                  ) : (
                    <tr>
                      <td colSpan={10} className="px-3 py-8 text-center text-gray-500 text-sm">
                        Nenhum número/cupom encontrado para esta temporada.
                      </td>
                    </tr>
                  )}

                </tbody>
              </table>

            </div>
                          <div className="px-6 py-4 border-b border-gray-200">
                <h2 className="text-lg font-semibold text-gray-800">
                  Números/Cupons da Temporada
                </h2>
                <p className="text-sm text-gray-600 mt-1">
                  Total: {listNumerosCupom.length} número(s)/cupom(ns) encontrado(s)
                </p>
              </div>
          </div>
        </div>

      </div>
 
  );
}