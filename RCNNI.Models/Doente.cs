using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;

namespace RNCCI.Modelos
{
    public class Doente : Pessoa
    {
        //variaveis
        private int numeroUtente = 1000;

        /// <summary>
        /// constructor
        /// </summary>
        public Doente() => this.NumeroUtente += numeroUtente; //voltamos a isto
        

        /// <summary>
                 /// Numero de utente de saude
                /// </summary>
        public int NumeroUtente { get; private set; }

        /// <summary>
        /// Data de nascimento do doente
        /// </summary>
        public DateOnly DataNascimento { get; set; }

        /// <summary>
        /// sexo do doente
        /// </summary>
        public Sexo Sexo { get; set; }

        /// <summary>
        ///  pessoas autorizadas a visita
        /// </summary>
        public Visitante[] VisitantesAutorizados { get; set; }

        /// <summary>
        /// Morada do doente
        /// </summary>
        public Morada Morada { get; set; }

        /// <summary>
        /// override do ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"\tUtente n{this.NumeroUtente}\n\n" +
            $"Nome: {this.Nome}\nData de nascimento: {this.DataNascimento} ({2022 - this.DataNascimento.Year} anos)\n" +
            $"Sexo: {this.Sexo}\n" +
            $"Morada: {this.Morada}\n" +
            $"Numero Telemovel: {this.NumeroTelemovel}\n\n" +
            $"Visitantes autorizados: {this.VisitantesAutorizados}\n\n\n";        
    }
}
