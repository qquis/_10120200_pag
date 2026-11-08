


export default class tbfc_cbenef { 
    fc_cbenef_cd : string 
    fc_cbenef_bluesoft_cd : number 
    fc_cbenef_dispositivo : string 
    fc_cbenef_objetivo : string 
    fc_cbenef_bluesoft_dispositivo : string 
    fc_cbenef_bluesoft_objetivo : string 
    fc_cbenef_bluesoft : number 
    constructor() 
    {
        this.fc_cbenef_cd = ''
        this.fc_cbenef_bluesoft_cd = 0
        this.fc_cbenef_dispositivo = ''
        this.fc_cbenef_objetivo = ''
        this.fc_cbenef_bluesoft_dispositivo = ''
        this.fc_cbenef_bluesoft_objetivo = ''
        this.fc_cbenef_bluesoft = 0
    }

    binding(item: any) {
        if (item) {
            this.fc_cbenef_cd = item?.fc_cbenef_cd
            this.fc_cbenef_bluesoft_cd = item?.fc_cbenef_bluesoft_cd
            this.fc_cbenef_dispositivo = item?.fc_cbenef_dispositivo
            this.fc_cbenef_objetivo = item?.fc_cbenef_objetivo
            this.fc_cbenef_bluesoft_dispositivo = item?.fc_cbenef_bluesoft_dispositivo
            this.fc_cbenef_bluesoft_objetivo = item?.fc_cbenef_bluesoft_objetivo
            this.fc_cbenef_bluesoft = item?.fc_cbenef_bluesoft
        }
    }
}