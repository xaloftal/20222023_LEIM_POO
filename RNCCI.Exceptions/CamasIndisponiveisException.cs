using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class CamasIndisponiveisException : Exception
    {
        public CamasIndisponiveisException(String origem) => this.Source = origem;

        public override string Message => "Não há camas disponíveis para esta tipologia!";
    }
}
