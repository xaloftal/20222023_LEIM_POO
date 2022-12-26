using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;

namespace RNCCI.Modelos
{
    public class RegistoClinico
    {
        /// <summary>
        /// Doente 
        /// </summary>
        public Doente Doente { get; set; }

        /// <summary>
        /// médico responsável
        /// </summary>
        public Medico Medico { get; set; }

        public Cama Cama { get; set; }

        public string Diagnostico { get; set; }

        public DateOnly DataAdmissao { get; set; }

        public DateOnly DataAlta { get; set; }

        public Tipologia Tipologia { get; set; }   
    }
}
