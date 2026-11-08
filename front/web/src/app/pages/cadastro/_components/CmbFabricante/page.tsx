import { useEffect, useMemo, useState } from "react";
import { moduleParticipante } from "@/api/m0011_Participante/moduleParticipante";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";

type cmbProps = {
  user: moduleUserConnect;
  onChange: (value: string) => void;
  value: string;
  sis_ac_cd: number;
};

export default function CmbFabricante({ user, onChange, value, sis_ac_cd }: cmbProps) {
  const [List, setList] = useState<any[]>([]);
  const [query, setQuery] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const myModule = new moduleParticipante(user, sis_ac_cd);
        const ListApi = await myModule.getPagFabricanteList();
        setList(ListApi);
      } catch (error) {
        console.error("Erro ao buscar dados do sistema:", error);
      }
    };

    fetchData();
  }, [user, sis_ac_cd]);

  useEffect(() => {
    const selected = List.find(
      (item) => String(item.cdparticipante) === String(value)
    );
    setQuery(selected?.nome_razao ?? "");
  }, [List, value]);

  const filteredList = useMemo(() => {
    const q = query.toLowerCase();
    return List.filter((item) =>
      item.nome_razao?.toLowerCase().includes(q)
    );
  }, [List, query]);

  const handleSelect = (text: string) => {
    const selected = List.find(
      (item) => item.nome_razao?.trim().toLowerCase() === text.trim().toLowerCase()
    );

    if (selected) {
      onChange(String(selected.cdparticipante));
      setQuery(selected.nome_razao);
    } else {
      onChange("");
    }
  };

  return (
    <div className="w-full">
      <input
        type="text"
        value={query}
        onChange={(e) => {
          setQuery(e.target.value);
          onChange("");
        }}
        onBlur={() => handleSelect(query)}
        placeholder="Digite o fabricante"
        list="fabricantes-list"
        className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
      />

      <datalist id="fabricantes-list">
        {filteredList.map((item) => (
          <option key={item.cdparticipante} value={item.nome_razao} />
        ))}
      </datalist>
    </div>
  );
}
