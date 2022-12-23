using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class Doente : Pessoa
    {
        /// <summary>
        /// Numero de utente de saude
        /// </summary>
        public int NumeroUtente { get; set; }

        /// <summary>
        /// Lista de pessoas autorizadas a visita
        /// </summary>
        public List<Visitante> VisitantesAutorizados { get; set; }

    }
}
