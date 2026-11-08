

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import {moduleFaturamentoBluesoft, tpFaturamentoBlueSoftStatus} from "@/api/m0050_faturamentoBluesoft/moduleFaturamentoBluesoft";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";







type cmbProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: number;
    sis_ac_cd: number
    ListFaturamentoBlueSoftStatus: tpFaturamentoBlueSoftStatus[]
    disabled?: boolean
}



export default function CmbFaturamentoBluesoftStatus({ user, onChange, value, sis_ac_cd, ListFaturamentoBlueSoftStatus, disabled = false }: cmbProps) {

    
    const [List, setList] = useState<tpFaturamentoBlueSoftStatus[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
        const fetchFaturamentoStatus = async () => {
            try {

                setList(ListFaturamentoBlueSoftStatus);
            } catch (error) {
                console.error('Erro ao buscar status de faturamento:', error);
            }
        };

        fetchFaturamentoStatus();
    }, []);

useEffect(() => {
    if (List.length >= 1) {
        onChange(List[0].fat_blue_status_cd.toString());
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
                <option key={item.fat_blue_status_cd} value={item.fat_blue_status_cd}>
                    {item.fat_blue_status_descricao}
                </option>
            ))}
        </select>
    );
}   
