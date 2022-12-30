using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Modelos;
using RNCCI.Enums;
using RNCCI.Excecoes;

namespace RNCCI.Dados
{
    public class UnidadesDeCovalescenca
    {
        //variaveis
        List<UnidadeDeCovalescenca> unidadesUCo = new List<UnidadeDeCovalescenca>();



        /// <summary>
        /// construtor
        /// </summary>
        public UnidadesDeCovalescenca()
        {
            unidadesUCo.Add(new UnidadeDeCovalescenca(6) { Nome = "Coativo" });
            unidadesUCo.Add(new UnidadeDeCovalescenca(3) { Nome = "Cojito" });
        }


        //propriedades

        /// <summary>
        /// Lista de todas as unidades de covalescenca
        /// </summary>
        public List<UnidadeDeCovalescenca> ListaUCo => this.unidadesUCo.ToList();


        //metodos

        /// <summary>
        /// este metodo permite controlar o que e adicionado
        /// </summary>
        /// <param name="novaUnidade">unidade de covalescenca a ser adicionada</param>
        /// <exception cref="DadosNulosException">se novaUnidade e nulo</exception>
        /// <exception cref="DadoJaExisteException">se novaUnidade ja existe no sistema</exception>
        public void Add(UnidadeDeCovalescenca novaUnidade)
        {
            //não pode ser nulo
            if (novaUnidade is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeCovalescenca.Add");

            //nao pode existir duas clinicas iguais
            if (this.unidadesUCo.Exists(co => co.NumeroUC.Equals(novaUnidade.NumeroUC)))
                throw new DadoJaExisteException("RNCCI.Dados.UnidadesDeCovalescenca.Add");

            //adiciona
            this.unidadesUCo.Add(novaUnidade);
        }



        /// <summary>
        /// usar este metodo para eliminar unidades no sistema
        /// </summary>
        /// <param name="unidadeUCo">unidade a ser eliminada</param>
        /// <exception cref="DadosNulosException">se unidadeUCo é nula</exception>
        /// <exception cref="DadoNaoExisteException">se a unidade a ser eliminada não existe</exception>
        public void Apaga(UnidadeDeCovalescenca unidadeUCo)
        {
            //não pode ser nulo
            if (unidadeUCo is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeCovalenscenca.Apaga");

            //a unidade tem de existir para ser eliminada
            if (!this.unidadesUCo.Exists(co => co.NumeroUC.Equals(unidadeUCo.NumeroUC)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesDeCovalenscenca.Apaga");

            //encontra o index da unidade na lista
            int index = unidadesUCo.FindIndex(co => co.NumeroUC.Equals(unidadeUCo.NumeroUC));

            //remove a unidade
            unidadesUCo.RemoveAt(index);
        }



        /// <summary>
        /// usar este metodo para atualizar unidades de covalescenca
        /// </summary>
        /// <param name="unidadeUCo">unidade com os dados atualizados</param>
        /// <exception cref="DadosNulosException">caso unidadeUCo esteja nula</exception>
        /// <exception cref="DadoNaoExisteException">caso a unidade original não exista</exception>
        public void Atualiza(UnidadeDeCovalescenca unidadeUCo)
        {
            //não pode ser nulo
            if (unidadeUCo is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeCovalenscenca.Atualiza");

            //tem de existir
            if (!this.unidadesUCo.Exists(co => co.NumeroUC.Equals(unidadeUCo.NumeroUC)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesDeCovalenscenca.Atualiza");

            //encontra na lista
            int index = unidadesUCo.FindIndex(co => co.NumeroUC.Equals(unidadeUCo.NumeroUC));

            //atualiza a unidade
            unidadesUCo[index] = unidadeUCo;
        }   
        
    }
}
