using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class VisitanteNaoAutorizadoException : Exception
    {
        public VisitanteNaoAutorizadoException(String origem) => this.Source = origem;

        public override string Message => "Visitante nao autorizado!";
    }
}
