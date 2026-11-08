const pagToolsDate = {
    
    GetDateTimeptBr: (datestring: string | any) : Date => {
        try {

                    let dateComponents = datestring.split(' ');
                   
                    let datePieces  = dateComponents[0].split("/");
                    let time = dateComponents[1].split(":");

                    let dia: number = Number(datePieces[0])
                    let mes: number = Number(datePieces[1])
                    let ano: number = Number(datePieces[2])
                    let hora: number = Number(time[0])
                    let minuto: number = Number(time[1])
                    let segundo: number = Number(time[2])

                    const data_f = new Date(); 
                    data_f.setFullYear(ano)
                    data_f.setMonth(mes - 1)
                    data_f.setDate(dia); 
                    data_f.setUTCHours(hora + 3, minuto, segundo,0)

                    return data_f
                }
                catch (e)
                {
                    console.log(`Error GetDateTimeptBr ${e} ` )
                    return new Date(1900,0,1)
                }
            
            }
    
    ,

    

    getDateFromString: (date_yyyy_dd_dd: string) : Date => {
        return new Date(date_yyyy_dd_dd + "T00:00:00")    
    },

    getStringDate_yyyymmdd_hhmmss: (date: Date ) : string => {
        return `${date.toISOString().substring(0,10)} 00:00:00`
        
    },
    str_yyyymmdd: (date: Date ) : string => {
        return date.toISOString().substring(0,10)
    },

    
    getStringDateTime: (date: Date ) : string => {

        let options: object = {     
            year: 'numeric', 
            month: '2-digit', 
            day: '2-digit', 
            //hour: 'numeric' || '2-digit',
            //minute: 'numeric' || '2-digit',
            //second: 'numeric' || '2-digit', 
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit', 
            hour12: false
            
        }
        return `${date.toLocaleDateString('pt-BR',options)}`
    },

    getStringDate: (date: Date ) : string => {
        return `${pagToolsDate.getStringDateTime(date).split(' ')[0]}`
    },

    getStringDateToPostgre: (date: Date ) : string => {

        let options: object = {     
            year: 'numeric', 
            month: '2-digit', 
            day: '2-digit', 
        }

        let string_to_postgre = `${date.toLocaleDateString('pt-BR',options)}`.split("/")
        return `${string_to_postgre[2]}-${string_to_postgre[1]}-${string_to_postgre[0]}`
    },

    
    getStringDateTimeToPostgre: (date: Date ) : string => {
        return `${pagToolsDate.getStringDateToPostgre(date)} ${pagToolsDate.getStringDateTime(date).split(" ")[1]}`
    }
}

export default pagToolsDate

