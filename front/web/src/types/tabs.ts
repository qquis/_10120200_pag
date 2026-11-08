export interface Tab {
  id: string;
  title: string;
  path: string;
  menuItem: any; // Tipo do seu menu item do banco
  isActive: boolean;
  canClose: boolean;
  timestamp: number; // Para ordenação por ordem de abertura
}

export interface TabsState {
  tabs: Tab[];
  activeTabId: string | null;
}
