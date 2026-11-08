'use client';

import { useEffect, useState } from 'react';
import { useAuth } from '@/app/context/context';
import { moduleFaturamento } from '@/api/m0070_faturamento/moduleFaturamento';
import { moduleProdutoBluesoft } from '@/api/m0021_produtoBluesoft/moduleprodutobluesoft';
import HeaderMain from '@/app/components/divs/headerMain';
import ButtonPag from '@/app/components/Buttons/button';
import CmbOperacao from '@/app/pages/cadastro/_components/CmbOperacao/page';


interface ModalContratoProps {
  sis_ac_cd: number;
  competencia_cd?: number;
  contrato_seq?: number;
  modo?: 'consulta' | 'edicao';
  listTipoContrato: any[];
  listFabricante: any[];
  faturamento_controle_seq_pedido?: number;
  data_faturamento_pedido?: string;
  fabricante_pedido?: number | string;
  numeropedido_pedido?: number | string;
  numeropedido_fv_pedido?: number | string;
  nome_razao_pedido?: string;
  onClose: () => void;
  onSaved?: () => void;
}

const TIPO_INVESTIMENTO_PERIODO = '1';
const TIPO_INVESTIMENTO_PEDIDO = '3';

const hoje = () => new Date().toISOString().slice(0, 10);

const obterPeriodoCompetencia = (competencia_cd?: number) => {
  if (competencia_cd === undefined || !Number.isInteger(competencia_cd)) return null;

  const ano = Math.floor(competencia_cd / 100);
  const mes = competencia_cd % 100;
  if (ano < 1 || mes < 1 || mes > 12) return null;

  const mesFormatado = String(mes).padStart(2, '0');
  const ultimoDia = new Date(ano, mes, 0).getDate();
  return {
    dataInicial: `${ano}-${mesFormatado}-01`,
    dataFinal: `${ano}-${mesFormatado}-${String(ultimoDia).padStart(2, '0')}`,
  };
};

const gerarUuid = (): string => {
  const chars = 'ABCDEFGHJKLMNPQRSTUVWXYZ23456789';
  const bytes = new Uint8Array(10);
  if (typeof crypto !== 'undefined' && crypto.getRandomValues) crypto.getRandomValues(bytes);
  else for (let i = 0; i < 10; i++) bytes[i] = Math.floor(Math.random() * 256);
  return Array.from(bytes, (n) => chars[n % chars.length]).join('');
};

const inputClass =
  'w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black';

export default function ModalContrato({
  sis_ac_cd,
  competencia_cd,
  contrato_seq,
  modo = 'consulta',
  listTipoContrato,
  listFabricante,
  faturamento_controle_seq_pedido,
  data_faturamento_pedido,
  fabricante_pedido,
  numeropedido_pedido,
  numeropedido_fv_pedido,
  nome_razao_pedido,
  onClose,
  onSaved,
}: ModalContratoProps) {
  const { user } = useAuth();
  const [ActionStatus, setActionStatus] = useState(0);
  const [messageInfo, setMessageInfo] = useState('');
  const periodoCompetencia = obterPeriodoCompetencia(competencia_cd);

  const [contrato_uuid, setContratoUuid] = useState<string>(gerarUuid);
  const porPedido = !!faturamento_controle_seq_pedido && faturamento_controle_seq_pedido > 0;
  const [contrato_tipo_cd, setContratoTipoCd] = useState(porPedido ? TIPO_INVESTIMENTO_PEDIDO : '');
  const [fabricante, setFabricante] = useState(porPedido ? String(fabricante_pedido ?? '') : '');
  const [contrato_descricao, setContratoDescricao] = useState('');
  const dataFaturamentoPedido = /^\d{4}-\d{2}-\d{2}$/.test(data_faturamento_pedido ?? '') ? data_faturamento_pedido! : undefined;
  const [contrato_data, setContratoData] = useState(dataFaturamentoPedido ?? periodoCompetencia?.dataInicial ?? hoje());
  const [contrato_data_val_ini, setDataValIni] = useState(dataFaturamentoPedido ?? periodoCompetencia?.dataInicial ?? hoje());
  const [contrato_data_val_fim, setDataValFim] = useState(dataFaturamentoPedido ?? periodoCompetencia?.dataFinal ?? hoje());
  
  const [contrato_valor, setContratoValor] = useState('0');
  const [op_cdoperacao, setOpCdOperacao] = useState('');

  const [listItens, setListItens] = useState<any[]>([]);
  const [valoresItens, setValoresItens] = useState<Record<string, string>>({});
  const [loadingItens, setLoadingItens] = useState(false);

  const [filtroItens, setFiltroItens] = useState('');
  const [faturamento_controle_seq, setFaturamentoControleSeq] = useState(porPedido ? String(faturamento_controle_seq_pedido) : '0');
  const [numeropedido, setNumeropedido] = useState(porPedido ? String(numeropedido_pedido ?? '') : '');
  const [numeropedido_fv, setNumeropedidoFv] = useState(porPedido ? String(numeropedido_fv_pedido ?? '') : '');
  const [nome_razao, setNomeRazao] = useState(porPedido ? String(nome_razao_pedido ?? '') : '');
  




  const consulta = !!contrato_seq && contrato_seq > 0;
  const edicao = consulta && modo === 'edicao';
  const investimentoPeriodo = contrato_tipo_cd === TIPO_INVESTIMENTO_PERIODO;
  const exibeItens = investimentoPeriodo || (porPedido && !consulta) || (consulta && contrato_tipo_cd === TIPO_INVESTIMENTO_PEDIDO) || edicao;

  useEffect(() => {
    if (consulta || !periodoCompetencia) return;
    setContratoData(dataFaturamentoPedido ?? periodoCompetencia.dataInicial);
    setDataValIni(dataFaturamentoPedido ?? periodoCompetencia.dataInicial);
    setDataValFim(dataFaturamentoPedido ?? periodoCompetencia.dataFinal);
  }, [consulta, periodoCompetencia?.dataInicial, periodoCompetencia?.dataFinal, dataFaturamentoPedido]);

  const ratearValor = (valorStr: string, itens: any[]) => {
    const total = Number(valorStr.replace(',', '.'));
    const somaCusto = itens.reduce((acc, i) => acc + (Number(i.valor_custo) || 0), 0);
    if (!total || total <= 0 || somaCusto <= 0) {
      return Object.fromEntries(itens.map((i) => [i.prb_cdprodutobluesoft_pk, '0']));
    }
    const totalCentavos = Math.round(total * 100);
    const centavos = itens.map((i) => Math.round(((Number(i.valor_custo) || 0) / somaCusto) * totalCentavos));
    // a diferença do arredondamento vai para o item de maior custo
    const idxMaior = itens.reduce((m, i, k) => ((Number(i.valor_custo) || 0) > (Number(itens[m].valor_custo) || 0) ? k : m), 0);
    centavos[idxMaior] += totalCentavos - centavos.reduce((a, c) => a + c, 0);
    return Object.fromEntries(itens.map((i, k) => [i.prb_cdprodutobluesoft_pk, (centavos[k] / 100).toFixed(2)]));
  };

  const alterarValorContrato = (v: string) => {
    setContratoValor(v);
    if (porPedido && !consulta) setValoresItens(ratearValor(v, listItens));
  };

  const termoFiltro = filtroItens.trim().toLowerCase();
  const itensFiltrados = termoFiltro
    ? listItens.filter((i) =>
        [i.pr_cdproduto, i.prb_cdprodutobluesoft_pk, i.prb_descricao].some((v) =>
          String(v ?? '').toLowerCase().includes(termoFiltro),
        ),
      )
    : listItens;

  useEffect(() => {
    if (!consulta) return;
    let cancelado = false;
   
    const consultar = async () => {
      try {
        setActionStatus(1);
        setLoadingItens(true);
        const myModule = new moduleFaturamento(user, sis_ac_cd);
        const response = await myModule.contrato.contratoConsultar({ contrato_seq });
        const c = Array.isArray(response) ? response[0] : response;
        if (cancelado || !c) return;
        const dt = (v: any) => String(v ?? '').slice(0, 10);
        setContratoUuid(String(c.contrato_uuid ?? ''));
        setContratoTipoCd(String(c.contrato_tipo_cd ?? ''));
        setFabricante(String(c.cdparticipante_contratante ?? ''));
        setContratoDescricao(c.contrato_descricao ?? '');
        setContratoData(dt(c.contrato_data));
        setDataValIni(dt(c.contrato_data_val_ini));
        setDataValFim(dt(c.contrato_data_val_fim));
        setContratoValor(String(c.contrato_valor ?? '0'));
        setFaturamentoControleSeq(String(c.faturamento_controle_seq ?? '0'));
        setNumeropedido(String(c.numeropedido ?? ''));
        setNumeropedidoFv(String(c.numeropedido_fv ?? ''));
        setNomeRazao(String(c.nome_razao ?? ''));
        setOpCdOperacao(String(c.op_cdoperacao ?? ''));
        const itens = edicao
          ? await myModule.contrato.consultarProdutosContratoOuFornecedor({
              prb_cdpessoabluesoft_fornecedor: c.cdparticipante_contratante,
              prb_status: 1,
              apenasunitario: 1,
              contrato_seq,
            })
          : c.itens;
        // deduplica por produto blue, preservando a linha com valor lançado
        const mapaItens = new Map<string, any>();
        (Array.isArray(itens) ? itens : []).forEach((i: any) => {
          const chave = String(i.prb_cdprodutobluesoft_pk ?? i.prb_cdprodutobluesoft);
          const atual = mapaItens.get(chave);
          if (!atual || (Number(atual.valor_unitario) || 0) <= 0 && (Number(i.valor_unitario) || 0) > 0) mapaItens.set(chave, i);
        });
        const listaItens = Array.from(mapaItens.values());
        setListItens(
          listaItens.map((i: any) => ({
            ...i,
            prb_cdprodutobluesoft_pk: i.prb_cdprodutobluesoft_pk ?? i.prb_cdprodutobluesoft,
            prb_descricao: i.prb_descricao ?? i.descricao,
          })),
        );
        setValoresItens(
          Object.fromEntries(
            listaItens.map((i: any) => [
              i.prb_cdprodutobluesoft_pk ?? i.prb_cdprodutobluesoft,
              String(i.valor_unitario ?? 0),
            ]),
          ),
        );
      } catch (e) {
        if (!cancelado) setMessageInfo(edicao ? 'Erro ao consultar o contrato ou os itens.' : 'Erro ao consultar o contrato.');
      } finally {
        if (!cancelado) {
          setActionStatus(0);
          setLoadingItens(false);
        }
      }
    };
    consultar();
    return () => {
      cancelado = true;
    };
  }, [contrato_seq, edicao, modo]);

  useEffect(() => {
    if (consulta) return;
    setListItens([]);
    setValoresItens({});
    if ((!investimentoPeriodo && !porPedido) || !fabricante || fabricante === '0') return;

    let cancelado = false;
    const carregar = async () => {
      try {
        setLoadingItens(true);
        const myProduto = new moduleFaturamento(user, sis_ac_cd);
        const response = await myProduto.contrato.consultarProdutosContratoOuFornecedor(
          porPedido
            ? { prb_cdpessoabluesoft_fornecedor: fabricante, faturamento_controle_seq: faturamento_controle_seq_pedido }
            : { prb_cdpessoabluesoft_fornecedor: fabricante, prb_status: 1, apenasunitario : 1 },
        );
        if (cancelado) return;
        const lista = Array.isArray(response) ? response : [];
        if (!porPedido) {
          setListItens(lista);
        } else {
          // consolida por produto bluesoft, somando o custo
          const mapa = new Map<string, any>();
          lista.forEach((i: any) => {
            const chave = String(i.prb_cdprodutobluesoft_pk ?? i.prb_cdprodutobluesoft);
            const custo = Number(i.valor_custo) || 0;
            const atual = mapa.get(chave);
            if (atual) atual.valor_custo += custo;
            else
              mapa.set(chave, {
                ...i,
                prb_cdprodutobluesoft_pk: i.prb_cdprodutobluesoft_pk ?? i.prb_cdprodutobluesoft,
                descricao: i.descricao ?? i.pr_descricao,
                valor_custo: custo,
              });
          });
          const itens = Array.from(mapa.values());
          setListItens(itens);
          setValoresItens(ratearValor(contrato_valor, itens));
        }
      } catch (e) {
        if (!cancelado) {
          setListItens([]);
          setMessageInfo('Erro ao consultar os itens do fabricante.');
        }
      } finally {
        if (!cancelado) setLoadingItens(false);
      }
    };
    carregar();
    return () => {
      cancelado = true;
    };
  }, [contrato_tipo_cd, fabricante, faturamento_controle_seq_pedido]);

  const validar = (): string => {
    if (edicao) {
      if (!contrato_data || !contrato_data_val_ini || !contrato_data_val_fim)
        return 'Informe a data do contrato e a validade inicial e final.';
      if (contrato_data_val_ini > contrato_data_val_fim)
        return 'A validade inicial não pode ser maior que a final.';
      const itemInvalido = Object.values(valoresItens).some((v) => v !== '' && (isNaN(Number(v)) || Number(v) < 0));
      if (itemInvalido) return 'Valor unitário de investimento inválido (mínimo 0).';
      return '';
    }

    if (!contrato_tipo_cd || contrato_tipo_cd === '0') return 'Selecione o tipo de contrato.';
    if (!fabricante || fabricante === '0') return 'Selecione o fabricante.';
    if (!contrato_descricao.trim()) return 'Informe a descrição.';
    if (!contrato_data || !contrato_data_val_ini || !contrato_data_val_fim)
      return 'Informe a data do contrato e a validade inicial e final.';
    if (contrato_data_val_ini > contrato_data_val_fim)
      return 'A validade inicial não pode ser maior que a final.';
    if (
      periodoCompetencia &&
      (contrato_data_val_ini < periodoCompetencia.dataInicial ||
        contrato_data_val_ini > periodoCompetencia.dataFinal ||
        contrato_data_val_fim < periodoCompetencia.dataInicial ||
        contrato_data_val_fim > periodoCompetencia.dataFinal)
    )
      return 'As datas de validade devem estar dentro da competência selecionada.';
    const valorNum = Number(contrato_valor.replace(',', '.'));
    if (contrato_valor === '' || isNaN(valorNum) || valorNum < 0)
      return 'Valor do contrato inválido (mínimo 0).';
    if (!op_cdoperacao || op_cdoperacao === '0') return 'Selecione a operação.';
    const valorInvalido = Object.values(valoresItens).some((v) => v !== '' && (isNaN(Number(v)) || Number(v) < 0));
    if (valorInvalido) return 'Valor unitário de investimento inválido (mínimo 0).';
    return '';
  };

  const salvar = async () => {
    const erro = validar();
    setMessageInfo(erro);
    if (erro) return;

    try {
      setActionStatus(1);
      const myModule = new moduleFaturamento(user, sis_ac_cd);
      if (edicao) {
        await myModule.contrato.contratoIncluir({
          contrato_seq,
          contrato_data,
          contrato_data_val_ini,
          contrato_data_val_fim,
          itens: listItens
            .filter((i) => Number(valoresItens[i.prb_cdprodutobluesoft_pk]) > 0)
            .map((i) => ({
              pr_cdproduto: i.pr_cdproduto,
              prb_cdprodutobluesoft: i.prb_cdprodutobluesoft_pk,
              valor_unitario: Number(valoresItens[i.prb_cdprodutobluesoft_pk]),
            })),
        });
      } else {
        await myModule.contrato.contratoIncluir({
          contrato_status: 1,
          contrato_uuid,
          contrato_descricao: contrato_descricao.trim(),
          contrato_data,
          contrato_data_val_ini,
          contrato_data_val_fim,
          ...(competencia_cd ? { competencia_cd } : {}),
          contrato_valor: Number(contrato_valor.replace(',', '.')),
          contrato_tipo_cd: Number(contrato_tipo_cd),
          op_cdoperacao: Number(op_cdoperacao),
          cdparticipante_contratante: Number(fabricante),
          faturamento_controle_seq,
          itens: investimentoPeriodo || porPedido
            ? listItens
                .filter((i) => Number(valoresItens[i.prb_cdprodutobluesoft_pk]) > 0)
                .map((i) => ({
                  pr_cdproduto: i.pr_cdproduto,
                  prb_cdprodutobluesoft: i.prb_cdprodutobluesoft_pk,
                  valor_unitario: Number(valoresItens[i.prb_cdprodutobluesoft_pk]),
                }))
            : [],
        });
      }
      onSaved?.();
      onClose();
    } catch (e) {
      setMessageInfo('Erro ao incluir o contrato.');
    } finally {
      setActionStatus(0);
    }
  };

  return (
    <div className="p-4">
      <HeaderMain tipo="_PAGE" ActionStatus={ActionStatus} header_title={edicao ? `Contrato | Edição | ${contrato_seq}` : consulta ? `Contrato | Consulta | ${contrato_seq}` : 'Contrato | Novo'}>
        <div className="flex space-x-2">
          {(!consulta || edicao) && (
            <ButtonPag
              TypeButton="_BUTTON_HEADER"
              label="Salvar"
              TypeIcon="_SALVAR"
              title="Salvar contrato"
              onClick={salvar}
              ActionStatus={ActionStatus}
            />
          )}
          <ButtonPag
            TypeButton="_BUTTON_HEADER"
            label="Fechar"
            TypeIcon="_VOLTAR"
            title="Fechar"
            onClick={onClose}
          />
        </div>
      </HeaderMain>

      {messageInfo && (
        <div className="bg-red-50 border border-red-200 rounded-lg p-3 mb-4">
          <span className="text-red-700 text-sm">{messageInfo}</span>
        </div>
      )}

      <fieldset disabled={consulta && !edicao} className="bg-white rounded-lg shadow-md border border-purple-100 p-4 grid grid-cols-1 md:grid-cols-2 gap-4">
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Código do Contrato (UUID)</label>
          <input
            type="text"
            readOnly
            className={`${inputClass} bg-gray-100 text-gray-600`}
            value={contrato_uuid}
            maxLength={10}
            disabled={edicao}
          />
        </div>

        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Competência</label>
          <input
            type="text"
            className={inputClass}
            value={competencia_cd
              ? `${String(competencia_cd).slice(4, 6)}/${String(competencia_cd).slice(0, 4)}`
              : ''}
            readOnly
          />
        </div>

        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Tipo Contrato <span className="text-red-500">*</span>
          </label>
          <select
            className={inputClass}
            disabled={edicao || porPedido}
            value={contrato_tipo_cd}
            onChange={(e) => setContratoTipoCd(e.target.value)}
          >
            <option value="0">Selecione um tipo de contrato...</option>
            {listTipoContrato.map((t) => (
              <option key={t.contrato_tipo_cd} value={t.contrato_tipo_cd}>
                {t.contrato_tipo_descricao}
              </option>
            ))}
          </select>
        </div>

          <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Seq Faturamento Controle
          </label>
          <input
            type="text"
            className={inputClass}
            disabled={true}
            value={faturamento_controle_seq}
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Número do Pedido
          </label>
          <input
            type="text"
            className={inputClass}
            disabled={true}
            value={numeropedido}
            
            
          />
        </div>

        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Número do Pedido FV
          </label>
          <input
            type="text"
            className={inputClass}
            disabled={true}
            value={numeropedido_fv}
            
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Nome/Razão Social
          </label>
          <input
            type="text"
            className={inputClass}
            disabled={true}
            value={nome_razao}
          />
        </div>

        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Fabricante <span className="text-red-500">*</span>
          </label>
          <select className={inputClass} disabled={edicao || porPedido} value={fabricante} onChange={(e) => setFabricante(e.target.value)}>
            <option value="0">Selecione um fabricante...</option>
            {listFabricante.map((f) => (
              <option key={f.fv_fabricante_cdpessoabluesoft} value={f.fv_fabricante_cdpessoabluesoft}>
                {f.fv_fabricante_descricao}
              </option>
            ))}
          </select>
        </div>

        <div className="md:col-span-2">
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Descrição <span className="text-red-500">*</span>
          </label>
          <input
            type="text"
            className={inputClass}
            disabled={edicao}
            value={contrato_descricao}
            onChange={(e) => setContratoDescricao(e.target.value)}
          />
        </div>

        <div className="md:col-span-2 grid grid-cols-1 md:grid-cols-3 gap-4">
          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">Data do Contrato</label>
            <input type="date" className={inputClass} disabled={consulta && !edicao} value={contrato_data} onChange={(e) => setContratoData(e.target.value)} />
          </div>

          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">Validade Inicial</label>
            <input
              type="date"
              className={inputClass}
              min={!consulta ? periodoCompetencia?.dataInicial : undefined}
              max={!consulta ? periodoCompetencia?.dataFinal : undefined}
              value={contrato_data_val_ini}
              onChange={(e) => setDataValIni(e.target.value)}
            />
          </div>

          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">Validade Final</label>
            <input
              type="date"
              className={inputClass}
              min={!consulta ? periodoCompetencia?.dataInicial : undefined}
              max={!consulta ? periodoCompetencia?.dataFinal : undefined}
              value={contrato_data_val_fim}
              onChange={(e) => setDataValFim(e.target.value)}
            />
          </div>
        </div>

        <div>
          <label className="block text-sm font-medium text-gray-700 mb-1">Valor do Contrato</label>
          <input
            type="number"
            min={0}
            step="0.01"
            className={inputClass}
            disabled={edicao}
            value={contrato_valor}
            onChange={(e) => alterarValorContrato(e.target.value)}
          />
        </div>

        <div className="md:col-span-2">
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Operação <span className="text-red-500">*</span>
          </label>
          <fieldset disabled={consulta} className="disabled:opacity-70">
            <CmbOperacao user={user} onChange={(value) => setOpCdOperacao(value)} value={op_cdoperacao} sis_ac_cd={sis_ac_cd} />
          </fieldset>
        </div>
      </fieldset>
      {exibeItens && (
        <div className="bg-white rounded-lg shadow-md border border-purple-100 p-4 mt-4">
          <div className="flex items-center justify-between gap-2 mb-2">
            <h2 className="text-sm font-semibold text-purple-700">
              {edicao ? 'Itens do Contrato' : 'Itens do Fabricante'}
            </h2>
            <input
              type="text"
              placeholder="Filtrar por código, cód. blue ou descrição..."
              className="w-80 p-1 border border-gray-300 rounded-md text-sm text-black"
              value={filtroItens}
              onChange={(e) => setFiltroItens(e.target.value)}
            />
          </div>
          <div className="overflow-x-auto max-h-96 overflow-y-auto">
            <table className="min-w-full text-sm">
              <thead className="sticky top-0">
                <tr className="bg-purple-50 text-purple-700 text-xs">
                  <th className="px-2 py-2 text-left">Cód</th>
                  <th className="px-2 py-2 text-left">Cód. Blue</th>
                  <th className="px-2 py-2 text-left">Descrição</th>
                  {porPedido && !consulta && <th className="px-2 py-2 text-right">Custo no Pedido</th>}
                  <th className="px-2 py-2 text-right">Valor Unit. Investimento</th>
                </tr>
              </thead>
              <tbody>
                {itensFiltrados.map((i) => (
                  <tr key={i.prb_cdprodutobluesoft_pk} className="border-t hover:bg-gray-50">
                    <td className="px-2 py-1 text-black">{i.pr_cdproduto}</td>
                    <td className="px-2 py-1 text-black">{i.prb_cdprodutobluesoft_pk}</td>
                    <td className="px-2 py-1 text-gray-800">{i.descricao}</td>
                    {porPedido && !consulta && (
                      <td className="px-2 py-1 text-black text-right">{Number(i.valor_custo ?? 0).toFixed(2)}</td>
                    )}
                    <td className="px-2 py-1 text-black text-right">
                      <input
                        type="number"
                        min={0}
                        step="0.01"
                        readOnly={consulta && !edicao}
                        className="w-32 p-1 border border-gray-300 rounded-md text-right text-black"
                        value={valoresItens[i.prb_cdprodutobluesoft_pk] ?? ''}
                        onChange={(e) =>
                          setValoresItens((prev) => ({ ...prev, [i.prb_cdprodutobluesoft_pk]: e.target.value }))
                        }
                      />
                    </td>
                  </tr>
                ))}
                {itensFiltrados.length === 0 && (
                  <tr>
                    <td colSpan={5} className="px-2 py-3 text-center text-gray-500">
                      {loadingItens
                        ? 'Carregando itens...'
                        : listItens.length > 0
                          ? 'Nenhum item corresponde ao filtro.'
                        : fabricante && fabricante !== '0'
                          ? 'Nenhum item encontrado para o fabricante.'
                          : 'Selecione o fabricante.'}
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>
      )}
    </div>
  );
}
