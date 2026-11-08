'use client'
import { useEffect, useState} from "react";
import { moduleResultado , re_conta, re_contaOrigem} from "@/api/m0100_resultado/moduleResultado";


import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

interface ModalContaProps {
    r_conta_cd: number;
    onClose: () => void;
}

export default function ModalConta({ r_conta_cd, onClose }: ModalContaProps) {



    //Screen Controls
    const [ActionStatus, setActionStatus] = useState(0)

    const [DataListRateios, setDataListRateios] = useState <[]>([]);
    const [selectedConta, setSelectedConta] = useState<re_conta>({} as re_conta);


    let myModule : moduleResultado = new moduleResultado();
    useEffect(() => {
      async function BindingDataInit() {
            /*Consultando a Conta */
            let dadosDetalhadosDaConta : re_conta 
            dadosDetalhadosDaConta = await myModule.apiDRE_Conta.get(r_conta_cd)
            setSelectedConta(dadosDetalhadosDaConta);
            /*Preenchendo os tipos de rateios*/
            setDataListRateios(await myModule.getListRateios({r_rateio_sistema : 0}));
      }

    BindingDataInit()
    }, []);

    const DREContaAtualizar = async(item: any) : Promise<void> => { 
        await myModule.apiDRE_Conta.post(item)
        alert("Conta Atualizada com Sucesso")
        onClose();
    }

    return (
          <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4 z-50">
            <div className="bg-white rounded-lg shadow-xl w-full max-w-4xl max-h-[90vh] overflow-y-auto">
            <HeaderMain tipo={"_MODAL"} ActionStatus={ActionStatus} header_title="Resultado | Consulta" >
            <div className="flex space-x-2">
                <ButtonPag TypeButton="_BUTTON_HEADER" label="Voltar" TypeIcon="_VOLTAR" title="Voltar" onClick={onClose} ></ButtonPag>
            </div>
            </HeaderMain>    

        <div className="p-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                    <h3 className="font-semibold text-gray-700 mb-2">Informações Básicas</h3>
                    <div className="space-y-2">
                        <p><span className="font-medium">Código:</span> {selectedConta.r_conta_cd}</p>
                        <hr className="my-1 border-gray-200" />
                        <p><span className="font-medium">Descrição:</span> {selectedConta.r_conta_descricao}</p>
                        <hr className="my-1 border-gray-200" />
                        <p><span className="font-medium">Grupo:</span> {selectedConta.r_grupo_descricao} ({selectedConta.r_grupo_cd})</p>
                    </div>
                </div>

                <div>
                    <h3 className="font-semibold text-gray-700 mb-2">Configurações</h3>
                    <div className="space-y-2">
                        <p><span className="font-medium">Lançamento Manual:</span> {selectedConta.r_conta_lancamento_manual == 1 ? "Sim" : "Não"}</p>
                        <hr className="my-1 border-gray-200" />
                        <p><span className="font-medium">Lançamento à Crédito:</span> {selectedConta.debitocredito == 1 ? "Sim" : "Não"}</p>
                        <hr className="my-1 border-gray-200" />
                        <p><span className="font-medium">Rateio:</span> {selectedConta.r_rateio_cd}</p>
                        <hr className="my-1 border-gray-200" />
                        <p><span className="font-medium">Descrição do Rateio:</span></p>
                        <select
                          className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent"
                          value={selectedConta.r_rateio_cd}
                          onChange={(e) => {
                              const selectValue = e.target.value
                              setSelectedConta({
                                    ...selectedConta,
                                    r_rateio_cd:  parseInt(selectValue),
                                    r_rateio_descricao: selectedConta?.r_rateio_descricao || ""
                                  });
                              //setfilterCentroOperacional(selectValue? JSON.parse(selectValue): null)
                          }}
                        >
                          {DataListRateios.map((item : any) => (
                            <option key={item?.r_rateio_cd} 
                                    value={item?.r_rateio_cd}>
                                  {item.r_rateio_descricao} ({item.r_rateio_cd})
                            </option>
                          ))}
                      </select>
                        <ButtonPag TypeButton="_BUTTON_HEADER" label="Efetivar" TypeIcon="_SALVAR" title="Efetivar" onClick={() => DREContaAtualizar(selectedConta)} ></ButtonPag>

                    </div>
                </div>
                <div className="col-span-2 ">
                  <h2 className="text-xl font-bold text-purple-700 mb-4">Fonte de Dados</h2>
                  <div className="max-h-[300px] overflow-y-auto">
                    <table className="min-w-full divide-y divide-gray-200">
                        <thead className="bg-gray-100 sticky top-0 z-10">
                          <tr>
                            <th className="px-3 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Tipo de Origem</th>
                            <th className="px-2 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Operação Vinculada</th>
                            <th className="px-1 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Centro de Resultado</th>
                            <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Conta Contábil</th>
                            <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Depto do Produto</th>
                            <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Seção</th>
                            <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Setor Operacional</th>
                            <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Respons</th>
                            <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Part. Pag</th>
                            <th className="px-4 py-3 text-left text-xs font-medium text-purple-700 tracking-wider">Nome Razão</th>
                          </tr>
                        </thead>
                        <tbody className="bg-white divide-y divide-gray-200">
                          {selectedConta.resultadoContaOrigemList? (
                            selectedConta.resultadoContaOrigemList.map((item: re_contaOrigem) => (
                              <tr key={item.r_conta_cd} className="hover:bg-gray-50">
                                <td className="px-3 py-3 whitespace-nowrap text-xs text-gray-700 text-right">{item.r_conta_origem_tipo_descricao}</td>
                                <td className="px-2 py-3 whitespace-nowrap text-xs text-gray-700">{item.op_descricao}</td>
                                <td className="px-1 py-3 whitespace-nowrap text-xs text-gray-700"> {item.r_centro_op_descricao}   </td>
                                <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.plc_descricao}</td>
                                <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.prd_descricao}</td>
                                <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.prs_descricao}</td>
                                <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.rh_setor_operacional_descricao}</td>
                                <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.r_resp_descricao}</td>
                                <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.cdparticipante}</td>
                                <td className="px-4 py-3 whitespace-nowrap text-xs text-gray-700">{item.nome_razao}</td>

                            </tr>
                            ))
                          ) : (
                            <tr>
                              <td colSpan={6} className="px-6 py-4 text-center text-sm text-gray-500">
                                Nenhum Vínculo Encontrado
                              </td>
                            </tr>
                          )}
                        </tbody>
                    </table>
                  </div>
                </div>
                  

            </div>
        </div>

            </div>
          </div>
    )


}