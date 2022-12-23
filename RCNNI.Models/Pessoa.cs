using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public abstract class Pessoa
    {
        /// <summary>
        /// nome da pessoa
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// numero de telemovel da pessoa
        /// </summary>
        public int NumeroTelemovel { get; set; }

        /// <summary>
        /// NIF da pessoa
        /// </summary>
        public int NumeroContribuinte { get; set; }

        /// <summary>
        /// email da pessoa
        /// </summary>
        public string Email { get; set; }
              


    }
}
