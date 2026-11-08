const datanow = function(format = 'log', int = 0) {

    let d = new Date();




// formatar data no formato ISO 8601
    var iso = d.getFullYear().toString() + "-";
    iso += d.getMonth().toString().padStart(2, '0') + "-";
    iso += d.getDate().toString().padStart(2, '0') + "T";
    iso += d.getHours().toString().padStart(2, '0') + ":";
    iso += d.getMinutes().toString().padStart(2, '0') + ":";
    iso += d.getSeconds().toString().padStart(2, '0');
    //console.log(iso); // 2018-10-17T14:22:29

if (format == "report") {
    var dt = new Date();

   iso = `${
    (dt.getMonth()+1).toString().padStart(2, '0')}/${
    dt.getDate().toString().padStart(2, '0')}/${
    dt.getFullYear().toString().padStart(4, '0')} ${
    dt.getHours().toString().padStart(2, '0')}:${
    dt.getMinutes().toString().padStart(2, '0')}:${
    dt.getSeconds().toString().padStart(2, '0')}`
    }

    return iso
}

module.exports = datanow