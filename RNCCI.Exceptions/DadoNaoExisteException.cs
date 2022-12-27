using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class DadoNaoExisteException : Exception
    {
        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="origem">onde a excecao foi atirada</param>
        public DadoNaoExisteException(string origem) => this.Source = origem;

        /// <summary>
        /// mensagem da excecao
        /// </summary>
        public override string Message => "O que pretende realizar é impossível, dado nao existente";
        
    }
}
