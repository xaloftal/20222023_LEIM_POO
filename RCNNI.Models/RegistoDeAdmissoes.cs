using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class RegistoDeAdmissoes
    {
        public Doente Doente { get; set; }

        public Visitante Visitante { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime DataSaida { get; set; } 

        
    }
}
