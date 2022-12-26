using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class Medico : Pessoa
    {
        //variaveis
        private int numeroMedico = 1000;

        /// <summary>
        /// Constructor
        /// </summary>
        public Medico() => this.CodigoMedico += numeroMedico;
        
        //propriedades
        /// <summary>
        /// código de identificação do profissional
        /// </summary>
        public int CodigoMedico { get; set; }


        /// <summary>
        /// Especialidade do médico
        /// </summary>
        public string Especialidade { get; set; }
    }
}
