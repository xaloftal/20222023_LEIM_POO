using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class EquipaDomiciliariaDeCuidadosContinuidadesIntegrados : UnidadeClinica
    {
        //variveis
        private int numeroEDCCI = 1000;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="camasDisponiveis">camas disponiveis para a unidade</param>
        public EquipaDomiciliariaDeCuidadosContinuidadesIntegrados(int camasDisponiveis)
        {
            this.NumeroEDCCI = numeroEDCCI++;
            this.Cama = new Cama[camasDisponiveis];
            this.Tipologia = Enums.Tipologia.EquipaDomiciliariaDeCuidadosContinuidadesIntegrados;
        }

        //propriedade

        /// <summary>
        /// numero da equipa domiciliaria de cuidados continuidades integrados
        /// </summary>
        public int NumeroEDCCI { get; set; }


        //metodo

        /// <summary>
        /// override do metodo ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int camasLivres = this.Cama.Where(c => c.Livre).Count();

            return $"\tNumero clinica EDCCi n{this.NumeroEDCCI}\n\n" + base.ToString();
        }
    }
}
