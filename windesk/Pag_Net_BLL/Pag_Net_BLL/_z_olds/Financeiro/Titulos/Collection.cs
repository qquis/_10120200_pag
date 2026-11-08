using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Financeiro.Titulos
{
    public class Collection
    {
        public USPTituloEspecie Especie;
        public UspTitulos List;
        Models.modelSistemaUsuario MyConnect;
        public Collection (Models.modelSistemaUsuario __myConnect)
        {

            MyConnect = __myConnect;
            Especie = new USPTituloEspecie(MyConnect);
            List = new UspTitulos(MyConnect);

        }

        public void Pagamento(Pag_Net.Bll.Financeiro.Titulos.UVWTitulo[] _listTitulos)
        {
            
        }
    }
}
