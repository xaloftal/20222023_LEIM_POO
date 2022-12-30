using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public class RegistoDeVisitantes
    {
        //variaveis
        private int numeroRV=1000;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="visitante">visitante</param>
        public RegistoDeVisitantes(Visitante visitante, RegistoClinico registoClinico, DateTime entrada, DateTime saida)
        {
            this.NumeroRV += numeroRV;
            this.Visitante = visitante;
            this.RegistoClinico = registoClinico;
            this.DataEntrada = entrada;
            this.DataSaida = saida;

        }

        /// <summary>
        /// segundo construtor
        /// </summary>
        public RegistoDeVisitantes() => this.NumeroRV = numeroRV++;

        //propriedades

        /// <summary>
        /// Numero do registo de Admissoes
        /// </summary>
        public int NumeroRV { get; private set; }


        /// <summary>
        ///Doente referente
        /// </summary>
        public RegistoClinico RegistoClinico { get; set; }


        /// <summary>
        /// Visitante
        /// </summary>
        public Visitante Visitante { get; set; }

        /// <summary>
        /// unidade clinica que entrou 
        /// </summary>
        public UnidadeClinica UnidadeClinica { get; set; }

        /// <summary>
        /// Data e hora de entrada
        /// </summary>
        public DateTime DataEntrada { get; set; }

        /// <summary>
        /// Data e hora de saida
        /// </summary>
        public DateTime DataSaida { get; set; }


        //metodo

        /// <summary>
        /// override do metodo ToString();
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"\tRegisto Visitante n {this.NumeroRV}\n" +
            $"unidade Clinica: {this.UnidadeClinica.Nome}, {this.UnidadeClinica.Morada.Distrito}\n\n" +
            $"Doente Visitado: {this.RegistoClinico.Doente.Nome} (n utente: {this.RegistoClinico.Doente.NumeroUtente})\n" +
            $"Visitante: {this.Visitante.Nome} (n visitante: {this.Visitante.NumeroVisitante})\n\n" +
            $"Data e Hora de entrada: {this.DataEntrada}\n" +
            $"Data e Hora de saida: {this.DataSaida}\n\n\n";
        

    }
}
