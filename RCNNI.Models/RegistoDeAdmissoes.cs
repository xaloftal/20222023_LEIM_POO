using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class RegistoDeAdmissoes
    {
        //variaveis
        private int numeroRA=1000;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="visitante">visitante</param>
        public RegistoDeAdmissoes(Visitante visitante)
        {
            this.NumeroRA += numeroRA;
            this.Visitante = visitante;
        }

        //propriedades

        /// <summary>
        /// Numero do registo de Admissoes
        /// </summary>
        public int NumeroRA { get; private set; }

        /// <summary>
        ///Doente referente
        /// </summary>
        public Doente Doente { get; set; }

        /// <summary>
        /// Visitante
        /// </summary>
        public Visitante Visitante { get; set; }

        /// <summary>
        /// Data e hora de entrada
        /// </summary>
        public DateTime DataEntrada { get; set; }

        /// <summary>
        /// Data e hora de saida
        /// </summary>
        public DateTime DataSaida { get; set; } 

        // OVERRIDE DO TOSTRING()
        
    }
}
