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
        public RegistoDeMovimento()
        {
            this.NumeroRegisto = numeroRegisto++;
        }

        public int NumeroRegisto { get; set; }

        public Doente Doente { get; set; }

        public Movimento TipoMovimento { get; set; }

        public DateTime DataMovimento { get; set; }

        public UnidadeClinica Origem { get; set; }

        public UnidadeClinica Destino { get; set; }


        public override string ToString()
        {
            string mensagem = $"\tRegisto de movimento n {this.NumeroRegisto}\n" +
            $"Doente: {this.Doente.Nome} (n utente: {this.Doente.NumeroUtente})\n\n" +
            $"Tipo de transferencia: {this.TipoMovimento}\n" +
            $"Data: {this.DataMovimento}\n\n";

            switch (this.TipoMovimento)
            {
                case Movimento.Saida:                    
                    return mensagem + $"Unidade clinica de saida: {this.Origem}"; 
                case Movimento.Entrada:
                   return mensagem + $"Unidade clinica de entrada: {this.Destino}";                    
                case Movimento.Transferencia:
                  return mensagem + $"Unidade clinica de origem: {this.Origem} -> Unidade clinica: {this.Destino}";                    
                default:
                    throw new DadoNaoExisteException("RNCCI.Modelos.RegistoDeMovimento");                    
            }
        }
        
    }
}
