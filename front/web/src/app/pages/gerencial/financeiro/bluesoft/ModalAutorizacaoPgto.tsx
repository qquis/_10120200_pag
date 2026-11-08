'use client'
import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";

/* Módulos */
import { moduleFinanceiro, tpAutorizacaoPagamento } from "@/api/m0080_financeiro/modulefinanceiro";
import { moduleResultado, re_conta } from "@/api/m0100_resultado/moduleResultado";
import { moduleEnterprise, re_compentencia } from "@/api/m0002_enterprise/moduleEnterprise";

/* Componentes */

import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

interface ModalAutorizacaoPgto {
    autpgto_seq_pk: number;
    onClose: () => void;
    action : string
}




export default function ModalAutorizacaoPgto({ autpgto_seq_pk, onClose, action }: ModalAutorizacaoPgto) {
    const [Item, setItem] = useState<tpAutorizacaoPagamento>({} as tpAutorizacaoPagamento);
    const [ActionStatus, setActionStatus] = useState(0);
    const [ListResultadoConta, setListResultadoConta] = useState<re_conta[]> ([])
    const [ListCompetencia, setListCompetencia] = useState<re_compentencia[]>([])
    const [filterr_conta_cd, setfilterr_conta_cd] = useState(0)
    const { user } = useAuth();

    const myModule: moduleFinanceiro = new moduleFinanceiro(user);
    let myModuleResultado : moduleResultado = new moduleResultado()



    useEffect(() => {
        async function BindingDataInit() {
            try {

                let mylistCompetencia : re_compentencia[] = await new moduleEnterprise(user,0).CompetenciaList()
                setListCompetencia(mylistCompetencia)

                let myListResultadoConta : re_conta[] = await myModuleResultado.getListConta({orderbycolunm:"r_grupo_descricao, r_conta_descricao"})
                setListResultadoConta(myListResultadoConta)


                setActionStatus(1);
                const item = await myModule.moduleBluesoft.consultar(autpgto_seq_pk);
                setItem(item);
                setActionStatus(0);
            } catch (error) {
                setActionStatus(0);
                alert("Erro ao carregar dados da autorização de pagamento");
                onClose();
            }
        }
        BindingDataInit();
    }, [autpgto_seq_pk]);

    const formatCurrency = (value: number | undefined) => {
        if (value === undefined) return 'R$ 0,00';
        return new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(value);
    };

    const formatDate = (date: Date | undefined) => {
        if (!date) return 'N/A';
        return new Date(date).toLocaleDateString('pt-BR');
    };


    const AtualizarAutorizacaoPgto = async (item: tpAutorizacaoPagamento) : Promise<void> => { 
        try { 
            setActionStatus(1);
            await myModule.moduleBluesoft.atualizar(item)
        } catch (error) {
            alert("Erro ao atualizar autorização de pagamento");
        } finally {
            setActionStatus(0);
            alert("Autorização de Pagamento Atualizada com Sucesso");
            onClose();
        }
    
    }


    const getStatusDescricao = () => {
        if (Item.autpgto_cancelada === 1) return "Cancelada";
        return Item.autpgto_status_descricao || "N/A";
    };

    return (
        <div className="fixed inset-0 bg-black/30 backdrop-blur-sm flex items-center justify-center p-4 z-50">
            <div className="bg-white rounded-xl shadow-2xl w-full max-w-4xl max-h-[90vh] overflow-y-auto">
                {/* Cabeçalho do Modal */}
                <HeaderMain header_title="Consulta de Autorização de Pagamento/Recebimento" ActionStatus={ActionStatus} tipo="_MODAL">
                    <div className="flex items-center gap-2">
                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Voltar" TypeIcon="_VOLTAR" title="Voltar" onClick={onClose} />
                    </div>
                </HeaderMain>

                {/* Corpo do Modal */}
                <div className="p-4">
                    <div className="grid grid-cols-1 md:grid-cols-2 gap-5">
                        {/* Seção de Dados Básicos */}
                        <div className="space-y-3">
                            <div className="bg-gray-50 p-3 rounded-lg border border-gray-100">
                                <h3 className="font-medium text-gray-700 mb-2 text-base border-b pb-1">Dados Básicos</h3>
                                <div className="space-y-2">
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Código:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.autpgto_seq_pk || 'N/A'}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Código Participante Pag</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.cdparticipante || 'N/A'}</span>
                                    </div> 
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Código Pessoa Blue</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.autpgto_cdpessoabluesoft || 'N/A'}</span>
                                    </div>                                                                        
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Sacado/Favorecido:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.nome_razao || 'N/A'}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Tipo:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.autpgto_tipo?.trim() == "P"? "Pagamento": "Recebimento"}</span>
                                    </div>
                                </div>
                            </div>

                            {/* Seção de Datas */}
                            <div className="bg-gray-50 p-3 rounded-lg border border-gray-100">
                                <h3 className="font-medium text-gray-700 mb-2 text-base border-b pb-1">Datas</h3>
                                <div className="space-y-2">
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Emissão:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatDate(Item.autpgto_dataemissao)}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Vencimento:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatDate(Item.autpgto_datavencimento)}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Quitação:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatDate(Item.autpgto_dataquitacao)}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Pagamento:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatDate(Item.autpgto_datapagamento)}</span>
                                    </div>
                                </div>
                            </div>

                            {/* Seção de Pag */}
                            <div className="bg-gray-50 p-3 rounded-lg border border-gray-100">
                                <h3 className="font-medium text-red-700 mb-2 text-base border-b pb-1">Pag</h3>
                                <div className="space-y-2">
                                    <div>
                                        <label className="block text-sm font-medium text-gray-700 mb-1">Conta de Lançamento</label>
                                        <select 
                                            className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                                            value={Item.r_conta_cd || 0}
                                            onChange={(e) => {
                                                const selectValue = e.target.value
                                                setItem({
                                                    ...Item,
                                                    r_conta_cd: parseInt(selectValue),
                                                    r_conta_descricao: Item?.r_conta_descricao || ""
                                                });
                                            }}      
                                            >
                                            <option key={0} value = {0} >* NÃO DEFINIDA *</option>
                                            {ListResultadoConta.map((item) => (
                                                <option key={item.r_conta_cd} value={item.r_conta_cd} >
                                                {item.r_grupo_descricao + " | " + item.r_conta_descricao}
                                                </option>
                                            ))}
                                        </select>
                                    </div>
                                    <div>

                                        <label className="block text-sm font-medium text-gray-700 mb-1">Competência</label>
                                        <select 
                                            className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 max-w-30"
                                            value={Item.competencia_cd}
                                            onChange={(e) => {
                                            const selectedValue = e.target.value;
                                            const selectedCompetencia = ListCompetencia.find(c => c.competencia_cd === parseInt(selectedValue)) || null;
                                            setItem({
                                                ...Item,
                                                competencia_cd: parseInt(selectedValue),
                                                competencia_descricao: selectedCompetencia?.competencia_descricao || ""
                                            });
                                            }}
                                        >
                                            <option key={0} value="">* Competência Não Selecionada *</option>
                                            {ListCompetencia.map((item) => (
                                            <option key={item.competencia_cd} value={item.competencia_cd}>
                                                {item.competencia_descricao}
                                            </option>
                                            ))}
                                        </select>
                                    </div>
                                    <div className="flex justify-end mt-4">
                                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Efetivar" TypeIcon="_SALVAR" title="Efetivar" 
                                            onClick={() => { AtualizarAutorizacaoPgto(Item) } } >
                                        </ButtonPag>
                                    </div>
                                </div>


                                


                                </div>
                                <div>
                                

                                
                            </div>


                        </div>

                        {/* Seção de Valores */}
                        <div className="space-y-3">
                            <div className="bg-gray-50 p-3 rounded-lg border border-gray-100">
                                <h3 className="font-medium text-gray-700 mb-2 text-base border-b pb-1">Valores</h3>
                                <div className="space-y-2">
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Valor Fatura:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatCurrency(Item.autpgto_valorfatura)}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Valor Pago:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatCurrency(Item.autpgto_valorpago)}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Desconto:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatCurrency(Item.autpgto_valordescontofinanceiro)}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Multa:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatCurrency(Item.autpgto_valor_multa)}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Juros:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatCurrency(Item.autpgto_valor_juros)}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Valor Líquido:</span>
                                        <span className="text-sm text-gray-700 col-span-2 font-medium">{formatCurrency(Item.autpgto_valorliquido)}</span>
                                    </div>

                                    <div className="grid grid-cols-3 gap-1 items-center border-t">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Valor Total da Operação:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{formatCurrency(Item.autpgto_valortotal)}</span>
                                    </div>
                                </div>
                            </div>

                            {/* Seção de Informações Adicionais */}
                            <div className="bg-gray-50 p-3 rounded-lg border border-gray-100">
                                <h3 className="font-medium text-gray-700 mb-2 text-base border-b pb-1">Informações Adicionais</h3>
                                <div className="space-y-2">
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Nota Fiscal:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.autpgto_nf_numero || 'N/A'}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Parcela:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.autpgto_numeroparcela || 'N/A'}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Status:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{getStatusDescricao()}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Conta:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.r_conta_descricao || 'N/A'}</span>
                                    </div>
                                    <div className="grid grid-cols-3 gap-1 items-center">
                                        <span className="text-xs text-gray-500 font-medium col-span-1">Competência Bluesoft:</span>
                                        <span className="text-sm text-gray-700 col-span-2">{Item.competencia_bluesoft_descricao || 'N/A'}</span>
                                    </div>                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}