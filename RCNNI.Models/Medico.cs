using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class Medico : Pessoa
    {
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
