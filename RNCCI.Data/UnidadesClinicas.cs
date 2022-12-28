﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Modelos;
using RNCCI.Excecoes;
using RNCCI.Enums;

namespace RNCCI.Dados
{
    public class UnidadesClinicas
    {
        //lista
        List<UnidadeClinica> unidadesC = new List<UnidadeClinica>();

        /// <summary>
        /// constructor
        /// </summary>
        public UnidadesClinicas()
        {
            unidadesC.Add(new UnidadeClinica() { Nome = "Sorriso" });
            unidadesC.Add(new UnidadeClinica() { Nome = "Vida" });
        }

        //metodos

        /// <summary>
        /// Lista todas as unidades
        /// </summary>
        public List<UnidadeClinica> ListaUC => this.unidadesC;

        /// <summary>
        /// usar este metodo para a insersao de novas clinicas
        /// </summary>
        /// <param name="novaClinica">nova clinica a ser inserida no sistema</param>
        /// <exception cref="DadosNulosException">se os dados a serem inseridos sao nulos, a insercao não é possivel</exception>
        /// <exception cref="DadoJaExisteException">se a clinica ja existe no sistema nao pode ser inserida novamente</exception>
        public void Add(UnidadeClinica novaClinica)
        {
            //não pode ser nulo
            if (novaClinica is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesClinicas.Add");

            //verificar se a clinica já existe na clinica
            if (this.unidadesC.Exists(u => u.NumeroClinica.Equals(novaClinica.NumeroClinica)))
                throw new DadoJaExisteException("RNCCI.Dados.UnidadesClinicas.Add");

            //adiciona
            this.unidadesC.Add(novaClinica);
        }

        public void Delete(UnidadeClinica unidadeC)
        {
            //não pode ser nulo
            if (unidadeC is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesClinicas.Delete");

            //a unidade tem de existir para ser eliminada
            if (!this.unidadesC.Exists(dcci => dcci.NumeroClinica.Equals(unidadeC.NumeroClinica)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesClinicas.Delete");

            //encontra o index da unidade na lista
            int index = unidadesC.FindIndex(dcci => dcci.NumeroClinica.Equals(unidadeC.NumeroClinica));

            //remove a unidade
            unidadesDCCI.RemoveAt(index);
        }

        public void Update(UnidadeClinica unidadeC)
        {
            //não pode ser nulo
            if (unidadeDCCI is null)
                throw new DadosNulosException("RNCCI.Dados.EquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Update");

            //tem de existir
            if (!this.unidadesDCCI.Exists(dcci => dcci.NumeroEDCCI.Equals(unidadeDCCI.NumeroEDCCI)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadeEquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Update");

            //encontra na lista
            int index = unidadesDCCI.FindIndex(dcci => dcci.NumeroEDCCI.Equals(unidadeDCCI.NumeroEDCCI));

            //atualiza a unidade
            unidadesDCCI[index] = unidadeDCCI;
        }

        public void ListarTodosOsUnidadesClínicas(List<UnidadeClinica> unidadeClinica)
        {
            foreach (UnidadeClinica unidadeClinica in unidadesC)
            {
                Console.WriteLine(unidadesC.ToString());
            }
        }
    }
}
