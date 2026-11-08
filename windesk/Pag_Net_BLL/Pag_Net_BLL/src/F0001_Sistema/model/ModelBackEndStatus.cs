using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Pag_Net.src.F0001_Sistema.model
{
    [DataContract]
    public class ModelBackEndStatus
    {
        [DataMember(Name = "status")]
        public int status { get; set;  }

        [DataMember(Name = "info")]
        public string info { get; set; }


        public ModelBackEndStatus() {  }


        public static ModelBackEndStatus getJson(string json) 
        {
            var x = new DataContractJsonSerializer(typeof(ModelBackEndStatus));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                
                 return (ModelBackEndStatus)x.ReadObject(ms);
                
            }
        }
    }

}
