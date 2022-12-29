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

        public void Delete(UnidadeDeLongaDuracaoEManutencao unidadeULDM)
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

        public void Update(UnidadeDeLongaDuracaoEManutencao unidadeULDM)
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

        /// <summary>
        /// Cria a lista os doentes, as unidades e tipologias e a quantidade de camas disponíveis nestes
        /// </summary>
        /// <param name="unidadeFiltrada">unidade correspondente à do doente</param>
        /// <returns>retorna a lista de todos os doentes filtrados por tipologia</returns>
        private List<RegistoClinico> ListaTodosOsDoentesTipologia(List<RegistoClinico> registoClinico, Tipologia unidadeFiltrada) => this.registosClinicos.Where(r => r.UnidadeClinica.Tipologia.Equals(unidadeFiltrada)).ToList();
    }
}
