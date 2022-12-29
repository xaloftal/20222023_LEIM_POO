using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;
using RNCCI.Excecoes;
using RNCCI.Modelos;

namespace RNCCI.Dados
{
    public class RegistosDeMovimentos
    {
        //variaveis
        List<RegistoDeMovimento> registosMovimentos = new List<RegistoDeMovimento>();


        public void Add(RegistoDeMovimento novoRegisto)
        {
            //não pode ser nulo
            if (novoRegisto is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeMovimentos.Add");

            //nao pode existir
            if (this.registosMovimentos.Exists(m => m.NumeroRegisto.Equals(novoRegisto.NumeroRegisto)))
                throw new DadoJaExisteException("RNCCI.Dados.RegistosDeMovimentos.Add");

            //adiciona
            this.registosMovimentos.Add(novoRegisto);
        }

        public void Apaga(RegistoDeMovimento registoMovimento)
        {
            //não pode ser nulo
            if (registoMovimento is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeMovimentos.Apaga");

            //tem de existir
            if (!this.registosMovimentos.Exists(m => m.NumeroRegisto.Equals(registoMovimento.NumeroRegisto)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosDeMovimentos.Apaga");

            //encontra na lista
            int index = registosMovimentos.FindIndex(m => m.NumeroRegisto.Equals(registoMovimento.NumeroRegisto));

            //apaga
            registosMovimentos.RemoveAt(index);
        }

        public void Atualiza(RegistoDeMovimento registoMovimento)
        {
            //não pode ser nulo
            if (registoMovimento is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeMovimentos.Atualiza");

            //tem de existir
            if (!this.registosMovimentos.Exists(m => m.NumeroRegisto.Equals(registoMovimento.NumeroRegisto)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosDeMovimentos.Atualiza");

            //encontra na lista
            int index = registosMovimentos.FindIndex(m => m.NumeroRegisto.Equals(registoMovimento.NumeroRegisto));

            //atualiza a unidade
            registosMovimentos[index] = registoMovimento;
        }

        public void ExtratoMovimentosDoente(List<RegistoDeMovimento> registoMovimentos, Doente doente) => ImprimirExtratoMovimentos(this.registosMovimentos.Where(r => r.Doente.NumeroUtente.Equals(doente.NumeroUtente)).ToList());


        private void ImprimirExtratoMovimentos(List<RegistoDeMovimento> registoMovimentos )
        {
            foreach (RegistoDeMovimento registo in registoMovimentos)
            {
                Console.WriteLine(registoMovimentos.ToString());
            }
        }

    }
}
