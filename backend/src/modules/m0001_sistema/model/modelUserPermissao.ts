export default class ModelUserPermissao { 
        sis_cd : number
        sis_descricao : string 
        sis_us_seq: number
   		sis_fc_cd: number
		sis_ac_cd: number 
		sis_ac_descricao: string
		sis_ac_menu: string
		sis_ta_cd: number
		sis_ta_descricao : string
        sis_ac_gmenu_cd: number = 0
        sis_ac_gmenu: string = ''
        sis_ac_gmenu_sub: string = ''		
		sis_ac_gmenu_sub_item: string = ''
        sis_ac_href: string = ''
        sis_ac_modulo_menu_cd: number = 0
        sis_ac_modulo_menu_descricao: string = ''
        constructor() {
            this.sis_us_seq = 0
            this.sis_fc_cd = 0
            this.sis_ac_cd = 0
            this.sis_ac_descricao = ''
            this.sis_ac_menu = ''
            this.sis_ta_cd = 0
            this.sis_ta_descricao = ''
            this.sis_cd = 0
            this.sis_descricao = `` 
            this.sis_ac_modulo_menu_cd = 0
            this.sis_ac_modulo_menu_descricao = ''
        }

    public binding(item: any): void {
        try {
                if (item) {
                    this.sis_cd = item.sis_cd
                    this.sis_descricao = item.sis_descricao
                    this.sis_us_seq = item.sis_us_seq
                    this.sis_fc_cd = item.sis_fc_cd
                    this.sis_ac_cd = item.sis_ac_cd
                    this.sis_ac_descricao = item.sis_ac_descricao
                    this.sis_ac_menu = item.sis_ac_menu
                    this.sis_ta_cd = item.sis_ta_cd
                    this.sis_ta_descricao = item.sis_ta_descricao
                    this.sis_ac_gmenu_cd = item.sis_ac_gmenu_cd
                    this.sis_ac_gmenu = item.sis_ac_gmenu
                    this.sis_ac_gmenu_sub = item.sis_ac_gmenu_sub
                    this.sis_ac_gmenu_sub_item = item.sis_ac_gmenu_sub_item
                    this.sis_ac_href = item.sis_ac_href ? item.sis_ac_href : ''
                    this.sis_ac_modulo_menu_cd = item.sis_ac_modulo_menu_cd
                    this.sis_ac_modulo_menu_descricao = item.sis_ac_modulo_menu_descricao
                }
                
        } catch (e) {
            console.log(e)
        }
    }
}
