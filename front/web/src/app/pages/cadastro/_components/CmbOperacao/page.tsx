

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import { moduleEnterprise } from "@/api/m0002_enterprise/moduleEnterprise"; 
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";







type cmbProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: string;
    sis_ac_cd: number
}



export default function CmbOperacao({ user, onChange, value, sis_ac_cd }: cmbProps) {

    
    const [List, setList] = useState<any[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
    const fetchData = async () => {
        try {
            const myModule = new moduleEnterprise(user, sis_ac_cd);
            const ListApi = await myModule.getEmpresaOperacaoList()
            setList(ListApi);
        } catch (error) {
            console.error("Erro ao buscar dados do sistema:", error);
        }
    };

    fetchData();
}, []);
useEffect(() => {
    if (List.length >= 1) {
        onChange(List[0].op_cdoperacao);
    }
}, [List]);


    return (
        <select
            value={value}
            onChange={handleChange}
            className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
        >

            {List.length > 1 && <option value="0">TODOS</option>}
            {List.map((item) => (
                <option key={item.op_cdoperacao} value={item.op_cdoperacao}>
                    {item.op_descricao}
                </option>
            ))}
                        
        </select>
    );
}   
