

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import { moduleFaturamento, type tpFaturamentoStatus } from "@/api/m0070_faturamento/moduleFaturamento";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";







type cmbProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: string;
    sis_ac_cd: number
}



export default function CmbFaturamentoStatus({ user, onChange, value, sis_ac_cd }: cmbProps) {

    
    const [List, setList] = useState<any[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
    const fetchData = async () => {
        try {
            const myModule = new moduleFaturamento(user, sis_ac_cd);
            
            const ListApi = await myModule.getFaturamentoStatusList();
            setList(ListApi);
        } catch (error) {
            console.error("Erro ao buscar dados do sistema:", error);
        }
    };

    fetchData();
}, []);
useEffect(() => {
    if (List.length >= 1) {
        onChange(List[0].statusfaturamento);
    }
}, [List]);


    return (
        <select
            value={value}
            onChange={handleChange}
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
