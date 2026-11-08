
'use client';
import { createContext, useContext, useState, ReactNode, useEffect } from "react";
import moduleUserConnect from "../api/m0001_sistema/moduleUserConnect";
import { moduleParticipanteCrm, TpParticipanteCRM } from '../api/m0011_participante/moduleparticipante';

interface AuthContextType {
  //user: moduleUserConnect | null;
  user: moduleUserConnect;
  cliente: TpParticipanteCRM | null;
  login_getcredentialnumber: (email_main: string) => Promise<void>;
  login: (user_credential_number: string) => Promise<void>;
  logout: () => void;
  openSession: () => void;
  check: () => Promise<boolean>;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

const AuthProvider = ({ children }: { children: ReactNode }) => {


  const userNaoDefinido: moduleUserConnect = new moduleUserConnect()
  
  userNaoDefinido.user_name = `` 
  userNaoDefinido.statusLogin = false;

  const [user, setUser] = useState<moduleUserConnect>(userNaoDefinido);
  const [cliente, setCliente] = useState<TpParticipanteCRM | null>(null);
  

  useEffect(() => {
    openSession();
  }, []);

const login_getcredentialnumber = async(email_main: string) : Promise<void> => {
  let myUser = new moduleUserConnect();
  myUser.user_credential
  myUser.email_main = email_main;

  try {
    await myUser.login_getCredentialNumber(email_main)
    setUser(myUser);
    sessionStorage.removeItem("user_credential")
    sessionStorage.setItem("user_credential", myUser.user_credential);

    // Cookie mais compatível com mobile (remover Secure se não for HTTPS)
    const isHttps = typeof window !== 'undefined' && window.location.protocol === 'https:';
    const secureFlag = isHttps ? '; Secure' : '';
    
    document.cookie = `user_credential=${myUser.user_credential}; path=/; max-age=600; SameSite=Lax${secureFlag}`;
    
    console.log('Cookie definido:', document.cookie); // Debug

  } catch (error) {
    console.error("Erro ao obter credencial do usuário:", error);
    throw new Error("Erro ao obter credencial do usuário.");
  }
}

const login = async (credential_number_digitado: string) => {
    try {
        console.log('=== INICIANDO LOGIN ===');
        console.log('User antes do login:', user);
        
        await user.login(credential_number_digitado);
        
        console.log('User após login:', {
            autorizado: user.autorizado,
            statusLogin: user.statusLogin,
            user_name: user.user_name,
            email_main: user.email_main
        });
        
        if (user.autorizado === 1) { 
            const myModuleCliente = new moduleParticipanteCrm();
            const mycliente = await myModuleCliente.consultar({ crm_email: user.email_main});
          
            if (mycliente) {
                setCliente(mycliente);
            }
        }

        // Salvar usuário completo na sessão após login bem-sucedido
        const userToSave = {
            user_name: user.user_name,
            user_credential: user.user_credential,
            statusLogin: user.statusLogin,
            autorizado: user.autorizado,
            email_main: user.email_main
        };
        
        console.log('Salvando no sessionStorage:', userToSave);
        sessionStorage.setItem("user", JSON.stringify(userToSave));
        
        // Verificar se foi salvo corretamente
        const verificacao = sessionStorage.getItem("user");
        console.log('Verificação sessionStorage após salvar:', verificacao);
        
        // Atualizar cookie JWT com 10 minutos
        document.cookie = `user_credential=${user.user_credential}; path=/; max-age=600; SameSite=Strict; Secure`;
        
    } catch (error) {
        setUser(userNaoDefinido);
        console.error("Erro ao fazer login:", error);
        throw new Error("Erro ao fazer login.");
    }
}


const openSession = async() => { 
    try {
        console.log('=== INICIANDO openSession ===');
        
        // Verificar se sessionStorage está disponível
        if (typeof window === 'undefined' || !window.sessionStorage) {
            console.log('SessionStorage não disponível');
            setUser(userNaoDefinido);
            return false;
        }

        const storedUser = sessionStorage.getItem("user");
        console.log('StoredUser do sessionStorage:', storedUser);
        
        if (storedUser) {
            const parsedUser = JSON.parse(storedUser);
            console.log('ParsedUser:', parsedUser);
            
            const myUser = new moduleUserConnect();
            myUser.bindingLogin(parsedUser);
            
            console.log('MyUser após bindingLogin:', {
                user_name: myUser.user_name,
                user_credential: myUser.user_credential,
                statusLogin: myUser.statusLogin,
                autorizado: myUser.autorizado
            });
            
            
            console.log('XXX MyUser user_credential:', myUser.user_credential);
            console.log("XXX Ver se está autorizado", myUser.autorizado);
            
            
            
            // Verificar se o usuário tem credenciais válidas
            if (myUser.user_credential && myUser.autorizado === 1) {
                setUser(myUser);
                
                // Tentar carregar dados do cliente se autorizado
                /* (myUser.autorizado) {
                    try {
                        const myModuleCliente = new moduleParticipanteCrm();
                        const mycliente = await myModuleCliente.consultar({ crm_email: myUser.email_main });
                        console.log('Cliente carregado:', mycliente);
                        if (mycliente) {
                            setCliente(mycliente);
                        }
                    } catch (clienteError) {
                        console.error('Erro ao carregar cliente:', clienteError);
                    }
                }*/
                
                return true;
            } else {
                console.log('Usuário sem credenciais válidas, removendo da sessão');
                sessionStorage.removeItem("user");
                setUser(userNaoDefinido);
                return false;
            }
        }
        
        console.log('Nenhum usuário armazenado, definindo usuário não definido');
        setUser(userNaoDefinido);
        return false;
        
    } catch (error) {
        console.error("Error loading user from session:", error);
        //setUser(userNaoDefinido);
        return false;
    }
}

const check = async () : Promise<boolean> => {
    try {
      // Verificar se o cookie user_credential existe e está dentro do prazo
      if (typeof document === 'undefined') return false;
      
      const cookies = document.cookie.split(';');
      const userCredentialCookie = cookies.find(cookie => 
        cookie.trim().startsWith('user_credential=')
      );
      
      // Se não existe cookie ou está vazio, retorna false
      if (!userCredentialCookie) {
        console.log('Cookie user_credential não encontrado');
        return false;
      }
      
      const cookieValue = userCredentialCookie.split('=')[1]?.trim();
      if (!cookieValue || cookieValue === '') {
        console.log('Cookie user_credential está vazio');
        return false;
      }
      
      // Se chegou até aqui, o cookie existe e tem valor
      // Como o cookie tem max-age=600 (10 minutos), se ele existe, está válido
      console.log('Cookie user_credential válido encontrado');
      return true;
      
    } catch (e) {
      console.error("Error checking cookie:", e);
      return false;
    }
  }


const logout = () => {
    // Tornar logout idempotente: se já está deslogado, sair sem setState
    if (!user || (user.user_credential === '' && user.statusLogin === false)) {
      return;
    }

    // Remover chaves específicas em vez de limpar toda a sessão (evita efeitos colaterais)
    try {
      sessionStorage.removeItem("user");
      sessionStorage.removeItem("user_credential");
    } catch (e) {
      // ignore
    }

    const userNUll = new moduleUserConnect();
    userNUll.user_name = '';
    userNUll.statusLogin = false;
    userNUll.user_credential = '';

    setUser(userNUll);

    // Emite evento para que outros componentes possam reagir ao logout
    if (typeof window !== 'undefined') {
      window.dispatchEvent(new CustomEvent('userLogout'));
    }
  };

  return (
    <AuthContext.Provider value={{ user, cliente, login, logout, openSession, check, login_getcredentialnumber }}>
      {children}
    </AuthContext.Provider>
  );
};

const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("useAuth must be used within an AuthProvider");
  return context;
};


export { AuthProvider, useAuth };