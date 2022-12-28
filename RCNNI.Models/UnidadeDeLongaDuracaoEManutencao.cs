using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class UnidadeDeLongaDuracaoEManutencao : UnidadeClinica
    {
        //variveis
        private int numeroULDM = 1000;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="camasDisponiveis">camas disponiveis para a unidade</param>
        public UnidadeDeLongaDuracaoEManutencao(int camasDisponiveis)
        {
            this.NumeroULDM += numeroULDM;
            this.Cama = new Cama[camasDisponiveis];
            this.Tipologia = Enums.Tipologia.UnidadeDeLongaDuracaoEManutencao;
        }


        //propriedades

        /// <summary>
        /// Numero da unidade de longa duracao e manutencao
        /// </summary>
        public int NumeroULDM { get; private set; }
    }
}
