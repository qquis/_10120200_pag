using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Pag_Net.src.F0085_zanthus.model
{
    [DataContract]
    public class modelResultadoCarga
    {
        [DataMember(Name = "integracao_tipo_cd")]
        public int integracao_tipo_cd { get; set; }

        [DataMember(Name = "integracao_tipo_descricao")]
        public string integracao_tipo_descricao { get; set; }

        [DataMember(Name = "tipoCarga")]
        public string tipoCarga { get; set; }

        [DataMember(Name = "integracao_pendente_qtde")]
        public int integracao_pendente_qtde { get; set; }

        [DataMember(Name = "integracao_qtde_promocional")]
        public int integracao_qtde_promocional { get; set; }

        

        public modelResultadoCarga() { constructor(); }

        private void constructor()
        {
            this.integracao_tipo_cd = 0;
            this.integracao_tipo_descricao = "";
            this.tipoCarga = "";
            this.integracao_pendente_qtde = 0;
            this.integracao_qtde_promocional = 0;
        }


        public static modelResultadoCarga getJson(string json)
        {
            var x = new DataContractJsonSerializer(typeof(modelResultadoCarga));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                return (modelResultadoCarga)x.ReadObject(ms);

            }
        }
    }

}
