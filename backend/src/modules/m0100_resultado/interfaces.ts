/*Interfaces -----------------------------------------------------------------------------------------------------*/
interface ifilter {
    competencia_cd : number,
    op_cdoperacao? : number, 
    r_resp_cd?: number, 
    r_centro_op_cd?: number, 
    r_cd: number

}
export  {
    ifilter
}