using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Pag_Net.src.F0045_Preco.model
{
    
        [DataContract]
        public class ModelBackEnd_Preco_Aplicar
        {
            [DataMember(Name = "status")]
            public bool status { get; set; }

            public ModelBackEnd_Preco_Aplicar() { }


            public static ModelBackEnd_Preco_Aplicar getJson(string json)
            {
                var x = new DataContractJsonSerializer(typeof(ModelBackEnd_Preco_Aplicar));
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {

                    return (ModelBackEnd_Preco_Aplicar)x.ReadObject(ms);

                }
            }
        }

    

}
