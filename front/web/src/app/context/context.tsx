'use client';
import { createContext, useContext, useState, ReactNode, useEffect } from "react";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";

interface AuthContextType {
  user: moduleUserConnect;
  sessionReady: boolean;
  login: (email_main: string, password: string) => void;
  logout: () => void;
  openSession: () => void;
  check: () => Promise<boolean>;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

// ==================== CONFIGURAÇÕES DE TEMPO ====================
const SESSION_DURATION = 24 * 60 * 60 * 1000; // 24 horas (controle da aplicação)
const CHECK_INTERVAL = 3 * 60 * 60 * 1000; // Verifica a cada 3 horas
const RENEWAL_THRESHOLD = 1 * 60 * 60 * 1000; // Renova quando restam 1 hora
const TIME_TOLERANCE = 5 * 60 * 1000; // 5 minutos de tolerância
const SESSION_STORAGE_KEY = "pag.auth.session";

interface StoredSession {
  user: Record<string, unknown>;
  loginTime: number;
}

// ==================== UTILITÁRIOS DE COOKIE ====================
const getCookie = (name: string): string | null => {
  if (typeof window === 'undefined') return null;
  
  const nameEQ = name + "=";
  const ca = document.cookie.split(';');
  
  for (let i = 0; i < ca.length; i++) {
    let c = ca[i];
    while (c.charAt(0) === ' ') c = c.substring(1, c.length);
    if (c.indexOf(nameEQ) === 0) return c.substring(nameEQ.length, c.length);
  }
  return null;
};

const deleteCookie = (name: string) => {
  if (typeof window === 'undefined') return;
  
  document.cookie = `${name}=;expires=Thu, 01 Jan 1970 00:00:01 GMT;path=/;samesite=strict`;
};

const readStoredSession = (): StoredSession | null => {
  if (typeof window === "undefined") return null;

  const storedSession = window.localStorage.getItem(SESSION_STORAGE_KEY);
  if (!storedSession) return null;

  const parsedSession = JSON.parse(storedSession) as Partial<StoredSession>;
  if (
    !parsedSession.user ||
    typeof parsedSession.user !== "object" ||
    typeof parsedSession.loginTime !== "number"
  ) {
    throw new Error("Dados da sessão local inválidos.");
  }

  return parsedSession as StoredSession;
};

const saveSession = (user: moduleUserConnect, loginTime: number): void => {
  if (typeof window === "undefined") return;

  window.localStorage.setItem(
    SESSION_STORAGE_KEY,
    JSON.stringify({ user, loginTime })
  );
};

// ==================== UTILITÁRIOS DE TEMPO ====================
const getCurrentTime = (): number => Date.now();



const isSessionValid = (loginTimestamp: number): boolean => {
  const currentTime = getCurrentTime();
  const timeElapsed = currentTime - loginTimestamp;
  return timeElapsed <= (SESSION_DURATION + TIME_TOLERANCE);
};

const shouldRenewSession = (loginTimestamp: number): boolean => {
  const currentTime = getCurrentTime();
  const timeElapsed = currentTime - loginTimestamp;
  const timeRemaining = SESSION_DURATION - timeElapsed;
  return timeRemaining <= RENEWAL_THRESHOLD && timeRemaining > 0;
};

// ==================== PROVIDER PRINCIPAL ====================
const AuthProvider = ({ children }: { children: ReactNode }) => {
  // Estado inicial do usuário
  const createEmptyUser = (): moduleUserConnect => {
    const user = new moduleUserConnect();
    user.user_name = '';
    user.statusLogin = false;
    return user;
  };

  const [user, setUser] = useState<moduleUserConnect>(createEmptyUser());
  const [sessionReady, setSessionReady] = useState<boolean>(false);

  // ==================== EFFECTS ====================
  useEffect(() => {
    void openSession();
    
    // Verifica a sessão a cada 3 horas
    const intervalId = setInterval(() => {
      checkAndManageSession();
    }, CHECK_INTERVAL);
    
    return () => clearInterval(intervalId);
  }, []);

  // ==================== GERENCIAMENTO DE SESSÃO ====================
  const checkAndManageSession = async (): Promise<void> => {
    try {
      const session = readStoredSession();
      if (!session) {
        if (user.statusLogin) {
          handleSessionExpired("Sessão local não encontrada");
        }
        return;
      }
      
      const loginTimestamp = session.loginTime;
      
      // Verifica se a sessão expirou
      if (!isSessionValid(loginTimestamp)) {
        handleSessionExpired("Sessão expirou por tempo");
        return;
      }
      
      // Auto-renovação se necessário
      if (shouldRenewSession(loginTimestamp) && user.statusLogin) {
        await renewSession();
      }
      
    } catch (error) {
      console.error("Erro ao verificar sessão:", error);
      if (user.statusLogin) {
        handleSessionExpired("Erro na verificação");
      }
    }
  };

  const renewSession = async (): Promise<void> => {
    try {
      const session = readStoredSession();
      
      if (!session || !user.statusLogin) {
        return;
      }
      
      saveSession(user, getCurrentTime());
      
      //console.log("Sessão renovada automaticamente");
      
    } catch (error) {
      console.error("Erro ao renovar sessão:", error);
    }
  };

  const handleSessionExpired = (reason: string): void => {
    //console.log(`Sessão expirada: ${reason}`);
    logout();
    
    // Mostra alerta apenas se o usuário estava logado
    if (user.statusLogin) {
      alert("Sua sessão expirou. Faça login novamente.");
    }
  };

  // ==================== FUNÇÕES PRINCIPAIS ====================
  const openSession = async (): Promise<boolean> => {
    setSessionReady(false);

    try {
      let session = readStoredSession();

      // Migra sessões antigas que eram guardadas integralmente em cookies.
      if (!session) {
        const userCookie = getCookie("user");
        const loginTimeCookie = getCookie("loginTime");
        if (userCookie && loginTimeCookie) {
          session = {
            user: JSON.parse(decodeURIComponent(userCookie)) as Record<string, unknown>,
            loginTime: Number(loginTimeCookie),
          };
        }
      }

      if (!session) {
        setUser(createEmptyUser());
        return false;
      }
      
      // Verifica se a sessão ainda é válida
      if (!Number.isFinite(session.loginTime) || !isSessionValid(session.loginTime)) {
        clearSessionData();
        setUser(createEmptyUser());
        return false;
      }
      
      // Restaura o usuário
      const restoredUser = new moduleUserConnect();
      restoredUser.bindingLogin(session.user);
      if (!restoredUser.user_name || !restoredUser.usuario_login_uuid) {
        clearSessionData();
        setUser(createEmptyUser());
        return false;
      }

      restoredUser.statusLogin = true;
      setUser(restoredUser);
      saveSession(restoredUser, session.loginTime);
      deleteCookie("user");
      deleteCookie("loginTime");
      
      return true;
      
    } catch (error) {
      console.error("Erro ao abrir sessão:", error);
      clearSessionData();
      setUser(createEmptyUser());
      return false;
    } finally {
      setSessionReady(true);
    }
  };

  const login = async (email_main: string, password: string): Promise<void> => {
    // Limpa estado anterior
    setUser(createEmptyUser());
    clearSessionData();
    
    const newUser = new moduleUserConnect();
    newUser.email_main = email_main;
    newUser.PermissaoList = [];

    try {
      await newUser.login(password);
      
      if (newUser.statusLogin) {
        saveSession(newUser, getCurrentTime());
        setUser(newUser);
        
        //console.log("Login realizado com sucesso");
        
      } else {
        setUser(createEmptyUser());
        throw new Error("Credenciais inválidas.");
      }
      
    } catch (error) {
      setUser(createEmptyUser());
      console.error("Erro ao fazer login:", error);
      throw error instanceof Error ? error : new Error("Erro ao fazer login.");
    }
  };

  const check = async (): Promise<boolean> => {
    try {
      // Verifica os cookies primeiro
      const loginTime = getCookie("loginTime");
      const session = readStoredSession();
      const sessionLoginTime = session?.loginTime ?? (loginTime ? Number(loginTime) : null);

      if (sessionLoginTime === null) {
        return false;
      }
      
      const loginTimestamp = sessionLoginTime;
      
      if (!isSessionValid(loginTimestamp)) {
        logout();
        return false;
      }
      
      if (!user.statusLogin) {
        return false;
      }
      
      // Verifica com o servidor
      //const serverCheck = await user.loginCheck(user.user_credential);
      const serverCheck = await user.loginCheck(user.usuario_login_uuid);
      user.statusLogin = serverCheck;
      
      if (user.statusLogin) {
        // Renova se necessário
        if (shouldRenewSession(loginTimestamp)) {
          await renewSession();
        }
      } else {
        logout();
      }
      
      return user.statusLogin;
      
    } catch (error) {
      console.error("Erro ao verificar sessão:", error);
      logout();
      return false;
    }
  };

  const logout = (): void => {
    clearSessionData();
    setUser(createEmptyUser());
    
    // Emite evento para outros componentes
    if (typeof window !== 'undefined') {
      window.dispatchEvent(new CustomEvent('userLogout'));
    }
    
    //console.log("Logout realizado");
  };

  // ==================== UTILITÁRIOS INTERNOS ====================
  const clearSessionData = (): void => {
    if (typeof window !== "undefined") {
      window.localStorage.removeItem(SESSION_STORAGE_KEY);
    }
    deleteCookie("user");
    deleteCookie("loginTime");
  };

  // ==================== PROVIDER ====================
  return (
    <AuthContext.Provider value={{
      user,
      sessionReady,
      login,
      logout,
      openSession,
      check
    }}>
      {children}
    </AuthContext.Provider>
  );
};

// ==================== HOOK ====================
const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth deve ser usado dentro de um AuthProvider");
  }
  return context;
};

export { AuthProvider, useAuth };