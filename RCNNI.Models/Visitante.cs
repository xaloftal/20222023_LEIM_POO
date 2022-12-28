using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class Visitante : Pessoa
    {
        //variaveis
        private int numeroVisitante=1000;

        /// <summary>
        /// construtor
        /// </summary>
        public Visitante() => this.NumeroVisitante += numeroVisitante;
        

        /// <summary>
        /// número atribuido a cada visitante
        /// </summary>
        public int NumeroVisitante { get; private set; }
    }
}
