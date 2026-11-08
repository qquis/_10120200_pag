'use client';
import { useAuth } from "./context/context";
import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";
import { usePathname } from "next/navigation";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";

export default function Protect({ children }: { children: React.ReactNode }) {
  const { user, login, openSession} = useAuth();
  const router = useRouter();
  const pathname = usePathname()
  const [autenticado, setAutenticado] = useState(true);

  useEffect(() => {
      // Se não houver usuário no contexto, busca da sessão
      // Se não houver usuário e não estiver na página de login, redireciona
    /*if (!user) { 
      const userData = sessionStorage.getItem("user")
      if (userData)
      {
        console.log("localizou o user data")
        let Myuser : moduleUserConnect = new moduleUserConnect() 
        Myuser = JSON.parse(userData) 
        
      }
    }
    
    if (!user?.user_name && pathname !== "/public") {
      router.push("/login");
    }

    if (user && pathname === "/") {
      router.push("/pages");
    }*/

    const autenticar = async() => { 
        if (!user)
          await openSession()
        setAutenticado(false);
        if(!user?.user_name && pathname !== "/public" && pathname !== "/login") {
            router.push("/login") 
        }

        if (user?.user_name && (pathname === "/" || pathname === "/login")) { 
          router.push("/pages")
        }
      }

      autenticar();
    }, [user]);

  const shouldRender = user?.user_name || ['/login', '/public', '/404'].includes(pathname);
  
  return <>{shouldRender ? children : null}</>;
}