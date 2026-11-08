export class Login
{
    sis_us_seq : number
    cdpessoabluesoft : number
    user_name : string 
    status_bluesoft : string 
    sis_fc_cd: number 

    constructor(sis_us_seq: number, 
        cdpessoabluesoft: number, 
        user_name : string, 
        status_bluesoft : string, 
        sis_fc_cd: number
        )
    {
        this.sis_us_seq = sis_us_seq;
        this.cdpessoabluesoft = cdpessoabluesoft; 
        this.user_name = user_name;
        this.status_bluesoft = status_bluesoft;
        this.sis_fc_cd = sis_fc_cd;
    }

    static NewUsuarioFromRows(item : any) : Login
    {
            return new Login(
                item.sis_us_seq,
                item.cdpessoabluesoft,
                item.user_name,
                item.status_bluesoft,
                item.sis_fc_cd
            )
    }
}

export default Login;