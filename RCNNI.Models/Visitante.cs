using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class Visitante : Pessoa
    {
        //variaveis
        private int numeroVisitante=1000;

        /// <summary>
        /// construtor
        /// </summary>
        public Visitante() => this.NumeroVisitante += numeroVisitante;

        /// <summary>
        /// Doente a visitar
        /// </summary>
        public Doente Doente { get; set; }


        /// <summary>
        /// número atribuido a cada visitante
        /// </summary>
        public int NumeroVisitante { get; private set; }

        public override string ToString() => $"\tVisitante nº{this.NumeroVisitante}\n\n" +
            $"Nome: {this.Nome}\n" +
            $"Data de nascimento: {this.DataNascimento} ({2022-this.DataNascimento.Year} anos)\n" +
            $"Sexo: {this.Sexo}\n\n" +
            $"Doente autorizado a visitar: {this.Doente.Nome} (Utente nº{this.Doente.NumeroUtente})\n\n\n";
        
    }
}
