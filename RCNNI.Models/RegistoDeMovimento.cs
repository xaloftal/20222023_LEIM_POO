using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;
using RNCCI.Excecoes;

namespace RNCCI.Modelos
{
    public class RegistoDeMovimento
    {
        //variaveis
        private int numeroRegisto = 1000;

        /// <summary>
        /// construtor
        /// </summary>
        public RegistoDeMovimento() => this.NumeroRegisto = numeroRegisto++;


        /// <summary>
        /// numero do registo
        /// </summary>
        public int NumeroRegisto { get; set; }


        /// <summary>
        /// doente do registo
        /// </summary>
        public Doente Doente { get; set; }

        
        /// <summary>
        /// tipo de movimento
        /// </summary>
        public Movimento TipoMovimento { get; set; }


        /// <summary>
        /// data do movimento
        /// </summary>
        public DateTime DataMovimento { get; set; }

        /// <summary>
        /// unidade clinica de saida
        /// </summary>
        public UnidadeClinica Origem { get; set; }


        /// <summary>
        /// unidade clinica de entrada
        /// </summary>
        public UnidadeClinica Destino { get; set; }


        //metodo

        /// <summary>
        /// override do ToString()
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DadoNaoExisteException"></exception>
        public override string ToString()
        {
            string mensagem = $"\tRegisto de movimento n {this.NumeroRegisto}\n" +
            $"Doente: {this.Doente.Nome} (n utente: {this.Doente.NumeroUtente})\n\n" +
            $"Tipo de transferencia: {this.TipoMovimento}\n" +
            $"Data: {this.DataMovimento}\n\n";


            //output diferente, conforme o tipo de movimento
            switch (this.TipoMovimento)
            {
                case Movimento.Saida:                    
                    return mensagem + $"Unidade clinica de saida: {this.Origem}"; 
                case Movimento.Entrada:
                   return mensagem + $"Unidade clinica de entrada: {this.Destino}";                    
                case Movimento.Transferencia:
                  return mensagem + $"Unidade clinica de origem: {this.Origem} -> Unidade clinica: {this.Destino}";                    
                default:
                    throw new DadoNaoPrevistoException("RNCCI.Modelos.RegistoDeMovimento");                    
            }
        }
        
    }
}
