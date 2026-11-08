using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Tools
{
    public static class PagToolsIsCdBarra
    {
        public static bool Valid (string Str)
        {
            bool result = false;
            char[] list = Str.ToCharArray();
            string NumerosValidos = "0123456789";


            for (int i = 0; i <= list.Count() - 1; i++ )
            {

                if(NumerosValidos.IndexOf(list[i]) >= 0)
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            return result;


        }
    }
}
