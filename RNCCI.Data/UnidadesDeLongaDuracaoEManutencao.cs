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
    public class UnidadesDeLongaDuracaoEManutencao
    {
        //variaveis
        List<UnidadeDeLongaDuracaoEManutencao> unidadesULDM = new List<UnidadeDeLongaDuracaoEManutencao>();

        /// <summary>
        /// adiciona uma unidade no sistema
        /// </summary>
        /// <param name="novaUnidade">nova unidade a ser adicionada</param>
        /// <exception cref="DadosNulosException">novaUnidade e nulo</exception>
        /// <exception cref="DadoJaExisteException">unidade ja existe no sistema</exception>
        public void Add(UnidadeDeLongaDuracaoEManutencao novaUnidade)
        {
            //não pode ser nulo
            if (novaUnidade is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Add");

            //nao pode existir
            if (this.unidadesULDM.Exists(ldm => ldm.NumeroULDM.Equals(novaUnidade.NumeroULDM)))
                throw new DadoJaExisteException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Add");

            //adiciona
            this.unidadesULDM.Add(novaUnidade);
        }

        /// <summary>
        /// metodo para apagar unidades no sistema
        /// </summary>
        /// <param name="unidadeULDM">unidade a eliminar</param>
        /// <exception cref="DadosNulosException">unidadeULDM e nulo</exception>
        /// <exception cref="DadoNaoExisteException">unidade a eliminar nao existe no sistema</exception>
        public void Apaga(UnidadeDeLongaDuracaoEManutencao unidadeULDM)
        {
            //não pode ser nulo
            if (unidadeULDM is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Delete");

            //tem de existir
            if (!this.unidadesULDM.Exists(ldm => ldm.NumeroULDM.Equals(unidadeULDM.NumeroULDM)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Delete");

            //encontra na lista
            int index = unidadesULDM.FindIndex(ldm => ldm.NumeroULDM.Equals(unidadeULDM.NumeroULDM));

            //apaga
            unidadesULDM.RemoveAt(index);
        }

        /// <summary>
        /// metodo para atualizar os dados de unidades
        /// </summary>
        /// <param name="unidadeULDM">unidade com as informacoes atualizadas</param>
        /// <exception cref="DadosNulosException">unidadeULDM e nulo</exception>
        /// <exception cref="DadoNaoExisteException">unidade a atualizar nao existe no sistema</exception>
        public void Atualiza(UnidadeDeLongaDuracaoEManutencao unidadeULDM)
        {
            //não pode ser nulo
            if (unidadeULDM is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Update");

            //tem de existir
            if (!this.unidadesULDM.Exists(ldm => ldm.NumeroULDM.Equals(unidadeULDM.NumeroULDM)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Update");

            //encontra na lista
            int index = unidadesULDM.FindIndex(ldm => ldm.NumeroULDM.Equals(unidadeULDM.NumeroULDM));

            //atualiza a unidade
            unidadesULDM[index] = unidadeULDM;
        }

       
    }
}
