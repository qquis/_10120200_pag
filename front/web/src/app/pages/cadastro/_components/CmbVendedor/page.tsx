

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import { moduleParticipante } from "@/api/m0011_Participante/moduleParticipante";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";







type cmbProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: string;
    sis_ac_cd: number
    onLoadComplete?: () => void;
}



export default function CmbVendedor({ user, onChange, value,sis_ac_cd, onLoadComplete }: cmbProps) {

    
    const [List, setList] = useState<any[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
    let active = true;
    const fetchData = async () => {
        try {
            const myModule = new moduleParticipante(user, sis_ac_cd);
            const ListApi = await myModule.getPagVendedorList()
            if (active) setList(ListApi);
        } catch (error) {
            console.error("Erro ao buscar dados do sistema:", error);
        } finally {
            if (active) onLoadComplete?.();
        }
    };

    fetchData();
    return () => { active = false; };
}, []);
useEffect(() => {
    if (List.length === 1) {
        onChange(List[0].cdparticipante);
    }
}, [List]);

    return (
        <select
            value={value}
            onChange={handleChange}
            className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
        >
            {List && List.length > 1 && <option value="0">Selecione um vendedor</option>}
            {List && List.length > 0 && List.map((item) => (
                <option key={item.cdparticipante} value={item.cdparticipante}>
                    {item.nome_razao}
                </option>
            ))}
        </select>
    );
}   
