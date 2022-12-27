using System;
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
        List<UnidadeClinica> unidades = new List<UnidadeClinica>();

        /// <summary>
        /// constructor
        /// </summary>
        //public UnidadesClinicas()
        //{
        //    unidades.Add(new UnidadeClinica(Distrito.Beja) { Nome = "Sorriso" });
        //    unidades.Add(new UnidadeClinica(Distrito.Braga) { Nome = "Vida" });
        //}

        //metodos

        /// <summary>
        /// Lista todas as unidades
        /// </summary>
        public List<UnidadeClinica> Lista => this.unidades;

        /// <summary>
        /// usar este metodo para a insersao de novas clinicas
        /// </summary>
        /// <param name="novaClinica">nova clinica a ser inserida no sistema</param>
        /// <exception cref="DadosNulosException">se os dados a serem inseridos sao nulos, a insercao não é possivel</exception>
        /// <exception cref="ClinicaJaExisteException">se a clinica ja existe no sistema nao pode ser inserida novamente</exception>
        public void Add(UnidadeClinica novaClinica)
        {
            //não pode ser nulo
            if (novaClinica is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesClinicas.Add");

            //verificar se a clinica já existe na clinica
            if (this.unidades.Exists(u => u.NumeroClinica.Equals(novaClinica.NumeroClinica)))
                throw new ClinicaJaExisteException("RNCCI.Dados.UnidadesClinicas.Add");

            this.unidades.Add(novaClinica);
        }

       
       
    }
}
