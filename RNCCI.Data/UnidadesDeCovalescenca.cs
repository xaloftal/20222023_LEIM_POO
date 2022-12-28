﻿using System;
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
            unidadesUCo.Add(new UnidadeDeCovalescenca(3) { Nome = "Cojito", /*Rua não tou a conseguir meter, será que morada tem de ser interface?*/ });
        }


        //propriedades

        /// <summary>
        /// Lista todas as unidades de covalescenca
        /// </summary>
        public List<UnidadeDeCovalescenca> ListaUCo => this.unidadesUCo.ToList();

        public List<Medico> Medicos { get; set; } = new List<Medico>(); //esta parte não tenho certeza
        public List<Doente> Doentes = new List<Doente>(); //tipo ya, acho que não porque em Medicos não está a dar

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

        public void Delete(UnidadeDeCovalescenca unidadeUCo)
        {
            //não pode ser nulo
            if (unidadeUCo is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeCovalenscenca.Delete");

            //a unidade tem de existir para ser eliminada
            if (!this.unidadesUCo.Exists(co => co.NumeroUC.Equals(unidadeUCo.NumeroUC)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesDeCovalenscenca.Delete");

            //encontra o index da unidade na lista
            int index = unidadesUCo.FindIndex(co => co.NumeroUC.Equals(unidadeUCo.NumeroUC));

            //remove a unidade
            unidadesUCo.RemoveAt(index);
        }


        public void Update(UnidadeDeCovalescenca unidadeUCo)
        {
            //não pode ser nulo
            if (unidadeUCo is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeCovalenscenca.Update");

            //tem de existir
            if (!this.unidadesUCo.Exists(co => co.NumeroUC.Equals(unidadeUCo.NumeroUC)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesDeCovalenscenca.Delete");

            //encontra na lista
            int index = unidadesUCo.FindIndex(co => co.NumeroUC.Equals(unidadeUCo.NumeroUC));

            //atualiza a unidade
            unidadesUCo[index] = unidadeUCo;
        }
    }
}
