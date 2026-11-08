

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import { moduleSistema } from "@/api/m0001_sistema/moduleSistema";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";


import PrimeComboBox from "@/app/components/ComboBox/combobox";




type cmbSistemaProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: string;
}



export default function CmbSistemaAcesso({ user, onChange, value }: cmbSistemaProps) {

    const myModuleSistema = new moduleSistema(user);
    const [List, setList] = useState<any[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
    const fetchData = async () => {
        try {
            const myList = await myModuleSistema.getSistemaAcessoList();
            setList(myList);
        } catch (error) {
            console.error("Erro ao buscar dados do sistema:", error);
        }
    };

    fetchData();
}, []);

    return (
        <PrimeComboBox value={value} onChange={handleChange}>       
            <option value="0">Selecione um acesso</option>
            {List.map((item) => (
                <option key={item.sis_ac_cd} value={item.sis_ac_cd}>
                    {item.sis_descricao} - {item.sis_ac_descricao}
                </option>
            ))}
        </PrimeComboBox>
    );
}   
