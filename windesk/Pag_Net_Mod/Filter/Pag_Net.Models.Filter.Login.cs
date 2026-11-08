using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models.Filter
{
    public class Login
    {

        private string _email_main = "";
        public string email_main
        {
            get { return _email_main; }
            set
            {
                try
                {
                    if (value.Length > 1)
                    {
                        if (value.IndexOf("@") > 0)
                        {
                            _email_main = value;
                        }
                        else
                        {
                            throw new Exception("E-mail inválido");
                        }
                    }
                    else
                    {
                        _email_main = "";
                    }
                
                }
                catch (Exception ex)
                {
                    throw new Exception("Valor inválido: " + ex.Message);
                }
            }
        }
        public string passwd
        {
            get;
            set;
        }
        public string user_name
        {
            get;
            set;
        }

        public Login (string User_name, string Passwd, string Email_main)
        {
            user_name = User_name;
            passwd = Passwd;
            email_main = Email_main;
        }

        public Login (string Email_main, string Passwd)
        {
            email_main = Email_main;
            passwd = Passwd;
            user_name = "";
        }


    }
}