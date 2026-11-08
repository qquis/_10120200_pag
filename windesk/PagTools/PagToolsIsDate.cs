using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Tools
{
    public class IsDate
    {
        public static bool check(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if ((dt.Month != System.DateTime.Now.Month) || (dt.Day < 1 && dt.Day > 31) || dt.Year != System.DateTime.Now.Year)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
