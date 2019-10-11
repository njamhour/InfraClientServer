using InfraClientServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraClientServer.DAL
{
    class AtributosDAO
    {

        private static List<Atributos> atributos = new List<Atributos>();
        public static bool CadastrarAtributos(Atributos a)
        {
            atributos.Add(a);
            return true;
        }

        public static List<Atributos> RetornarAtributos()
        {
            return atributos;
        }

        
    }
}
