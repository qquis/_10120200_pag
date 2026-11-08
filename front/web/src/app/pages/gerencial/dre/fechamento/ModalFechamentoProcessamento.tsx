import { useEffect, useState, useTransition  } from "react";

/*Imports Modules Pag */
import { re_compentencia } from "@/api/m0002_enterprise/moduleEnterprise";
import {  moduleResultado,  re_resultado } from "@/api/m0100_resultado/moduleResultado";   


/*Impots Screen */
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

interface ModalFechamentoProcessamentoProps {
    onClose: () => void,

}


export default function  ModalFechamentoProcessamento({ onClose }: ModalFechamentoProcessamentoProps) {


    //States Lists    
    const [CompetenciaList, setListCompetencia ] = useState<re_compentencia[]>([])
    
    //Screen Controls
    const [ActionStatus, setActionStatus] = useState(0)

    //Filter 
    const [CompetenciaFilter, setFilterCompetencia ] = useState<re_compentencia>({competencia_cd: 0, competencia_descricao: ''}); // Inicializa com competencia_cd = 0 para pegar todos

    let myModule = new moduleResultado();

    const ResultadoFechamentoProcessar = async () => {
        try {
            if (!CompetenciaFilter || CompetenciaFilter.competencia_cd === 0) {
                alert("Por favor, selecione uma competência válida.");
                return;
            }
            setActionStatus(1)
            await myModule.postProcessarFechamento({competencia_cd: CompetenciaFilter.competencia_cd});
            alert("Processamento de fechamento realizado com sucesso!");
            setActionStatus(0)
            onClose();
        } catch (error) {
            setActionStatus(0)
            alert(`Erro ao processar fechamento: ${error}`);
        }
    }

  
    useEffect(() => {
        async function BindingForm() {
            setListCompetencia(await myModule.getListCompetencia())
        }
        BindingForm()
    }, [])
    
    return (
        <div className="fixed inset-0 bg-black/30 backdrop-blur-sm flex items-center justify-center p-4 z-50">
            <div className="bg-white rounded-xl shadow-2xl w-full max-w-3xl max-h-[90vh] flex flex-col overflow-hidden">
                {/* Modal Header */}
                <HeaderMain header_title="Resultado | Fechamento" ActionStatus={ActionStatus} tipo="_MODAL">
                {/* Action Buttons */}
                <div className="flex space-x-2">
                    <ButtonPag TypeButton="_BUTTON_HEADER" label="Efetivar" TypeIcon="_SALVAR" title="Efetivar Registro" onClick={ResultadoFechamentoProcessar} ></ButtonPag>
                    <ButtonPag TypeButton="_BUTTON_HEADER" label="Voltar" TypeIcon="_NO_ICON" title="Voltar" onClick={onClose} ></ButtonPag>
                </div>              

                </HeaderMain>
                
                {/* Form Content */}
                <div className="p-6 overflow-y-auto flex-1">
                <div className="space-y-6">
                    <div className="grid gap-1">
                    <label className="block text-sm font-semibold text-gray-700 mb-1">
                        Competência <span className="text-red-500">*</span>
                    </label>
                    <select
                        className="w-full p-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-transparent transition-all
                                hover:border-gray-400 disabled:bg-gray-100 disabled:cursor-not-allowed"
                        value={CompetenciaFilter ? JSON.stringify(CompetenciaFilter) : ''}
                        onChange={(e) => {
                        const selectValue = e.target.value;
                        setFilterCompetencia(selectValue ? JSON.parse(selectValue) : null);
                        }}
                        disabled={ActionStatus === 1}
                    >
                        <option value="">Selecione uma competência</option>
                        {CompetenciaList.map((item) => (
                        <option 
                            key={item.competencia_cd} 
                            value={JSON.stringify(item)}
                            className="py-2"
                        >
                            {item.competencia_descricao}
                        </option>
                        ))}
                    </select>
                    </div>
                    
                    {/* Adicione mais campos aqui seguindo o mesmo padrão */}
                </div>
                </div>

            </div>
        </div>
        )
}