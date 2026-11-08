using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Linq;
using Pag_Net.Models;
using Pag_Net.Dal;
using System.Reflection;

namespace Pag_Net.Dal
{
    /*
    public class dalUserAccess
    {
        public TbSysUserInfo OpenUserAcess(string system_id, string environment, string network, string userId, string PassWord, string pathConfig)
        {
            TbSysUserInfo myPackageConnect = new TbSysUserInfo();
            myPackageConnect.User_environment = environment;
            myPackageConnect.System_id = system_id;
            myPackageConnect.NetWork = network;
            myPackageConnect.User_id = userId;
            myPackageConnect.User_password = PassWord;

            //________________________CONEXOES______________________________________________________________
            dalConfig x = new dalConfig();


            List<TbSysDatabase> lstSystemDataBase = new List<TbSysDatabase>();
            lstSystemDataBase.Add(x.AuthenticateConnection(environment, pathConfig));
            myPackageConnect.ListConnections = lstSystemDataBase.ToArray();


            //________________________ACESSOS_______________________________________________________________

            TbSystemLoginAccess GetListAccess = new TbSystemLoginAccess(myPackageConnect);
            myPackageConnect.ListAccess = GetListAccess.ListAccess;
            myPackageConnect.ListConnections = GetListAccess.ListConnection;





            return myPackageConnect;
        }

    }*/
}
