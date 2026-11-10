import pagApi from "@/api/api"

import * as XLSX from 'xlsx';
const LOCAL_SIS_CD : string = "5"

const url_service_login = '/sistema/service/login'
const url_model_login = '/sistema/model/userconnectget'

type menulist = { 
    sis_ac_modulo_menu_cd: number
    sis_ac_modulo_menu_descricao: string 
}

type modelUserPermissao = { 
        sis_cd : number
        sis_descricao : string 
        sis_us_seq: number
   		sis_fc_cd: number
		sis_ac_cd: number 
		sis_ac_descricao: string
		sis_ac_menu: string
		sis_ta_cd: number
		sis_ta_descricao : string
        sis_ac_modulo_menu_cd: number
        sis_ac_modulo_menu_descricao: string
        sis_ac_gmenu_cd: number
        sis_ac_gmenu: string 
        sis_ac_gmenu_sub: string 
		sis_ac_gmenu_sub_item: string
        sis_ac_href: string
}




export default class moduleUserConnect { 
    usuario_login_uuid: string = ``
    sis_us_seq: number
    user_name: string
    email_main: string
    cdparticipante: number = 0
    statusLogin: boolean
    nome_razao: string = ''
    PermissaoList: modelUserPermissao[] = []
    MenusList: menulist[] = []
    cdpessoabluesoft: number = 0
    user_credential: string = `` 
    NumeroDeAcesssos: number
    ambiente: string = ''

    
    
    
    //MENUS
    Menu_Gerencial: modelUserPermissao[] = [] 
    Menu_Sistema: modelUserPermissao[] = [] 
    Menu_Operacional: modelUserPermissao[] = [] 
    Menu_CRM: modelUserPermissao[] = [] 
    Menu_controller: modelUserPermissao[] = [] 
    Menu_Cadastro: modelUserPermissao[] = []

    constructor() {
        this.sis_us_seq = 0
        this.user_name = ''
        this.email_main = ''
        this.statusLogin = false
        this.cdpessoabluesoft = 0
        this.cdparticipante = 0
        this.nome_razao = `` 
        this.MenusList = []
        this.PermissaoList = []
        this.NumeroDeAcesssos = 0
        this.ambiente = "PRD"
        
    }

    bindingLogin(item : any) { 
        if (item) { 
            this.sis_us_seq = item?.sis_us_seq
            this.user_name = item?.user_name
            this.email_main = item?.email_main
            if (typeof item.usuario_login_uuid === "string") {
                this.usuario_login_uuid = item.usuario_login_uuid;
            }

                if (typeof item.user_credential === "string") {
                this.user_credential = item.user_credential;
            }

                if (typeof item.statusLogin === "boolean") {
                this.statusLogin = item.statusLogin;
            }
            this.nome_razao = item?.nome_razao
            this.cdparticipante = item?.cdparticipante
            this.cdpessoabluesoft = item?.cdpessoabluesoft

            this.ambiente = item?.ambiente || "PRD"

            //this.usuario_login_uuid = item?.usuario_login_uuid
            this.PermissaoList = []

            if (item?.PermissaoList) { 
                this.bindingPermissao(item?.PermissaoList)
                this.bidingMenu()
                this.Menu_Gerencial = this.getacessos("gerencial")
                this.Menu_Sistema = this.getacessos("sistema")
                this.Menu_Operacional = this.getacessos("operacional")
                this.Menu_CRM = this.getacessos("crm")
                this.Menu_controller = this.getacessos("controller")
                this.Menu_Cadastro = this.getacessos("cadastro")
                this.NumeroDeAcesssos = this.Menu_Gerencial.length + this.Menu_Sistema.length + this.Menu_Operacional.length + this.Menu_CRM.length + this.Menu_controller.length + this.Menu_Cadastro.length
                

            }
        }
    }

    async login(passwordText: string) : Promise<boolean> {
  
        this.statusLogin = false
        this.PermissaoList = [];        
        let pagApiLoginBodyInfo = { 
            sis_id : parseInt(LOCAL_SIS_CD),
            mail  : this.email_main,
            password : passwordText 
        }
        let pagDadosLogin : any = await pagApi.post('/sistema/service/login', pagApiLoginBodyInfo)
        if (pagDadosLogin.data) { 
            
            if (pagDadosLogin?.data.autorizado == 1){

                this.statusLogin = true
                this.sis_us_seq = pagDadosLogin.data.sis_us_seq
                this.user_credential = pagDadosLogin.data.user_credential
                this.usuario_login_uuid = pagDadosLogin.data.usuario_login_uuid
                let dadosUsuario = await pagApi.get(`/sistema/model/userconnectget?sis_cd=${LOCAL_SIS_CD}&sis_us_seq=${this.sis_us_seq}`)
                this.bindingLogin(dadosUsuario)
            }
        }

        return this.statusLogin;
    }


    async loginCheck(hash: string) : Promise<boolean> {
   
        this.statusLogin = false

        let pagApiLoginBodyInfo = { 
            mail : this.email_main,
            usuario_login_uuid  : this.usuario_login_uuid       
             
        }
        let pagDadosLogin : any = await pagApi.post('/sistema/service/loginCheck', pagApiLoginBodyInfo)
        if (pagDadosLogin.data) { 
            
            if (pagDadosLogin?.data.autorizado == 1){

                this.statusLogin = true
                this.sis_us_seq = pagDadosLogin.data.sis_us_seq
                this.user_credential = pagDadosLogin.data.user_credential 
                this.usuario_login_uuid = pagDadosLogin.data.usuario_login_uuid

            }
        }
        return this.statusLogin;
    }

    bindingPermissao(item : any ) {
        if (item) { 
            for (let i = 0; i < item.length; i++) { 
                let myPermissao : modelUserPermissao = {
                    sis_cd: item[i].sis_cd,
                    sis_descricao: item[i].sis_descricao,
                    sis_us_seq: item[i].sis_us_seq,
                    sis_fc_cd: item[i].sis_fc_cd,
                    sis_ac_cd: item[i].sis_ac_cd,
                    sis_ac_descricao: item[i].sis_ac_descricao,
                    sis_ac_menu: item[i].sis_ac_menu,
                    sis_ta_cd: item[i].sis_ta_cd,
                    sis_ta_descricao: item[i].sis_ta_descricao,
                    sis_ac_modulo_menu_cd: item[i].sis_ac_modulo_menu_cd,
                    sis_ac_modulo_menu_descricao: item[i].sis_ac_modulo_menu_descricao,
                    sis_ac_gmenu_cd: item[i].sis_ac_gmenu_cd,
                    sis_ac_gmenu: item[i].sis_ac_gmenu,
                    sis_ac_gmenu_sub: item[i].sis_ac_gmenu_sub,
                    sis_ac_gmenu_sub_item: item[i].sis_ac_gmenu_sub_item,
                    sis_ac_href: item[i].sis_ac_href ? item[i].sis_ac_href : ''
                }
                this.PermissaoList.push(myPermissao)
            }
        }
    }

    bidingMenu() { 
        this.MenusList = []

        let localMenusList : menulist[] = []

        if (this.PermissaoList) { 
            for (let i = 0; i < this.PermissaoList.length; i++) { 
                let myMenu : menulist = {
                    sis_ac_modulo_menu_cd: this.PermissaoList[i].sis_ac_modulo_menu_cd,
                    sis_ac_modulo_menu_descricao: this.PermissaoList[i].sis_ac_modulo_menu_descricao
                }
                if (localMenusList.findIndex((menu) => menu.sis_ac_modulo_menu_cd === myMenu.sis_ac_modulo_menu_cd) === -1) {
                    localMenusList.push(myMenu) 
                }
            }
        }

        this.MenusList = localMenusList.sort((a, b) => a.sis_ac_modulo_menu_cd - b.sis_ac_modulo_menu_cd);

    }

    getacessos(menu: string) : modelUserPermissao[] {
        let result : modelUserPermissao[] =  this.PermissaoList.filter(
            (permissao) => 
                 permissao.sis_ac_modulo_menu_descricao.toLowerCase() == menu.toLocaleLowerCase()
                 && permissao.sis_ta_cd == 1                  
        );
        return result
    }

    async getPermissaoCheck(sis_ac_cd: number, sis_ta_cd: number) : Promise<boolean> {
        let result : modelUserPermissao[] =  this.PermissaoList.filter(
            (permissao) => 
                 permissao.sis_ac_cd == sis_ac_cd
                 && permissao.sis_ta_cd == sis_ta_cd                  
        );
        return result.length > 0
    }

    async get<T>(url : string) : Promise<T> { 
        try { 
            //const result = await pagApi.pagApiget<T>(this.user_credential, url)
            const result = await pagApi.pagApiget<T>(this.usuario_login_uuid, url)
            
            return result

        } catch (e) { 
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }

    async post(url : string , object : object = {}) : Promise<object> { 
        try { 

            //const result = await pagApi.pagApipost(this.user_credential, url, object)
            const result = await pagApi.pagApipost(this.usuario_login_uuid, url, object)
            return result 

        } catch (e) { 
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }
    /**
     * Converte uma string de data (yyyy-MM-dd) para um objeto Date,
     * ajustando para evitar problemas de fuso horário.
     */
    stringToDate(dateString: string): Date {
         // Divide a string da data em partes
            const parts = dateString.split('-');
            // Cria a data no horário LOCAL (não UTC)
            // Nota: O mês é 0-based (janeiro = 0)
            return new Date(
                parseInt(parts[0]), // ano
                parseInt(parts[1]) - 1, // mês
                parseInt(parts[2]) // dia
            );
    }

    /**
     * Formata um objeto Date para o formato yyyy-MM-dd (usado em inputs type="date"),
     * ajustando para o fuso horário local.
     */
    dateToInputFormat(date: Date): string {
        if (!date) return '';
        
        // Se for string, converte para Date primeiro
        if (typeof date === 'string') {
            date = this.stringToDate(date);
            // Se a conversão falhar, retorna string vazia
            if (!date || isNaN(date.getTime())) return '';
        }
        
        // Agora verifica se é um Date válido
        if (!(date instanceof Date) || isNaN(date.getTime())) return '';
    
        const pad = (num: number) => num.toString().padStart(2, '0');
        
        return [
            date.getFullYear(),
            pad(date.getMonth() + 1),
            pad(date.getDate())
        ].join('-');
    }

    formatCurrency = (value: number) => {
        if (!Number.isFinite(value)) return '0,00'
        return new Intl.NumberFormat('pt-BR', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
        }).format(value)
    }

    toNumber = (value: unknown): number => {
        if (typeof value === 'number') return Number.isFinite(value) ? value : 0
        if (typeof value === 'string') {
        const normalized = value.replace(',', '.')
        const parsed = Number(normalized)
        return Number.isFinite(parsed) ? parsed : 0
        }
        return 0
    
    }

    formatNumber = (value: any, numdecimal : number = 2, pontoMilhares: boolean = false): string => {
        if (value === null || value === undefined || value === '') return '0,00';
        const num = parseFloat(value);
        if (isNaN(num)) return '0,00';
        let formatted = num.toFixed(numdecimal).replace('.', ',');
        if (pontoMilhares) {
            formatted = formatted.replace(/\B(?=(\d{3})+(?!\d))/g, '.');
        }
        return formatted;
    };

    emailValidate = (email: string): boolean => {
        const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@(([^<>()[\]\.,;:\s@"]+\.)+[^<>()[\]\.,;:\s@"]{2,})$/i;
        return re.test(String(email).toLowerCase());
    };

    formatDateToStringYYYMMDD = (dateValue: string | Date): string => {
        if (!dateValue) return '';
        
        let date: Date;
        
        // Se for string
        if (typeof dateValue === 'string') {
            // Se já estiver no formato YYYY-MM-DD, retorna como está
            if (/^\d{4}-\d{2}-\d{2}$/.test(dateValue)) {
                return dateValue;
            }
            // Converte string para Date
            date = new Date(dateValue);
        } 
        // Se for Date
        else if (dateValue instanceof Date) {
            date = dateValue;
        }
        // Se não for nem string nem Date, retorna vazio
        else {
            return '';
        }
        
        // Verifica se a data é válida
        if (isNaN(date.getTime())) return '';
        
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');
        
        return `${year}-${month}-${day}`;
    }   

  formatDateTimeToStringYYYMMDDHHMMSS = (dateValue: string | Date): string => {
    if (!dateValue) return '';
    
    let date: Date;
    
    // Se for string
    if (typeof dateValue === 'string') {
        // Converte string para Date
        date = new Date(dateValue);
    } 
    // Se for Date
    else if (dateValue instanceof Date) {
        date = dateValue;
    }
    // Se não for nem string nem Date, retorna vazio
    else {
        return '';
    }
    
    // Verifica se a data é válida
    if (isNaN(date.getTime())) return '';
    
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    const seconds = String(date.getSeconds()).padStart(2, '0');
    
    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
  }

  formatDateDDMMYYYY = (dateValue: string): string => {
      
    let date = new Date();

    if (dateValue) { 
        date = new Date(dateValue);
    }
        
    
    try {
      let date = new Date(dateValue);



      if (isNaN(date.getTime())) return dateValue; // Se não conseguir converter, retorna o valor original
      
      const year = date.getFullYear();
      const month = String(date.getMonth() + 1).padStart(2, '0');
      const day = String(date.getDate()).padStart(2, '0');
      
      return `${day}/${month}/${year}`;
    } catch (error) {
      return dateValue; // Em caso de erro, retorna o valor original
    }
  };
  formatDateTimeNowToStrNameFile() : string {
    const now = new Date();
    const year = now.getFullYear();
    const month = String(now.getMonth() + 1).padStart(2, '0');
    const day = String(now.getDate()).padStart(2, '0');
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');
    const seconds = String(now.getSeconds()).padStart(2, '0');
    return `PRIME_${year}-${month}-${day}-${hours}H${minutes}M${seconds}S`;
  }

  async exportTxt(filename: string, content: string): Promise<void> {
    const blob = new Blob([content], { type: 'text/plain;charset=utf-8' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
  };

  formatDateNowToStr() : string { 
      const now = new Date()
  const local = new Date(now.getTime() - now.getTimezoneOffset() * 60000)
  return local.toISOString().split("T")[0]
  } 

  exportGridToExcel (
  rows: any[],
  filePrefix: string,
  mapper: (row: any) => Record<string, any>
    ) : void {
  if (!rows || rows.length === 0) {
    alert("Não há dados para exportar");
    return;
  }

  const dataToExport = rows.map(mapper);

  const wb = XLSX.utils.book_new();
  const ws = XLSX.utils.json_to_sheet(dataToExport);

  ws["!cols"] = Object.keys(dataToExport[0]).map(() => ({ wch: 18 }));

  XLSX.utils.book_append_sheet(wb, ws, "Dados");

  const timestamp = new Date().toISOString().slice(0, 19).replace(/:/g, "-");
  XLSX.writeFile(wb, filePrefix + this.formatDateTimeNowToStrNameFile() + ".xlsx");
};


getCurrentYear = (): number => new Date().getFullYear();
getCurrentMonth = (): number => new Date().getMonth() + 1;
getCurrentDate = () => new Date().toISOString().slice(0, 10);

}


