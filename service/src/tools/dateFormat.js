function dateFormat_yymmdd_hhmmss(date) {
    const dataformat = new Date() 

    var year = dataformat.getFullYear()
    var month = (dataformat.getMonth() + 101).toString().substring(1);
    var day = (dataformat.getDate() + 100).toString().substring(1);
    var hours = (dataformat.getHours() + 100).toString().substring(1);
    var minutes = (dataformat.getMinutes() + 100).toString().substring(1);
    var sec = (dataformat.getSeconds() + 100).toString().substring(1);
    return year + "-" + month + "-" + day + " " + hours + ":" + minutes + ":"  + sec
    
}


function dateFormat_yymmdd(date) {
    const dataformat = new Date() 

    var year = dataformat.getFullYear()
    var month = (dataformat.getMonth() + 101).toString().substring(1);
    var day = (dataformat.getDate() + 100).toString().substring(1);
    return year + "-" + month + "-" + day;
    
}

function dateFormat_default(){
    var data = new Date(),
        dia  = data.getDate().toString(),
        diaF = (dia.length == 1) ? '0'+dia : dia,
        mes  = (data.getMonth()+1).toString(), //+1 pois no getMonth Janeiro começa com zero.
        mesF = (mes.length == 1) ? '0'+mes : mes,
        anoF = data.getFullYear();
    return diaF+"/"+mesF+"/"+anoF;
}


module.exports = {dateFormat_yymmdd, dateFormat_default, dateFormat_yymmdd_hhmmss} ;    

