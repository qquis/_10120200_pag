'use client'
import PagSubMenu from "@/app/components/pagsubmenu";
import { useAuth } from "@/app/context/context";

export default function GerencialPage() {
  const { user } = useAuth();

  return (
    <PagSubMenu
      title="Gerencial"
      items={user?.Menu_Gerencial}
      info=""
      gridClassName="grid grid-cols-1 md:grid-cols-1 gap-2"
      groupTitleClassName="text-md font-semibold mb-4 text-gray-700 border-b border-gray-300 pb-2"
    />
  );
}