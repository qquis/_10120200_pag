'use client'
import { useEffect, useState, useActionState} from "react";
import { useAuth } from "@/app/context/context";


/*Módulos */
import { moduleFinanceiro, tpAutorizacaoPagamentoPag } from "@/api/m0080_financeiro/modulefinanceiro";
import { moduleResultado, re_conta } from "@/api/m0100_resultado/moduleResultado";
import { moduleEnterprise, re_compentencia } from "@/api/m0002_enterprise/moduleEnterprise";

/*SCREEN*/
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";




interface ModalAutorizacaoPgtoPag {
    aut_pgto_pag_seq: number;
    onClose: () => void;
    action: string 
    tipo_lancamento: number
}

export default function ModalFinanceiroPagItem({ aut_pgto_pag_seq, onClose, action, tipo_lancamento }: ModalAutorizacaoPgtoPag) {

    
    const [Item, setItem] = useState<tpAutorizacaoPagamentoPag>({} as tpAutorizacaoPagamentoPag);

    const opcaoDebitoCredito = [
      { debitocredito: -1, debitocredito_descricao: 'Débito' },
      { debitocredito: 1, debitocredito_descricao: 'Crédito' },
    ];


    //Screen Controls
    const [ActionStatus, setActionStatus] = useState(0)
    
    //LISTS
    const [ListResultadoConta, setListResultadoConta] = useState<re_conta[]> ([])
    const [ListCompetencia, setListCompetencia] = useState<re_compentencia[]>([])
    const [ContaResultadoSelecionada, setContaResultadoSelecionada] = useState<re_conta>({} as re_conta)


    const { user } = useAuth()

    let myModule : moduleFinanceiro = new moduleFinanceiro(user);
    let muModuleRESULTADO : moduleResultado = new moduleResultado();
    let myModuleEnterprise : moduleEnterprise = new moduleEnterprise(user,0);


    useEffect(() => {
      async function BindingDataInit() {
            // Preenchendo combobox de conta ____________________________
            let myListResultadoConta : re_conta[] = await muModuleRESULTADO.getListConta({r_conta_lancamento_manual:1, orderbycolunm:"r_conta_descricao"})
            setListResultadoConta(myListResultadoConta)

            let mylistCompetencia : re_compentencia[] = await myModuleEnterprise.CompetenciaList()
            setListCompetencia(mylistCompetencia)
            
            //Consultando o item selecionado_____________________________
            let item : tpAutorizacaoPagamentoPag = await myModule.modulelancamentoPag.new()

            item.aut_pgto_pag_tipo_cd = tipo_lancamento;

            if (aut_pgto_pag_seq !== 0)
                item = await myModule.modulelancamentoPag.consultar(aut_pgto_pag_seq)
            
            setItem(item);
      }
        BindingDataInit()
    }, []);


    const itemCancelar = async() : Promise<void> => {
      try { 
        setActionStatus(1)  
        await myModule.modulelancamentoPag.Cancelar(Item)
        setActionStatus(0) 
        alert("Item cancelado com sucesso")
      } catch (e) {
        setActionStatus(0)
        alert("Erro ao cancelar o item: " + e)
      }
    }

    const formSubmit = async(e: React.FormEvent) => { 
      e.preventDefault()
      try { 
          setActionStatus(1)
          await myModule.modulelancamentoPag.atualizar(Item)
              .then (() => alert("Registro Salvo com sucesso")) 
          setActionStatus(0)
          onClose()
      } catch (e) { 
          setActionStatus(0)
      }
    }


  

    return (
    <div className="fixed inset-0 bg-black/30 backdrop-blur-sm flex items-center justify-center p-4 z-50">
    <div className="bg-white rounded-xl shadow-2xl w-full max-w-4xl max-h-[90vh] overflow-y-auto">
      {/* Cabeçalho do Modal */}

    <HeaderMain header_title="Financeiro Operacional Pag | Lançamento" ActionStatus={ActionStatus} tipo="_MODAL">
      <div className="flex items-center gap-2">
        <ButtonPag TypeButton="_BUTTON_HEADER" label="Salvar" TypeIcon="_SALVAR" title="Salvar x" type="submit" form="formModalAutorizacaoPgtoPag" ></ButtonPag>
        <ButtonPag TypeButton="_BUTTON_HEADER" label="Voltar" TypeIcon="_VOLTAR" title="Voltar" onClick={onClose} ></ButtonPag>
      </div>
    </HeaderMain>

    {/* Corpo do Modal */}
    <form id="formModalAutorizacaoPgtoPag" onSubmit={formSubmit} className="p-4">

        <div className="grid grid-cols-1 md:grid-cols-2 gap-5">
          {/* Seção de Referência */}
          <div className="space-y-3">
            <div className="bg-gray-200 p-3 rounded-lg border border-gray-100">
              <div className="grid grid-cols-3 gap-1 items-center">
                <h3 className="font-medium text-gray-700 mb-2 text-base border-b pb-1">Referência</h3>
                <span className="text-sm text-gray-700 mb-2 border-b pb-1">{(tipo_lancamento == 1)? "Lançamento Real" : "Ajuste de Previsão de Fluxo de Caixa"}</span>
              </div>
              <div className="space-y-2">
                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Token:</span>
                  <span className="text-sm text-gray-700 break-all col-span-2">{Item.aut_pgto_pag_uuid}</span>
                </div>
                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Código:</span>
                  <span className="text-sm text-gray-700 col-span-2">{Item.aut_pgto_pag_seq}</span>
                </div>
              </div>
            </div>

            {/* Seção de Dados */}
            <div className="bg-gray-200 p-3 rounded-lg border border-gray-100">
              <h3 className="font-medium text-gray-700 mb-2 text-base border-b pb-1">Dados</h3>
              <div className="space-y-2">
                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Lançamento:</span>
                  <span className="text-sm text-gray-700 col-span-2">
                    {Item.aut_pgto_pag_data ? new Date(Item.aut_pgto_pag_data).toLocaleDateString('pt-BR') : 'N/A'}
                  </span>
                </div>
                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Pagamento:</span>
                  <input
                    type="date"
                    disabled={action === "_SELECT" || action === "_EDIT"} 
                    className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                    value={Item.aut_pgto_pag_data_pgto ? user.dateToInputFormat(Item.aut_pgto_pag_data_pgto): ''}
                    onChange={(e) => {
                      setItem({
                        ...Item,
                        aut_pgto_pag_data_pgto: user.stringToDate(e.target.value)
                      })
                    }}
                  />
                </div>
                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Descrição (Max 40c):</span>
                  <textarea
                    disabled={action === "_SELECT"}
                    className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                    value={Item.aut_pgto_pag_obs || ''}
                    onChange={(e) => {
                      setItem({
                        ...Item,
                        aut_pgto_pag_obs: e.target.value
                      })
                    }}
                    rows={3}
                    maxLength={40}
                  />
                </div>

                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Conta:</span>
                  <div className="col-span-2">
                    <select 
                      disabled={action === "_SELECT" || action === "_EDIT" || tipo_lancamento == 2} 
                      className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                      
                      value={Item.r_conta_cd}
                      onChange={(e) => {
                        const selectValue = e.target.value
                        const ContaSelect : re_conta = ListResultadoConta.find(c => c.r_conta_cd === parseInt(selectValue)) || {} as re_conta
                        
                        setContaResultadoSelecionada(ContaSelect)
                        setItem({
                          ...Item,
                          r_conta_cd: parseInt(selectValue)
                        })
                      }}      
                    >
                      {ListResultadoConta.map((item) => (
                        <option 
                          key={item.r_conta_cd} 
                          value={item.r_conta_cd}
                        >
                          {item.r_conta_descricao}
                        </option>
                      ))}
                    </select>
                  </div>
                </div>


                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Competência:</span>
                  <div className="col-span-2">
                    <select 
                      disabled={action === "_SELECT" || action === "_EDIT" || tipo_lancamento == 2} 
                      className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                      value={Item.competencia_cd}
                      onChange={(e) => {
                        const selectValue = e.target.value
                        setItem({
                          ...Item,
                          competencia_cd: parseInt(selectValue)
                        })
                      }}      
                    >
                      {ListCompetencia.map((item) => (
                        <option 
                          key={item.competencia_cd} 
                          value={item.competencia_cd}
                        >
                          {item.competencia_descricao}
                        </option>
                      ))}
                    </select>
                  </div>
                </div>


                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Débito/Crédito:</span>
                  <div className="col-span-2">
                    <select
                      disabled={tipo_lancamento === 1 || action === "_SELECT" || action === "_EDIT"}
                      className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                      value={
                        tipo_lancamento === 1
                          ? ContaResultadoSelecionada.debitocredito ?? ''
                          : Item.debitocredito ?? ''
                      }
                      onChange={(e) => {
                        //if (tipo_lancamento === 2) {
                          setItem({
                            ...Item,
                            debitocredito: parseInt(e.target.value)
                          });
                        //}
                      }}
                    >
                      {opcaoDebitoCredito.map((item) => (
                        <option
                          key={item.debitocredito}
                          value={item.debitocredito}
                        >
                          {item.debitocredito_descricao}
                        </option>
                      ))}
                    </select>
                  </div>
                </div>

                <div className="grid grid-cols-3 gap-1 items-center">
                  <span className="text-xs text-gray-500 font-medium col-span-1">Valor:</span>
                  <input
                    type="number"
                    disabled={action === "_SELECT" || action === "_EDIT"} 
                    className="w-full px-2 py-1 text-sm text-gray-700 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                    value={Item.aut_pgto_pag_valor || 0}
                    onChange={(e) => {
                      setItem({
                        ...Item,
                        aut_pgto_pag_valor: parseFloat(e.target.value)
                      })
                    }}
                    step="0.01"
                  />
                </div>
              </div>
            </div>
          </div>

          {/* Seção Adicional */}
          <div className="bg-gray-200 p-3 rounded-lg border border-gray-100">
            <h3 className="font-medium text-gray-700 mb-2 text-base border-b pb-1">Detalhes Adicionais</h3>

          </div>
          <div className="bg-gray-200 p-3 rounded-lg border border-gray-100">  
            <h3 className="font-medium text-gray-700 mb-2 text-base border-b pb-1">Cancelamento</h3>
            <div className="grid md:grid-cols-2 gap-4 sm:grid-cols-1">
              <div className="grid grid-cols-3 gap-10 items-center">
                <span className="text-xs text-gray-500 font-medium col-span-1">Status Cancelado:</span>
                <span className="text-sm text-gray-700 col-span-2">{(Item.aut_pgto_pag_cancelado == 0)? 
                          "Não"  
                      :  "Sim"}</span>
              </div>
              {(Item.aut_pgto_pag_cancelado == 0) && (action === "_EDIT") && (
                <div className="mt-3 pt-3 border-t border-gray-200">
                  <button
                    type="button"
                    onClick={itemCancelar}
                    className="flex items-center bg-red-500 hover:bg-red-600 text-white font-medium py-2 px-4 rounded-md text-sm transition-colors duration-300 gap-2"
                  >
                    <svg xmlns="http://www.w3.org/2000/svg" className="h-4 w-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                      <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
                    </svg>
                    Cancelar Lançamento
                  </button>
                </div>
              )}

              {(Item.aut_pgto_pag_cancelado == 1) && (
                <div className="space-y-2">
                  <div className="grid grid-cols-3 gap-1 items-center">
                    <span className="text-xs text-gray-500 font-medium col-span-1">Cancelado por:</span>
                    <span className="text-sm text-gray-700 col-span-2">{Item.user_name_cancelador || 'N/A'}</span>
                  </div>
                  <div className="grid grid-cols-3 gap-1 items-center">
                    <span className="text-xs text-gray-500 font-medium col-span-1">Data Cancelamento:</span>
                    <span className="text-sm text-gray-700 col-span-2">
                      {Item.aut_pgto_pag_cancelado_data ? new Date(Item.aut_pgto_pag_cancelado_data).toLocaleDateString('pt-BR') : 'N/A'}
                    </span>
                  </div>
                </div>
              )}  
            </div>
          </div>
          

        </div>

    </form>
  </div>
</div>
    )


}