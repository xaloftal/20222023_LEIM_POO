using RNCCI.Enums;
using RNCCI.Excecoes;
using RNCCI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Dados
{
    public class Doentes
    {
        //variaveis
        List<Doente> doentes = new List<Doente>();

        /// <summary>
        /// construtor
        /// </summary>
        public Doentes()
        {
            doentes.Add(new Doente { Nome = "Manel Figueiras", NumeroContribuinte = 4325, NumeroTelemovel = 934656324 });
            doentes.Add(new Doente { Nome = "Joaquina Almeida", NumeroContribuinte = 4095, NumeroTelemovel = 934436324 });
        }

        //metodos

        /// <summary>
        /// adiciona um doente
        /// </summary>
        /// <param name="novoDoente">doente a adicionar</param>
        /// <exception cref="DadosNulosException">novoDoente e nulo</exception>
        /// <exception cref="DadoJaExisteException">o doente ja existe no sistema</exception>
        public void Add(Doente novoDoente)
        {
            //não pode ser nulo
            if (novoDoente is null)
                throw new DadosNulosException("RNCCI.Dados.Doentes.Add");

            //nao pode existir
            if (this.doentes.Exists(d => d.NumeroUtente.Equals(novoDoente.NumeroUtente)))
                throw new DadoJaExisteException("RNCCI.Dados.Doentes.Add");

            //adiciona
            this.doentes.Add(novoDoente);
        }



        /// <summary>
        /// elimina doentes do sistema
        /// </summary>
        /// <param name="doente">doente a eliminar</param>
        /// <exception cref="DadosNulosException">doente e nulo</exception>
        /// <exception cref="DadoNaoExisteException">doente nao existe no sistema</exception>
        public void Apaga(Doente doente)
        {
            //não pode ser nulo
            if (doente is null)
                throw new DadosNulosException("RNCCI.Dados.Doentes.Apaga");

            //tem de existir
            if (!this.doentes.Exists(d => d.NumeroUtente.Equals(doente.NumeroUtente)))
                throw new DadoNaoExisteException("RNCCI.Dados.Doentes.Apaga");

            //encontra na lista
            int index = doentes.FindIndex(d => d.NumeroUtente.Equals(doente.NumeroUtente));

            //apaga
            doentes.RemoveAt(index);
        }



        /// <summary>
        /// atualizar dados de doentes no sistema
        /// </summary>
        /// <param name="doente">doente com informacoes novas</param>
        /// <exception cref="DadosNulosException">doente e nulo</exception>
        /// <exception cref="DadoNaoExisteException">doente nao existe no sistema</exception>
        public void Atualiza(Doente doente)
        {
            //não pode ser nulo
            if (doente is null)
                throw new DadosNulosException("RNCCI.Dados.Doentes.Atualiza");

            //tem de existir
            if (!this.doentes.Exists(d => d.NumeroUtente.Equals(doente.NumeroUtente)))
                throw new DadoNaoExisteException("RNCCI.Dados.Doentes.Atualiza");

            //encontra na lista
            int index = doentes.FindIndex(d => d.NumeroUtente.Equals(doente.NumeroUtente));

            //atualiza a unidade
            doentes[index] = doente;
        }



        /// <summary>
        /// lista na consola todos os doentes registados no sistema
        /// </summary>
        /// <param name="doentes"></param>
        public void ListarTodosDoentes(List<Doente> doentes)
        {
            foreach (Doente doente in doentes)
                Console.WriteLine(doentes.ToString());
        }
    }
}
