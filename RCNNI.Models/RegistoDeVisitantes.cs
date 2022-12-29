using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class RegistoDeVisitantes
    {
        //variaveis
        private int numeroRV=1000;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="visitante">visitante</param>
        public RegistoDeVisitantes(Visitante visitante, RegistoClinico registoClinico, DateTime entrada, DateTime saida)
        {
            this.NumeroRV += numeroRV;
            this.Visitante = visitante;
            this.Doente = registoClinico.Doente;
            this.DataEntrada = entrada;
            this.DataSaida = saida;

        }

        public RegistoDeVisitantes()
        {
            this.NumeroRV += numeroRV;

        }

        //propriedades

        /// <summary>
        /// Numero do registo de Admissoes
        /// </summary>
        public int NumeroRV { get; private set; }

        /// <summary>
        ///Doente referente
        /// </summary>
        public Doente Doente { get; set; }

        /// <summary>
        /// Visitante
        /// </summary>
        public Visitante Visitante { get; set; }

        public UnidadeClinica UnidadeClinica { get; set; }

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
