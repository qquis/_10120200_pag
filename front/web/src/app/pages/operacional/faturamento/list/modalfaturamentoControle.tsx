'use client';

import { useState, useEffect } from 'react';
import { useAuth } from '@/app/context/context';
import { moduleFaturamento, moduleFaturamentoControle } from '@/api/m0070_faturamento/moduleFaturamento';
import HeaderMain from '@/app/components/divs/headerMain';
import ButtonPag from '@/app/components/Buttons/button';
import { moduleForcaVenda } from '@/api/m0004_forcavenda/moduleforcavenda';
import ModalContrato from '../contrato/modalContrato';

interface ModalFaturamentoControleProps {
  numeropedido: number;
  faturamento_controle_seq: number;
  onClose: () => void;
}

// Converte a data de faturamento para YYYY-MM-DD (mesmo dia exibido na tela)
const dataFaturamentoParaIso = (valor: any): string => {
  const s = String(valor ?? '').trim();
  if (!s) return '';
  const br = s.match(/^(\d{2})\/(\d{2})\/(\d{4})/);
  if (br) return `${br[3]}-${br[2]}-${br[1]}`;
  if (/^\d{4}-\d{2}-\d{2}$/.test(s)) return s;
  const d = new Date(s);
  if (isNaN(d.getTime())) return '';
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
};

export default function ModalFaturamentoControle({
  numeropedido,
  faturamento_controle_seq,
  onClose,
}: ModalFaturamentoControleProps) {
  const __SIS_AC_CD: number = 3210;

  const { user } = useAuth();
  const [ActionStatus, setActionStatus] = useState(0);
  const [registro, setregistro] = useState<any>(null);
  const [ResumoPorFabricante, setResumoPorFabricante] = useState<any[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [listTipoContrato, setListTipoContrato] = useState<any[]>([]);
  const [listFabricante, setListFabricante] = useState<any[]>([]);
  const [fabricanteInvestimento, setFabricanteInvestimento] = useState<any>(null);

  useEffect(() => {
    const carregar = async () => {
      try {
        setActionStatus(1);
        setError(null);
        const myMODULE = new moduleFaturamento(user, __SIS_AC_CD);
        
        let parametro: any = { 
            numeropedido,
            faturamento_controle_seq,
        }
        
        try {
          const myForcaVenda = new moduleForcaVenda(user, __SIS_AC_CD);
          const [tipos, fabricantes] = await Promise.all([
            myMODULE.contrato.tipoContratoConsultar({}),
            myForcaVenda.getFabricanteFv({ fv_fabricante_status: 1 }),
          ]);
          setListTipoContrato(tipos || []);
          setListFabricante(fabricantes || []);
        } catch {
          setListTipoContrato([]);
          setListFabricante([]);
        }

        const resultado: any = await myMODULE.controle.Consultar(parametro);
        const item = Array.isArray(resultado) ? resultado[0] : resultado;


        if (!item) {
          setregistro(null);
          setError('registro.controle não encontrado.');
        } else {
          setregistro(item);

          parametro.tipo_view = 'RESUMO_POR_FABRICANTE';

          const resultadoResumo: any = await myMODULE.getList(parametro);
          setResumoPorFabricante(Array.isArray(resultadoResumo) ? resultadoResumo : [resultadoResumo]);




        }
      } catch (err) {
        setError('Erro ao carregar dados do faturamento.');
      } finally {
        setActionStatus(0);
      }
    };
    carregar();
  }, [numeropedido, faturamento_controle_seq]);

  const campo = (label: string, valor: any) => (
    <div className="bg-gray-50 rounded-lg p-3 border">
      <label className="block text-xs font-medium text-gray-500 mb-1">{label}</label>
      <div className="text-sm font-semibold text-gray-800">{valor ?? '-'}</div>
    </div>
  );

  const valor = (v: any) => user.formatNumber(v, 2, true);

  return (
    <div className="p-4">
      <HeaderMain
        tipo="_PAGE"
        ActionStatus={ActionStatus}
        header_title={`Faturamento Controle | Pedido ${numeropedido}`}
      >
        <div className="flex space-x-2">
          <ButtonPag
            TypeButton="_BUTTON_HEADER"
            label="Fechar"
            TypeIcon="_VOLTAR"
            title="Fechar consulta"
            onClick={onClose}
          />
        </div>
      </HeaderMain>

      {error && (
        <div className="bg-red-50 border border-red-200 rounded-lg p-3 mb-4">
          <span className="text-red-700 text-sm">{error}</span>
        </div>
      )}

      {registro && registro.controle && (
        <>
          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-4 mb-4">
            <h2 className="text-sm font-semibold text-purple-700 mb-2">Dados Básicos</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
              {campo('Controle / Tipo', `${registro.controle.faturamento_controle_seq} / ${registro.controle.fat_controle_tipo_descricao}`)}
              {campo('Nº Pedido / Nº FV', `${registro.controle.numeropedido} / ${registro.controle.numeropedido_fv ?? '-'}`)}
              {campo('Emissão', user.formatDateDDMMYYYY(registro.controle.dataemissao))}
              {campo('Faturamento', user.formatDateDDMMYYYY(registro.controle.datafaturamento))}
              {campo('SAT/ECF / Cupom Fiscal', `${registro.controle.sat_ecf ?? '-'} / ${registro.controle.cupomfiscal ?? '-'}`)}
              {campo('Documento Fiscal', registro.controle.df_nf_tipo_descricao)}
            </div>
          </div>

          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-4 mb-4">
            <h2 className="text-sm font-semibold text-purple-700 mb-2">Vendedor / Cliente</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              {campo('Vendedor', `${registro.controle.cdparticipante_vendedor ?? ''} - ${registro.controle.vendedor_nome_razao ?? ''}`)}
              {campo('Cliente', `${registro.controle.cdpessoabluesoft_cliente ?? ''} - ${registro.controle.cliente_nome_razao ?? ''}`)}
              {campo('Grupo Econômico', registro.controle.descricaogrupoeconomico)}
              {campo('Cód. Participante Cliente', registro.controle.cdparticipante_cliente)}
            </div>
          </div>

          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-4 mb-4">
            <h2 className="text-sm font-semibold text-purple-700 mb-2">Valores</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4">
              {campo('Valor NF', valor(registro.controle.df_valor_total))}
              {campo('Faturamento Base', valor(registro.controle.valorfaturamentobase))}
              {campo('Subsídios Correntes', valor(registro.controle.subsidioscorrentes))}
              {campo('Faturamento', valor(registro.controle.valorfaturamento))}
              {campo('Desconto Financeiro', valor(registro.controle.valortotaldescontofinanceiro))}
              {campo('Faturamento Bruto', valor(registro.controle.valorfaturamentobruto))}
              {campo('Subsídios Aplicados', valor(registro.controle.valortotalsubsidiosaplicados))}
              {campo('Faturamento Líquido', valor(registro.controle.valortotalfaturamentoliquido))}
            </div>
          </div>

          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-4 mb-4">
            <h2 className="text-sm font-semibold text-purple-700 mb-2">Venda por Fabricante</h2>
            <div className="overflow-x-auto">
              <table className="min-w-full text-sm">
                <thead>
                  <tr className="bg-purple-50 text-purple-700 text-xs">
                    <th className="px-2 py-2 text-left">Part</th>
                    <th className="px-2 py-2 text-left">Cd Blue</th>

                    <th className="px-2 py-2 text-left">Fabricante</th>
                    <th className="px-2 py-2 text-right">Faturamento Base</th>
                    <th className="px-2 py-2 text-right">Subsídios Correntes</th>
                    <th className="px-2 py-2 text-right">Faturamento</th>
                    <th className="px-2 py-2 text-right">Desc. Financeiro</th>
                    <th className="px-2 py-2 text-right">Faturamento Bruto</th>
                    <th className="px-2 py-2 text-right">Subsídios Aplicados</th>
                    <th className="px-2 py-2 text-right">Faturamento Líquido</th>
                    <th className="px-2 py-2 text-center">Investimento</th>
                  </tr>
                </thead>
                <tbody>
                  {ResumoPorFabricante.filter((r) => r).map((r, idx) => (
                    <tr key={idx} className="border-t hover:bg-gray-50">
                      <td className="px-2 py-1 font-medium text-gray-800">{r.cdparticipante || '-'}</td>
                      <td className="px-2 py-1 font-medium text-gray-800">{r.cdpessoabluesoft || '-'}</td>
                      <td className="px-2 py-1 font-medium text-gray-800">{r.fabricante_nome_razao || '-'}</td>
                      
                      <td className="px-2 py-1 text-right">{valor(r.valorfaturamentobase)}</td>
                      <td className="px-2 py-1 text-right">{valor(r.subsidioscorrentes)}</td>
                      <td className="px-2 py-1 text-right">{valor(r.valorfaturamento)}</td>
                      <td className="px-2 py-1 text-right">{valor(r.valortotaldescontofinanceiro)}</td>
                      <td className="px-2 py-1 text-right">{valor(r.valorfaturamentobruto)}</td>
                      <td className="px-2 py-1 text-right">{valor(r.valortotalsubsidiosaplicados)}</td>
                      <td className="px-2 py-1 text-right">{valor(r.valortotalfaturamentoliquido)}</td>
                      <td className="px-2 py-1 text-center">
                        <button
                          type="button"
                          className="px-2 py-1 text-xs rounded bg-purple-600 text-white hover:bg-purple-700"
                          title="Adicionar investimento (contrato) para este fabricante"
                          onClick={() => setFabricanteInvestimento(r)}
                        >
                          Adicionar investimento
                        </button>
                      </td>
                    </tr>
                  ))}
                  {ResumoPorFabricante.length === 0 && (
                    <tr>
                      <td colSpan={11} className="px-2 py-3 text-center text-gray-500">
                        Sem dados por fabricante.
                      </td>
                    </tr>
                  )}
                </tbody>
              </table>
            </div>
          </div>

          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-4 mb-4">
            <h2 className="text-sm font-semibold text-purple-700 mb-2">Itens</h2>
            <div className="overflow-x-auto">
              <table className="min-w-full text-sm">
                <thead>
                  <tr className="bg-purple-50 text-purple-700 text-xs">
                    <th className="px-2 py-2 text-left">Produto</th>
                    <th className="px-2 py-2 text-left">Cód. Bluesoft</th>
                    <th className="px-2 py-2 text-left">Descrição</th>
                    <th className="px-2 py-2 text-left">Emb. Estoque</th>
                    <th className="px-2 py-2 text-right">Fator</th>
                    <th className="px-2 py-2 text-left">Emb. Compra</th>
                    <th className="px-2 py-2 text-left">Qtde Unit</th>
                    <th className="px-2 py-2 text-left">Qtde Cmp</th>
                    
                    <th className="px-2 py-2 text-right">Faturamento Base</th>
                    <th className="px-2 py-2 text-right">Subsídios Correntes</th>
                    <th className="px-2 py-2 text-right">Faturamento</th>
                    <th className="px-2 py-2 text-right">Desc. Financeiro</th>
                    <th className="px-2 py-2 text-right">Faturamento Bruto</th>
                    <th className="px-2 py-2 text-right">Subsídios Aplicados</th>
                    <th className="px-2 py-2 text-right">Faturamento Líquido</th>
                  </tr>
                </thead>
                <tbody>
                  {(registro.itens ?? []).map((r: any, idx: number) => (
                    <tr key={idx} className="border-t hover:bg-gray-50">
                      <td className="px-2 py-1">{r.pr_cdproduto}</td>
                      <td className="px-2 py-1">{r.prb_cdprodutobluesoft}</td>
                      <td className="px-2 py-1 font-medium text-gray-800">{r.pr_descricao}</td>
                      <td className="px-2 py-1">{r.pr_embalagemestoque}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.pr_embalagemcompra_fator, 0)}</td>
                      <td className="px-2 py-1">{r.pr_embalagemcompra}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.embalagemestoqueqtde, 0)}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.embalagemcompraqtde, 2)}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.valorfaturamentobase, 2)}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.subsidioscorrentes, 2)}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.valorfaturamento, 2)}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.valortotaldescontofinanceiro, 2)}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.valorfaturamentobruto, 2)}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.valortotalsubsidiosaplicados, 2)}</td>
                      <td className="px-2 py-1 text-right">{user.formatNumber(r.valortotalfaturamentoliquido, 2)}</td>
                    </tr>
                  ))}
                  {(registro.itens ?? []).length === 0 && (
                    <tr>
                      <td colSpan={13} className="px-2 py-3 text-center text-gray-500">
                        Sem itens.
                      </td>
                    </tr>
                  )}
                </tbody>
              </table>
            </div>
          </div>
        </>
      )}

      {fabricanteInvestimento && (
        <div className="fixed inset-0 z-[60] flex items-start justify-center bg-black/50 overflow-y-auto">
          <div className="bg-white w-full max-w-3xl my-6 mx-4 rounded-lg shadow-xl">
            <ModalContrato
              key={`inv-${fabricanteInvestimento.cdpessoabluesoft}`}
              sis_ac_cd={__SIS_AC_CD}
              listTipoContrato={listTipoContrato}
              listFabricante={listFabricante}
              faturamento_controle_seq_pedido={faturamento_controle_seq}
              competencia_cd={Number(dataFaturamentoParaIso(registro?.controle?.datafaturamento).slice(0, 7).replace('-', '')) || undefined}
              data_faturamento_pedido={dataFaturamentoParaIso(registro?.controle?.datafaturamento)}
              fabricante_pedido={fabricanteInvestimento.cdpessoabluesoft}
              numeropedido_pedido={registro?.controle?.numeropedido}
              numeropedido_fv_pedido={registro?.controle?.numeropedido_fv}
              nome_razao_pedido={registro?.controle?.cliente_nome_razao}
              onClose={() => setFabricanteInvestimento(null)}
            />
          </div>
        </div>
      )}
    </div>
  );
}
