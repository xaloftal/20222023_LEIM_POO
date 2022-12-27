using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;

namespace RNCCI.Modelos
{
    public class Doente : Pessoa
    {
        //variaveis
        private int numeroUtente = 1000;

        /// <summary>
        /// constructor
        /// </summary>
        public Doente() => this.NumeroUtente += numeroUtente;
        

        /// <summary>
                 /// Numero de utente de saude
                 /// </summary>
        public int NumeroUtente { get; private set; }

        /// <summary>
        /// Data de nascimento do doente
        /// </summary>
        public DateOnly DataNascimento { get; set; }

        /// <summary>
        /// sexo do doente
        /// </summary>
        public Sexo Sexo { get; set; }

        /// <summary>
        /// Lista de pessoas autorizadas a visita
        /// </summary>
        public List<Visitante> VisitantesAutorizados { get; set; }

        /// <summary>
        /// Morada do doente
        /// </summary>
        public Morada Morada { get; set; }
        

    }
}
