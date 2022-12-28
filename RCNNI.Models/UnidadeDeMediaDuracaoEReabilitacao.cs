using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class UnidadeDeMediaDuracaoEReabilitacao : UnidadeClinica
    {
        //variveis
        private int numeroUMDR = 1000;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="camasDisponiveis">camas disponeiveis para a unidade</param>
        public UnidadeDeMediaDuracaoEReabilitacao(int camasDisponiveis)
        {
            this.NumeroUMDR += numeroUMDR;
            this.Cama = new Cama[camasDisponiveis];
        }

        public int NumeroUMDR { get; private set; }
    }
}
