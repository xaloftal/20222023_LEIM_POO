using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;
using RNCCI.Excecoes;

namespace RNCCI.Modelos
{
    public class UnidadeClinica
    {
        //variaveis de estado
        int numeroClinica = 1000;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="nome">nome da clinica</param>
        /// <param name="distrito">distrito da clinica</param>
        public UnidadeClinica() => this.NumeroClinica = numeroClinica++;


        //propriedades

        /// <summary>
        /// camas da unidade
        /// </summary>
        public Cama[] Cama { get; set; }

        
        /// <summary>
        /// numero de identificacao da clinica
        /// </summary>
        public int NumeroClinica { get; private set; }


        /// <summary>
        /// nome da clinica
        /// </summary>
        public string Nome { get; set; }


        /// <summary>
        /// Morada
        /// </summary>
        public Morada Morada { get; set; }


        /// <summary>
        /// Tipologia de resposta
        /// </summary>
        public Tipologia Tipologia { get; set; }

        //metodo

        /// <summary>
        /// override ao metodo ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int camasLivres = this.Cama.Where(c => c.Livre).Count();

            return $"\tNumero clinica n{this.NumeroClinica}\n\n" +
            $"Nome: {this.Nome}" +
            $"Morada: {this.Morada}\n" +
            $"Camas disponiveis: {camasLivres}\n\n\n";
        }
    }
}
