

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import { moduleSistema } from "@/api/m0001_sistema/moduleSistema";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";







type cmbSistemaProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: string;
}



export default function CmbSistema({ user, onChange, value }: cmbSistemaProps) {

    const myModuleSistema = new moduleSistema(user);
    const [List, setList] = useState<any[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
    const fetchData = async () => {
        try {
            const sistemaList = await myModuleSistema.getSistemaList();
            setList(sistemaList);
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
            <option value="0">Selecione um sistema</option>
            {List.map((item) => (
                <option key={item.sis_cd_pk} value={item.sis_cd_pk}>
                    {item.sis_descricao}
                </option>
            ))}
        </select>
    );
}   
