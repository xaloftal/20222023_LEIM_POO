using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class CodigoPostalInvalidoException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="origem">onde a excecao foi atirada</param>
        public CodigoPostalInvalidoException(string origem) => this.Source = origem;

        /// <summary>
        /// Mensagem da excecao
        /// </summary>
        public override string Message => "O codigo postal inserido é invalido";        
    }
}
