using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;

namespace RNCCI.Modelos
{
    /// <summary>
    /// Esta classe representa uma cama
    /// </summary>
    public class Cama
    {
        //variaveis
        private int numeroCama = 1000;

        /// <summary>
        /// Construtor
        /// </summary>
        public Cama()
        {
            this.Livre = true;
            this.NumeroCama = numeroCama++;
        }


        //propriedades

        /// <summary>
        /// Doente correspondente
        /// </summary>
        public Doente Doente { get; set; }

        public int NumeroCama { get; set; }
        
        /// <summary>
        /// permite verificar se cama está livre ou não no sistema
        /// </summary>
        public bool Livre { get; set; }       
    }
}
