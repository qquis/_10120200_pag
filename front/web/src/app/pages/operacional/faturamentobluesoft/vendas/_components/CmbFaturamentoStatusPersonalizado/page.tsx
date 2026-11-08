

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import {tpFaturamentoBlueSoftStatus} from "@/api/m0050_faturamentoBluesoft/moduleFaturamentoBluesoft";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";







type cmbProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: number;
    sis_ac_cd: number
    listFaturamentoStatusPersonalizado: tpFaturamentoBlueSoftStatus[]
    disabled?: boolean
}



export default function CmbFaturamentoBluesoftStatusPersonalizado({ user, onChange, value, sis_ac_cd, listFaturamentoStatusPersonalizado, disabled = false }: cmbProps) {

    
    const [List, setList] = useState<tpFaturamentoBlueSoftStatus[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
        const fetchFaturamentoStatus = async () => {
            try {

                setList(listFaturamentoStatusPersonalizado);
            } catch (error) {
                console.error('Erro ao buscar status de faturamento:', error);
            }
        };

        fetchFaturamentoStatus();
    }, []);

useEffect(() => {
    if (List.length >= 1) {
        onChange(List[0].statusfaturamento.toString());
    }
}, [List]);


    return (
        <select
            value={value}
            onChange={handleChange}
            disabled={disabled}
            className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
        >

            {List.map((item) => (
                <option key={item.statusfaturamento} value={item.statusfaturamento}>
                    {item.statusfaturamento_descricao}
                </option>
            ))}
        </select>
    );
}   
