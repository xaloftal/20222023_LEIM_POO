using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class DadosNulosException : Exception
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="origem">onde a excecao foi atirada</param>
        public DadosNulosException(string origem) => this.Source = origem;

        /// <summary>
        /// mensagem da excecao
        /// </summary>
        public override string Message => "Os dados não podem ser nulos para efetuar esta operacao";
       
    }
}
