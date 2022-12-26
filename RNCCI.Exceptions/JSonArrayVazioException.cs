using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class JSonArrayVazioException : Exception
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="origem">onde a excecao foi atirada</param>
        public JSonArrayVazioException(string origem) => this.Source = origem;

        /// <summary>
        /// mensagem da excecao
        /// </summary>
        public override string Message => "O array Json deverá ter pelo emnos um valor atribuido";
    }
}
