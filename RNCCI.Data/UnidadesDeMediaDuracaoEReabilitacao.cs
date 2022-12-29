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
    public class UnidadesDeMediaDuracaoEReabilitacao
    {
        //variaveis
        List<UnidadeDeMediaDuracaoEReabilitacao> unidadesMDR = new List<UnidadeDeMediaDuracaoEReabilitacao>();


        /// <summary>
        /// adiciona uma unidade ao sistema
        /// </summary>
        /// <param name="novaUnidade">unidade a atualizar </param>
        /// <exception cref="DadosNulosException">novaUnidade e nulo</exception>
        /// <exception cref="DadoJaExisteException">a unidade ja existe no sistema</exception>
        public void Add(UnidadeDeMediaDuracaoEReabilitacao novaUnidade)
        {
            //não pode ser nulo
            if (novaUnidade is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadeDeMediaDuracaoEReabilitacao.Add");

            //nao pode existir
            if (this.unidadesMDR.Exists(mdr => mdr.NumeroUMDR.Equals(novaUnidade.NumeroUMDR)))
                    throw new DadoJaExisteException("RNCCI.Dados.UnidadesClinicas.Add");

            //adiciona
            unidadesMDR.Add(novaUnidade);
        }

        /// <summary>
        /// eliminar unidades no sistema
        /// </summary>
        /// <param name="unidadeUMDR">unidade a eliminar</param>
        /// <exception cref="DadosNulosException">unidadeUMDR e nulo</exception>
        /// <exception cref="DadoNaoExisteException">unidade a eliminar nao existe no sistema</exception>
        public void Apaga(UnidadeDeMediaDuracaoEReabilitacao unidadeUMDR)
        {
            //não pode ser nulo
            if (unidadeUMDR is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadeDeMediaDuracaoEReabilitacao.Delete");

            //tem de existir
            if (!this.unidadesMDR.Exists(mdr => mdr.NumeroUMDR.Equals(unidadeUMDR.NumeroUMDR)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesClinicas.Delete");

            //encontra na lista
            int index = unidadesMDR.FindIndex(mdr => mdr.NumeroUMDR.Equals(unidadeUMDR.NumeroUMDR));

            //apaga
            unidadesMDR.RemoveAt(index);
        }


        /// <summary>
        /// atualiza unidades no sistema
        /// </summary>
        /// <param name="unidadeUMDR">unidade com as informacoes atualizadas</param>
        /// <exception cref="DadosNulosException">unidadeUMDR e nulo</exception>
        /// <exception cref="DadoNaoExisteException">unidade a atualizar nao existe no sistema</exception>
        public void Atualiza(UnidadeDeMediaDuracaoEReabilitacao unidadeUMDR)
        {
            //não pode ser nulo
            if (unidadeUMDR is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadeDeMediaDuracaoEReabilitacao.Update");

            //tem de existir
            if (!this.unidadesMDR.Exists(mdr => mdr.NumeroUMDR.Equals(unidadeUMDR.NumeroUMDR)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesClinicas.Update");

            //encontra na lista
            int index = unidadesMDR.FindIndex(mdr => mdr.NumeroUMDR.Equals(unidadeUMDR.NumeroUMDR));

            //atualiza a unidade
            unidadesMDR[index] = unidadeUMDR;
        }

    }
}
