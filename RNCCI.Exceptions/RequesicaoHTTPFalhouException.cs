using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class RequesicaoHTTPFalhouException : Exception
    {
        public RequesicaoHTTPFalhouException(string origem) => this.Source = origem;

        public override string Message => "A requesicao HTTP falhou";
        
    }
}
