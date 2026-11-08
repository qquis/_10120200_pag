'use client'

import { useEffect, useState } from 'react'
import { useAuth } from "@/app/context/context"

import HeaderMain from "@/app/components/divs/headerMain"
import ButtonPag from "@/app/components/Buttons/button"

import { moduleEstoqueCusto } from "@/api/m0030_estoquecusto/moduleestoquecusto"
import CmbFabricante from '@/app/pages/cadastro/_components/CmbFabricante/page'

import {moduleProduto
      , moduleProdutoCategoria
      , TpProduto
      , TpProdutoCategoria
      , TpProdutoDepartamento
      , TpProdutoGrupo
      , TpProdutoSecao
      , TpProdutoSubGrupo
    
    } from '@/api/m0020_produto/moduleproduto'

    let myModuleProduto : moduleProduto
    let myModuleProdutoCategoria : moduleProdutoCategoria


type TAnaliseEstoqueItem = {
    pr_cdproduto: number
    prb_cdprodutobluesoft: number
    pr_descricao: string
    prb_status: number
    ec_embalagemestoque_qtde: string
    fator: string
    ec_embalagemcompra_qtde: string
    data_ultima_compra: string
    venda_embalagemestoque: string
    venda_embalagemcompra: string
    venda_embalagemestoque_media_diaria: string
    data_ultima_venda: string | null
    ec_valor_custo_faturamento: string
    prg_descricao: string
    prs_descricao: string
    prsg_descricao: string
    prb_cdbarra_principal: string
    prb_cdpessoabluesoft_fabricante: number
    fabricante_nome_razao: string
}

export default function EstoqueCustoAnalisePage() {
    const __SIS_AC_CD: number = 3030
    const { user } = useAuth()

    const [ActionStatus, setActionStatus] = useState<number>(0)
    const [dataFaturamentoIni, setDataFaturamentoIni] = useState<string>(new Date().toISOString().split('T')[0])
    const [FatorMediaVenda , setFatorMediaVenda] = useState<number>(90)
    const [List, setList] = useState<TAnaliseEstoqueItem[]>([])
    const [FabricanteSelecionado, setFabricanteSelecionado] = useState<string>('0')
    const [filtrarEstoque, setFiltrarEstoque] = useState<number>(0)
    const [filtrarEstoqueNegativo, setFiltrarEstoqueNegativo] = useState<number>(0)
    const [qtdeinicial, setQtdeinicial] = useState<number>(0)
    const [qtdefinal, setQtdefinal] = useState<number>(0)

    const [ProdutoDepartamento, setProdutoDepartamento] = useState<TpProdutoDepartamento[]>([])
    const [ProdutosSecao, setProdutosSecao] = useState<TpProdutoSecao[]>([])
    const [DepartamentoFilterID, setDepartamentoFilterId] = useState<number>(0)
    
    const [DataUltimaVendaFiltrar, setDataUltimaVendaFiltrar] = useState<boolean>(false)
    const [DataUltimaVendaIni, setDataUltimaVendaIni] = useState<string>(`2020-01-01`)
    const [DataUltimaVendaFim, setDataUltimaVendaFim] = useState<string>(new Date().toISOString().split('T')[0])
    
    const [DataUltimaCompraFiltrar, setDataUltimaCompraFiltrar] = useState<boolean>(false)
    const [DataUltimaCompraIni, setDataUltimaCompraIni] = useState<string>(`2020-01-01`)
    const [DataUltimaCompraFim, setDataUltimaCompraFim] = useState<string>(new Date().toISOString().split('T')[0])
    
    
    const [SecaoFilterID, setSecaoFilterId] = useState<number>(0)
    const [filtrar_vendaexterna, setfiltrar_vendaexterna] = useState<string>('')
    const [prb_status, setprb_status] = useState('true'); 
    
    const toNumber = (value: string | number | null | undefined) => {
      const normalized = String(value ?? '0').replace(',', '.')
      const n = Number(normalized)
      return Number.isFinite(n) ? n : 0
    }

    const totalCusto = List.reduce((acc, item) => {
      const estoque = toNumber(item.ec_embalagemestoque_qtde)
      const custo = toNumber(item.ec_valor_custo_faturamento)
      return acc + estoque * custo
    }, 0)

    useEffect(() => {

        const BindingData = async () => {

            /* MODULES  */


            await myModuleProdutoCategoria.getCategoria()
            setProdutoDepartamento( await myModuleProdutoCategoria.getDepartamento() );
            await FiltrarSecao(0)
            

        };
            

        myModuleProduto = new moduleProduto(user);
        myModuleProdutoCategoria = new moduleProdutoCategoria(user);
        
        definirDataMediaVenda(90)

        setDataUltimaVendaIni(new Date(2020, 0, 1).toISOString().split('T')[0])
        setDataUltimaCompraIni(new Date(2020, 0, 1).toISOString().split('T')[0])
        
        BindingData()
    }, [])

    const consultarList = async () => {
        try {
            setActionStatus(1)
            setList([])

            const myMODULE = new moduleEstoqueCusto(user, __SIS_AC_CD)



            const filter = {
                dataFaturamento_filter: 1,
                dataFaturamento_ini: dataFaturamentoIni,
                fatormediavenda: FatorMediaVenda,
                cdparticipante_fabricante: FabricanteSelecionado !== '0' ? FabricanteSelecionado : null,
                filtrarEstoque: filtrarEstoque,
                qtdeinicial: qtdeinicial,
                qtdefinal: qtdefinal,
                prd_cddepartamento: DepartamentoFilterID,
                prs_cdsecao: SecaoFilterID,
                venda_externa: filtrar_vendaexterna !== '' ? filtrar_vendaexterna : null,
                prb_status: prb_status,
                DataUltimaVendaFiltrar: DataUltimaVendaFiltrar,
                DataUltimaVendaIni: user.formatDateToStringYYYMMDD(DataUltimaVendaIni),
                DataUltimaVendaFim: user.formatDateToStringYYYMMDD(DataUltimaVendaFim),
                DataUltimaCompraFiltrar: DataUltimaCompraFiltrar,
                DataUltimaCompraIni: user.formatDateToStringYYYMMDD(DataUltimaCompraIni),
                DataUltimaCompraFim: user.formatDateToStringYYYMMDD(DataUltimaCompraFim)
            }

            const response = await myMODULE.getAnaliseEstoque(filter)
            setList(response || [])
        } catch (error) {
            console.error('Erro ao consultar análise de estoque:', error)
            setList([])
        } finally {
            setActionStatus(0)
        }
    }

    const exportAnaliseToInventario = async () => {
        try {

            await moduleEstoqueCusto.export.AnaliseToInventario(List, user)

        } catch (error) {
            console.error('Erro ao exportar análise de estoque para inventário:', error)
        }
    }

    const definirDataMediaVenda = (dias: number) => {
        setFatorMediaVenda(dias)
        setDataFaturamentoIni(new Date(new Date().setDate(new Date().getDate() - dias)).toISOString().split('T')[0])
    }

    const definirEstoqueNegativo = (checked: boolean) => {
        if (checked) {
            setFiltrarEstoque(1)
            setFiltrarEstoqueNegativo(1)
            setQtdeinicial(-99999999)
            setQtdefinal(-0.001)
        } else {
            setFiltrarEstoque(0)
            setFiltrarEstoqueNegativo(0)
            setQtdeinicial(0)
            setQtdefinal(0)
        }
    }

      const changeDepartamento = async (prd_cddepartamento: number) => { 
      setDepartamentoFilterId(prd_cddepartamento)
      await FiltrarSecao(prd_cddepartamento)
  }

  const FiltrarSecao = async (departamentoID: number) => { 
    try {
        setActionStatus(1)
        await myModuleProdutoCategoria.getSecao(departamentoID)
        setProdutosSecao(myModuleProdutoCategoria.Secao)
        setSecaoFilterId(0)
        setActionStatus(0)

    } catch (e) {
        console.log(`Filtrar Secao Error ${e}`)

  }
}

    return (
        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Estoque/Custo | Análise de Estoque">
                    <div className="flex space-x-2">
                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            label="Pdf Inventário"
                            TypeIcon="_SALVAR"
                            title="Download pdf para Inventário"
                            onClick={exportAnaliseToInventario}
                        />
                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            label="Pesquisar"
                            TypeIcon="_PESQUISAR"
                            title="Pesquisar"
                            onClick={consultarList}
                        />
                        
                    </div>
                </HeaderMain>

                <div className="bg-white rounded-lg shadow-md p-4 mb-6 border border-blue-100">
                    <h3 className="text-base font-medium text-gray-900 mb-3">Filtros</h3>

                    <div className="grid grid-cols-1 lg:grid-cols-3 gap-3">


                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                N. dias Média Venda
                            </label>
                            <input
                                type="number"
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black text-sm"
                                value={FatorMediaVenda}
                                onChange={(e) => definirDataMediaVenda(parseInt(e.target.value || "0"))}
                            />
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Data para Cálculo da Média de Venda
                            </label>
                            <input
                                type="date"
                                disabled={true}
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black text-sm"
                                value={dataFaturamentoIni}
                                onChange={(e) => setDataFaturamentoIni(e.target.value)}
                            />
                        </div>

                        <div>
                            <label className="flex items-center gap-2 text-sm font-medium text-gray-700 mb-2">
                                <span>Filtrar Estoque</span>
                                <input
                                    type="checkbox"
                                    className="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                                    checked={filtrarEstoque == 1}
                                    onChange={(e) => setFiltrarEstoque(e.target.checked ? 1 : 0)}
                                />
                                <span>Filtrar Estoque Negativo</span>
                                <input
                                    type="checkbox"
                                    className="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                                    checked={filtrarEstoqueNegativo == 1}
                                    onChange={(e) => definirEstoqueNegativo(e.target.checked)}
                                />
                            </label>

                            <div className="grid grid-cols-[24px_1fr_24px_1fr] gap-2 items-center">
                                <span className="text-[11px] font-medium text-gray-500">De</span>
                                <input
                                    type="number"
                                    className="w-full p-2 border text-right border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black text-sm"
                                    disabled={filtrarEstoqueNegativo == 1 || filtrarEstoque == 0}
                                    value={qtdeinicial}
                                    onChange={(e) => setQtdeinicial(Number(e.target.value || 0))}
                                />
                                <span className="text-[11px] font-medium text-gray-500">Até</span>
                                <input
                                    type="number"
                                    className="w-full p-2 border text-right border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent text-black text-sm"
                                     disabled={filtrarEstoqueNegativo == 1 || filtrarEstoque == 0}
                                    value={qtdefinal}
                                    onChange={(e) => setQtdefinal(Number(e.target.value || 0))}
                                />
                            </div>
                        </div>
                    </div>

                    <div className="grid grid-cols-1 lg:grid-cols-3 gap-3 mt-4">
                                                <div className="lg:col-span-2">
                            <label className="block text-sm font-medium text-gray-700 mb-1">
                                Fabricante
                            </label>
                            <CmbFabricante
                                user={user}
                                value={FabricanteSelecionado}
                                onChange={(value) => setFabricanteSelecionado(value)}
                                sis_ac_cd={__SIS_AC_CD}
                            />
                        </div>
                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Departamento</label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                                value={DepartamentoFilterID}
                                onChange={async (e) => await changeDepartamento(Number(e.target.value))}
                                disabled={ProdutoDepartamento.length === 0}
                            >
                                <option value="">Todos</option>
                                {ProdutoDepartamento.map((departamento, index) => (
                                    <option key={index} value={departamento.prd_cddepartamento}>
                                        {departamento.prd_descricao}
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Seção</label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                                value={SecaoFilterID}
                                onChange={(e) => setSecaoFilterId(Number(e.target.value))}
                            >
                                <option value="">Todas</option>
                                {ProdutosSecao.map((section, index) => (
                                    <option key={index} value={section.prs_cdsecao}>
                                        {section.prs_descricao}
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Status</label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                                value={prb_status}
                                onChange={(e) => setprb_status(e.target.value)}
                            >
                                <option value="">Todos</option>
                                <option value="true">Ativo</option>
                                <option value="false">Inativo</option>
                            </select>
                        </div>

                        <div>
                            <label className="block text-sm font-medium text-gray-700 mb-1">Venda Externa</label>
                            <select
                                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                                value={filtrar_vendaexterna}
                                onChange={(e) => setfiltrar_vendaexterna(e.target.value)}
                            >
                                <option value="">Todos</option>
                                <option value="SIM">Sim</option>
                                <option value="NAO">Não</option>
                            </select>
                        </div>


                        <div>
                            <label className="flex items-center gap-2 text-sm font-medium text-gray-700 mb-1">
                            <span>Data Última Venda</span>
                            <input
                                type="checkbox"
                                className="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                                checked={DataUltimaVendaFiltrar}
                                onChange={(e) => setDataUltimaVendaFiltrar(e.target.checked)}
                            />
                            </label>


                            <div className="flex space-x-2">
                                <input
                                    type="date"
                                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                                    value={DataUltimaVendaIni}
                                    disabled={!DataUltimaVendaFiltrar}
                                    onChange={(e) => setDataUltimaVendaIni(e.target.value)}
                                />
                                <span className="text-gray-500">até</span>
                                <input
                                    type="date"
                                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                                    value={DataUltimaVendaFim}
                                    disabled={!DataUltimaVendaFiltrar}
                                    onChange={(e) => setDataUltimaVendaFim(e.target.value)}
                                />
                            </div>
                        </div>      
                        <div>
                            <label className="flex items-center gap-2 text-sm font-medium text-gray-700 mb-1">
                                <span>Data Última Compra</span>
                                <input
                                    type="checkbox"
                                    className="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                                    checked={DataUltimaCompraFiltrar}
                                    onChange={(e) => setDataUltimaCompraFiltrar(e.target.checked)}
                                />
                            </label>
                            <div className="flex space-x-2">
                                <input
                                    type="date"
                                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                                    value={DataUltimaCompraIni}
                                    disabled={!DataUltimaCompraFiltrar}
                                    onChange={(e) => setDataUltimaCompraIni(e.target.value)}
                                />
                                <span className="text-gray-500">até</span>
                                <input
                                    type="date"
                                    className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black text-sm"
                                    value={DataUltimaCompraFim}
                                    disabled={!DataUltimaCompraFiltrar}
                                    onChange={(e) => setDataUltimaCompraFim(e.target.value)}
                                />
                            </div>
                        </div>                                             
                    </div>
                </div>

                <div className="bg-white rounded-lg shadow-md overflow-hidden border border-blue-100">
                    <div className="max-h-[600px] overflow-y-auto">
                        <table className="min-w-full divide-y divide-gray-200">
                            <thead className="bg-blue-100 sticky top-0 z-10">
                                <tr>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Fabricante</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Cd Blue</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Descrição</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-blue-700 tracking-wider">Est. em CX</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-blue-700 tracking-wider">Fator</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-blue-700 tracking-wider">Estoque</th>
                                    
                                    <th className="px-4 py-3 text-right text-xs font-medium text-blue-700 tracking-wider">Venda Unt no Período</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-blue-700 tracking-wider">Média Diária</th>
                                    <th className="px-4 py-3 text-right text-xs font-medium text-blue-700 tracking-wider">Custo Fat.</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Últ. Venda</th>
                                    <th className="px-4 py-3 text-left text-xs font-medium text-blue-700 tracking-wider">Últ. Compra</th>

                                </tr>
                            </thead>
                            <tbody className="bg-white divide-y divide-gray-200">
                                {List.length > 0 ? (
                                    List.map((item, index) => (
                                        <tr key={item.pr_cdproduto || index} className="hover:bg-blue-50">
                                            <td className="px-4 py-2 text-xs text-gray-700">{item.fabricante_nome_razao || '-'}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 text-right">{item.prb_cdprodutobluesoft}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700">{item.pr_descricao}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 text-right">{user.formatNumber(item.ec_embalagemcompra_qtde, 2)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 text-right">{item.fator}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 text-right">{user.formatNumber(item.ec_embalagemestoque_qtde, 2)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 text-right">{user.formatNumber(item.venda_embalagemcompra, 2)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 text-right">{user.formatNumber(item.venda_embalagemestoque_media_diaria, 2)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700 text-right">{user.formatNumber(item.ec_valor_custo_faturamento, 2)}</td>
                                            <td className="px-4 py-2 text-xs text-gray-700">
                                                {item.data_ultima_venda ? user.formatDateDDMMYYYY(item.data_ultima_venda) : '-'}
                                            </td>
                                            <td className="px-4 py-2 text-xs text-gray-700">
                                                {item.data_ultima_compra ? user.formatDateDDMMYYYY(item.data_ultima_compra) : '-'}
                                            </td>
                                        </tr>
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan={11} className="px-6 py-4 text-center text-sm text-gray-500">
                                            {ActionStatus === 1 ? 'Carregando...' : 'Nenhum Registro Encontrado'}
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>

                <div className="px-6 py-4 bg-gray-50 border border-t-0 border-blue-100 rounded-b-lg">
                    <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-blue-100 text-blue-800">
                        Total de Registros: {List.length}
                    </span>
                    <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-blue-100 text-blue-800">
                        Total de Custo: {totalCusto.toLocaleString('pt-BR', {maximumFractionDigits: 2})}
                    </span>
                </div>
            </div>
        </div>
    )
}