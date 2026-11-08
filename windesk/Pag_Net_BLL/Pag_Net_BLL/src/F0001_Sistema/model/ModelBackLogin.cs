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
    public class ModelBackEndLogin
    {
        [DataMember(Name = "sis_id")]
        public int sis_id { get; set;  }

        [DataMember(Name = "usuario_login_uuid")]
        public string usuario_login_uuid { get; set; }

        [DataMember(Name = "sis_us_seq")]
        public int sis_us_seq { get; set; }

        [DataMember(Name = "user_name")]
        public string user_name { get; set; }

        [DataMember(Name = "autorizado")]
        public int autorizado { get; set; }


        [DataMember(Name = "email_login")]
        public string email_login { get; set; }

        [DataMember(Name = "password")]
        public string password { get; set; }

        public ModelBackEndLogin() { constructor(); } 

        private void constructor() {
            this.autorizado = 0;
            this.usuario_login_uuid = "";
            this.user_name = "";
            this.password = "";
            this.sis_id = 0;
            this.sis_us_seq = 0;
        }


        public static ModelBackEndLogin getJson(string json) 
        {
            var x = new DataContractJsonSerializer(typeof(ModelBackEndLogin));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                return (ModelBackEndLogin)x.ReadObject(ms);
                
            }
        }
    }

}
