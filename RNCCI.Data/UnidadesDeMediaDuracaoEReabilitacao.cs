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

        public void Add(UnidadeDeMediaDuracaoEReabilitacao novaClinica)
        {
            //não pode ser nulo
            if (novaClinica is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadeDeMediaDuracaoEReabilitacao.Add");

            //nao pode existir
            if (this.unidadesMDR.Exists(mdr => mdr.NumeroUMDR.Equals(novaClinica.NumeroUMDR)))
                    throw new DadoJaExisteException("RNCCI.Dados.UnidadesClinicas.Add");

            //adiciona
            unidadesMDR.Add(novaClinica);
        }

        public void Delete(UnidadeDeMediaDuracaoEReabilitacao unidadeUMDR)
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

        public void Update(UnidadeDeMediaDuracaoEReabilitacao unidadeUMDR)
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

        /// <summary>
        /// Cria a lista os doentes, as unidades e tipologias e a quantidade de camas disponíveis nestes
        /// </summary>
        /// <param name="unidadeFiltrada">unidade correspondente à do doente</param>
        /// <returns>retorna a lista de todos os doentes filtrados por tipologia</returns>
        private List<RegistoClinico> ListaTodosOsDoentesTipologia(List<RegistoClinico> registoClinico, Tipologia unidadeFiltrada) => this.registosClinicos.Where(r => r.UnidadeClinica.Tipologia.Equals(unidadeFiltrada)).ToList();
    }
}
