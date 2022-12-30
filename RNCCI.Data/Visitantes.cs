using RNCCI.Excecoes;
using RNCCI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Dados
{
    public class Visitantes
    {
        //variaveis
        List<Visitante> visitantes = new List<Visitante>();

        /// <summary>
        /// construtor
        /// </summary>
        public Visitantes() => visitantes.Add(new Visitante { Nome = "Maria Figueiras", NumeroContribuinte = 4375, NumeroTelemovel = 934659324 });

        //metodos

        /// <summary>
        /// adiciona visitantes a lista
        /// </summary>
        /// <param name="novoVisitante">visitante a adicionar</param>
        /// <exception cref="DadosNulosException">novoVisitante e nulo</exception>
        /// <exception cref="DadoJaExisteException">visitante ja existe no sistema</exception>
        public void Add(Visitante novoVisitante)
        {
            //não pode ser nulo
            if (novoVisitante is null)
                throw new DadosNulosException("RNCCI.Dados.Visitantes.Add");

            //nao pode existir
            if (this.visitantes.Exists(v => v.NumeroVisitante.Equals(novoVisitante.NumeroVisitante)))
                throw new DadoJaExisteException("RNCCI.Dados.Visitantes.Add");

            //adiciona
            this.visitantes.Add(novoVisitante);
        }



        /// <summary>
        /// apaga visitantes do sistema
        /// </summary>
        /// <param name="visitante">visitante a eliminar</param>
        /// <exception cref="DadosNulosException">visitante e nulo</exception>
        /// <exception cref="DadoNaoExisteException">visitante nao existe no sistema</exception>
        public void Apaga(Visitante visitante)
        {
            //não pode ser nulo
            if (visitante is null)
                throw new DadosNulosException("RNCCI.Dados.Visitantes.Apaga");

            //tem de existir
            if (!this.visitantes.Exists(v => v.NumeroVisitante.Equals(visitante.NumeroVisitante)))
                throw new DadoNaoExisteException("RNCCI.Dados.Visitantes.Apaga");

            //encontra na lista
            int index = visitantes.FindIndex(v => v.NumeroVisitante.Equals(visitante.NumeroVisitante));

            //apaga
            visitantes.RemoveAt(index);
        }



        /// <summary>
        /// atualiza informacoes sobre visitantes
        /// </summary>
        /// <param name="visitante">visitante com as informacoes atualizadas</param>
        /// <exception cref="DadosNulosException">visitante e nulo</exception>
        /// <exception cref="DadoNaoExisteException">visitante nao existe no sistema</exception>
        public void Atualiza(Visitante visitante)
        {
            //não pode ser nulo
            if (visitante is null)
                throw new DadosNulosException("RNCCI.Dados.Visitantes.Atualiza");

            //tem de existir
            if (!this.visitantes.Exists(v => v.NumeroVisitante.Equals(visitante.NumeroVisitante)))
                throw new DadoNaoExisteException("RNCCI.Dados.Visitantes.Atualiza");

            //encontra na lista
            int index = visitantes.FindIndex(v => v.NumeroVisitante.Equals(visitante.NumeroVisitante));

            //atualiza a unidade
            visitantes[index] = visitante;
        }
    }
}
