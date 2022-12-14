using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class RequesicaoHTTPFalhouException : Exception
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="origem">onde a excecao foi atirada</param>
        public RequesicaoHTTPFalhouException(string origem) => this.Source = origem;

        /// <summary>
        /// mensagem da excecao
        /// </summary>
        public override string Message => "A requesicao HTTP falhou";
        
    }
}
