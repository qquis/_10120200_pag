

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import { moduleSistema } from "@/api/m0001_sistema/moduleSistema";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";







type cmbSistemaProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: string;
}



export default function CmbSistemaFuncao({ user, onChange, value }: cmbSistemaProps) {

    const myModuleSistema = new moduleSistema(user);
    const [List, setList] = useState<any[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
    const fetchData = async () => {
        try {
            const myList = await myModuleSistema.getSistemaFuncaoList();
            setList(myList);
        } catch (error) {
            console.error("Erro ao buscar dados do sistema:", error);
        }
    };

    fetchData();
}, []);

    return (
        <select
            value={value}
            onChange={handleChange}
            className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
        >
            <option value="0">Selecione uma função</option>
            {List.map((item) => (
                <option key={item.sis_fc_cd} value={item.sis_fc_cd}>
                    {item.sis_fc_descricao}
                </option>
            ))}
        </select>
    );
}   
